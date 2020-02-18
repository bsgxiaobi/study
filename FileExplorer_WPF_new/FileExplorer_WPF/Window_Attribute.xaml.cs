using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Threading;
using System.Windows.Threading;

namespace FileExplorer_WPF
{
    /// <summary>
    /// Window_Attribute.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Attribute : Window
    {
        Thread thread;//多线程，用来执行统计文件夹信息
        public bool judgeDfs = true;//判断深度搜索时是否出错
        private string dirpath, filename, filetype, iconpath;
        public long folder_size = 0;//文件夹大小
        public int folder_num = 0, folder_file_num = 0;//文件夹内的目录个数，文件夹内的文件个数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="name">文件名称</param>
        /// <param name="ftype">文件类型</param>
        /// <param name="icon">图标地址</param>
        public Window_Attribute(string path, string name, string ftype, string icon)
        {
            ResizeMode = System.Windows.ResizeMode.NoResize;//设置窗口不能调整大小
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            dirpath = path;
            filename = name;
            filetype = ftype;
            iconpath = icon;
            Window_Load();
        }

        /// <summary>
        /// 界面数据初始化
        /// </summary>
        public void Window_Load()
        {
            //填充图标路径
            image_icon.Source = new BitmapImage(new Uri(iconpath, UriKind.Absolute));
            //判断是否为磁盘分区
            if (dirpath == "")
            {
                GetDiskInfo();
                return;
            }
            //填充公共信息
            lb_type.Content = filetype;//文件类型
            lb_name.Content = filename;//名称
            lb_dir.Content = dirpath;//位置路径
            //判断是否为文件夹
            if (Directory.Exists(dirpath + filename))
            {
                GetFolderInfo();
                return;
            }
            //判断是否为文件
            if (File.Exists(dirpath + filename))
            {
                GetFileInfo();
                return;
            }
        }

        //获取磁盘分区信息
        public void GetDiskInfo()
        {
            //设置驱动器键值对
            Dictionary<string, string> drivetype_dict = new Dictionary<string, string>();
            drivetype_dict.Add("CDRom", "(光驱)");
            drivetype_dict.Add("Fixed", "(固定磁盘)");
            drivetype_dict.Add("Unknown", "(未知磁盘)");
            drivetype_dict.Add("Network", "(网络磁盘)");
            DriveInfo[] allDirves = DriveInfo.GetDrives();//获取所有逻辑驱动器
            int index = 0;//驱动器索引
            for (int i = 0; i < allDirves.Count(); i++)
            {
                if (allDirves[i].Name == filename) index = i;
            }
            //判断是否准备就绪,未就绪时退出
            if (!allDirves[index].IsReady)
            {
                MessageBox.Show("当前驱动器未就绪");
                this.Close();
            }
            string str_volume_label = allDirves[index].VolumeLabel;//卷标
            if (str_volume_label == "") str_volume_label = "本地磁盘";
            lb_name.Content = str_volume_label;
            string str_type = allDirves[index].DriveType.ToString();//驱动器类型
            lb_type.Content = str_type + drivetype_dict[str_type];
            string str_format = allDirves[index].DriveFormat;//文件系统
            lb_file_system.Content = str_format;
            long total_size = allDirves[index].TotalSize;//总容量空间，单位：字节
            long total_free_space = allDirves[index].TotalFreeSpace;//总空闲空间
            long used_space = total_size - total_free_space;//总已用空间
            string str_total = GetDiskGB(double.Parse(total_size.ToString()));
            string str_free = GetDiskGB(double.Parse(total_free_space.ToString()));
            string str_used = GetDiskGB(double.Parse(used_space.ToString()));
            lb_dir_title.Content = "空间总量：";
            lb_dir.Content = total_size.ToString() + " 字节\t" + str_total.Split('.')[0].ToString() + " GB";
            lb_size_title.Content = "已用空间：";
            lb_size.Content = total_free_space + " 字节\t" + str_free + " GB";
            //设置颜色#666666
            lb_size_title.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#666666"));
            lb_size.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#666666"));
            lb_include_title.Content = "可用空间：";
            lb_include.Content = used_space + " 字节\t" + str_used + " GB";
            //设置颜色#26A0DA
            lb_include_title.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#26A0DA"));
            lb_include.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#26A0DA"));
            //删除无用空间
            StackPanel sp = Grid_main.FindName("StackPanel_time") as StackPanel;
            Grid_main.Children.Remove(sp);
            Grid_main.UnregisterName("StackPanel_time");
            StackPanel sp1 = Grid_main.FindName("StackPanel_time_title") as StackPanel;
            Grid_main.Children.Remove(sp1);
            Grid_main.UnregisterName("StackPanel_time_title");
            ShowDiskPart(str_free,str_used);

        }

        //获取文件夹信息
        public void GetFolderInfo()
        {
            //使用多线程来获取文件夹大小信息，防止界面卡顿,使用UI线程
            thread = new Thread(ModifyUI);
            thread.Start();
            DirectoryInfo folder_info = new DirectoryInfo(dirpath + filename);
            //获取创建时间
            string create_time = string.Format("{0:yyyy/MM/dd HH:mm}", folder_info.CreationTime);
            lb_create_time.Content = create_time;
            //将其他不必要的信息隐藏
            lb_file_system_title.IsEnabled = false;
            lb_file_system.IsEnabled = false;
            //将修改时间和访问时间设为空
            lb_file_system_title.Content = "";
            lb_file_system.Content = "";
            lb_modify_time_title.Content = "";
            lb_modify_time.Content = "";
            lb_access_time_title.Content = "";
            lb_access_time.Content = "";
            //将信息设置为正在获取...
            lb_size.Content = "正在计算...";
            lb_include.Content = "正在计算...";
        }

        //获取文件信息
        public void GetFileInfo()
        {
            FileInfo file_info = new FileInfo(dirpath + filename);
            //获取文件大小
            string file_size = "";
            long size_tmp = file_info.Length / 1024;
            if (size_tmp == 0) file_size = "1 KB";
            else if (size_tmp / 1024 < 1) file_size = (size_tmp / 1024).ToString() + " MB";
            else file_size = size_tmp.ToString() + " KB";
            //创建时间
            string create_time = string.Format("{0:yyyy/MM/dd HH:mm}", file_info.CreationTime);
            //上次修改时间
            string modify_time = string.Format("{0:yyyy/MM/dd HH:mm}", file_info.LastWriteTime);
            //上次访问时间
            string access_time = string.Format("{0:yyyy/MM/dd HH:mm}", file_info.LastAccessTime);
            lb_size.Content = file_size;
            lb_create_time.Content = create_time;
            lb_modify_time.Content = modify_time;
            lb_access_time.Content = access_time;

            //将其他不必要的信息隐藏
            //隐藏文件系统栏
            lb_file_system_title.Content = "";
            lb_file_system.Content = "";
            lb_include_title.Content = "";
            lb_include.Content = "";
        }

        //将字节转为GB
        public string GetDiskGB(double tmp)
        {
            for (int i = 0; i < 3; i++) tmp /= 1024.0;
            return tmp.ToString("N1");//保留一位小数
        }

        //深度搜索文件夹
        public void DfsFolder(string path)
        {
            if (!judgeDfs) return;
            //需要判断是否有权限
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] file_arr = dir.GetFiles();//先获取当前目录的文件
                foreach (FileInfo files in file_arr)
                {
                    folder_size += files.Length / 1024;//累积文件大小
                }
                if (file_arr != null) folder_file_num += file_arr.Count();//累积文件数量

                DirectoryInfo[] folderinfo = dir.GetDirectories();
                foreach (DirectoryInfo dirinfo in folderinfo)
                {
                    DfsFolder(dirinfo.FullName);//访问子目录
                    folder_num++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                judgeDfs = false;
                return;
            }
        }

        //更新窗口的文件夹大小信息，采用多线程
        public void ModifyUI()
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                DfsFolder(dirpath + filename);
                if (!judgeDfs)
                {
                    lb_size.Content = "获取失败";
                    lb_include.Content = "获取失败";
                    return;
                }
                string str_unit = " KB";
                if (folder_size / 1024 > 1)
                {
                    folder_size = folder_size / 1024;
                    str_unit = " MB";
                }
                lb_size.Content = folder_size.ToString() + str_unit;
                lb_include.Content = folder_file_num.ToString() + " 个文件，" + folder_num.ToString() + " 个文件夹";
            });
        }

        //显示磁盘空间使用情况图
        public void ShowDiskPart(string str_free, string str_used)
        {
            double free = double.Parse(str_free);
            double used = double.Parse(str_used);
            Point midPoint = new Point();//创建一个画笔
            //创建圆环对象，
            var ringParts = new List<RingPart>();
            //ringParts.Add(new RingPart(0, 0, 0, 0, Brushes.White));//指定为0，则显示无圆环
            ringParts.Add(new RingPart(0, 0, 60, 60, Brushes.White));//指定为0，则显示无圆环
            //创建椭圆对象list 
            var sectorParts = new List<SectorPart>();
            //计算出占用角度
            double tmp = free / (free + used) * 360;
            int angle_free = int.Parse(tmp.ToString().Split('.')[0]);
            int angle_used = 360 - angle_free;
            //定义两种颜色
            SolidColorBrush color_free = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#666666"));
            SolidColorBrush color_used = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#26A0DA"));
            //判断角度是否大于180，因为画笔最大180°
            if (angle_free > 180)
            {
                sectorParts.Add(new SectorPart(180, color_free));
                sectorParts.Add(new SectorPart(angle_free - 180, color_free));
            }
            else sectorParts.Add(new SectorPart(angle_free, color_free));
            if (angle_used > 180)
            {
                sectorParts.Add(new SectorPart(180, color_used));
                sectorParts.Add(new SectorPart(angle_used - 180, color_used));
            }
            else sectorParts.Add(new SectorPart(angle_used, color_used));
            //画平面圆形扇图
            var shapes = PieChartDrawer.GetPieChartShapes(midPoint, 80, 0, sectorParts, ringParts);
            foreach (var shape in shapes)
            {
                GridPie.Children.Add(shape);
            }
        }
    }
}
