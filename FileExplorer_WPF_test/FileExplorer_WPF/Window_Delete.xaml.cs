using System;
using System.Collections.Generic;
using System.IO;
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

namespace FileExplorer_WPF
{
    /// <summary>
    /// Window_Delete.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Delete : Window
    {
        private List<string> list_del_path;//删除路径
        public Window_Delete(List<string> list,string icon_path)
        {
            ResizeMode = System.Windows.ResizeMode.NoResize;//设置窗口不能调整大小
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            list_del_path = list;
            //设置图标
            image_icon.Source = new BitmapImage(new Uri(icon_path, UriKind.Absolute));
            Window_Delete_Load();
        }
        /// <summary>
        /// 界面数据初始化
        /// </summary>
        public void Window_Delete_Load()
        {
            //查询出信息
            string str_name, str_type, str_time, str_size;//名称，类型，上次修改时间，大小
            //判断是否选中了多个
            if (list_del_path.Count > 1)
            {
                textBlock_Info.Text = "多个文件\n\n谨慎操作";
            }
            else
            {
                //先判断是目录还是文件
                if (Directory.Exists(list_del_path[0]))
                {
                    DirectoryInfo forder_info = new DirectoryInfo(list_del_path[0]);
                    str_name = forder_info.Name;
                    str_time = string.Format("{0:yyyy/MM/dd HH:mm}", forder_info.LastWriteTime);
                    textBlock_Info.Text = str_name + "\n" + "类型:文件夹\n" + "修改时间:" + str_time;
                }
                if (File.Exists(list_del_path[0]))
                {
                    FileInfo file_info = new FileInfo(list_del_path[0]);
                    str_name = file_info.Name;
                    if (file_info.Extension.Length > 1) str_type = file_info.Extension.Substring(1);
                    else str_type = "未知文件";
                    str_time = string.Format("{0:yyyy/MM/dd HH:mm}", file_info.LastWriteTime);
                    long filesize = file_info.Length / 1024;
                    if (filesize > 1024)
                    {
                        //大于1MB时
                        double db = (double)filesize / 1024.0;
                        str_size = db.ToString("f1") + " MB";
                    }
                    else str_size = filesize.ToString() + " KB";
                    textBlock_Info.Text = str_name + "\n类型: " + str_type + "\n修改时间: " + str_time + "\n大小:" + str_size;
                }
            }
            
        }

        /// <summary>
        /// 删除函数，返回删除是否成功
        /// </summary>
        /// <returns></returns>
        public void DeleteDirectoryOrFile()
        {
            int num = 0;
            List<string> list_error = new List<string>();
            foreach (string del_path in list_del_path)
            {
                try
                {
                    //先判断是目录还是文件
                    if (Directory.Exists(del_path))
                    {
                        Directory.Delete(del_path, true); //删除指定的目录，并删除该目录中的所有子目录和文件
                    }
                    if (File.Exists(del_path))
                    {
                        File.Delete(del_path);//删除指定的文件
                    }
                    num++;
                }
                catch (Exception ex)
                {
                    list_error.Add(del_path);
                }
            }
            if (num > 0)
            {
                string str_error = "";
                foreach(string str in list_error)
                {
                    str_error += str + "\n";
                }
                MessageBox.Show("以下删除失败：\n" + str_error);
            } 
            this.Close();//关闭当前窗口
        }
            

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            DeleteDirectoryOrFile();
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();//关闭当前窗口
        }
    }
}
