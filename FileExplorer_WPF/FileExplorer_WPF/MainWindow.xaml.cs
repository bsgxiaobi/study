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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using System.Data;

namespace FileExplorer_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string str_current_path = "";//DataGrid的当前路径
        ObservableCollection<FileNode> list_info;//在dataGrid区显示的数据
        ObservableCollection<PropertyNodeItem> itemList;//TreeView的数据源
        List<string> list_dick_name = new List<string>();//保存硬盘分区名称
        List<int> list_selection = new List<int>();//列表选中状态数组
        List<string> list_file_dir = new List<string>();//列表选中的文件目录
        string str_icon_path = "";//定义图标文件夹路径
        Dictionary<string, string> Icon_path = new Dictionary<string, string>();//图标路径键值对
        int choose_model = 1;//选择模式，1 单选，-1 多选
        string move_fileordir_model = "";
        //设置驱动器键值对
        Dictionary<string, string> drivetype_dict = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
            //设置窗口垂直水平都居中
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InstantiationPublicOblect();
            MainWindow_Load();
        }

        //实例化一些公共对象-在界面数据初始化前
        public void InstantiationPublicOblect()
        {
            drivetype_dict.Add("CDRom", "光驱");//添加驱动器键值对
            drivetype_dict.Add("Fixed", "固定磁盘");
            drivetype_dict.Add("Unknown", "未知磁盘");
            drivetype_dict.Add("Network", "网络磁盘");
            //获取图标路径键值对
            string str_arr_path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = str_arr_path.Substring(0, str_arr_path.LastIndexOf("bin"));
            str_icon_path = rootpath + "img_FileTypeIcon\\";
            Icon_path = FileOperations.GetIconPath(str_icon_path);
            //使用ObservableCollection类更好的进行双向绑定
            list_info = new ObservableCollection<FileNode>();
            itemList = new ObservableCollection<PropertyNodeItem>();
        }

        /// <summary>
        /// 界面数据初始化
        /// </summary>
        private void MainWindow_Load()
        {
            PropertyNodeItem pni = new PropertyNodeItem()
            {
                Icon = str_icon_path + "computer.png",
                DisplayName = "我的电脑",
                Name = "我的电脑",
                isDir = true
            };
            PropertyNodeItem node5 = new PropertyNodeItem()
            {
                DisplayName = "Tag No.5",
                Name = "测试用的无效节点"
            };
            //初始化树
            //获得所有硬盘分区
            foreach (DriveInfo driveitem in DriveInfo.GetDrives())
            {
                //将硬盘分区名称添加保存到硬盘信息里
                list_dick_name.Add(driveitem.Name);
                string str_type = driveitem.DriveType.ToString();
                str_type = drivetype_dict[str_type];
                //将分区硬盘信息添加到详细信息里
                list_info.Add(new FileNode(false, driveitem.Name, "", str_type, "", str_icon_path+"disk.png"));
                //将硬盘名称添加到树列表中
                string str = driveitem.Name;
                str = str.Substring(0, str.Length - 1);
                //添加到树节点中
                PropertyNodeItem node_tmp = new PropertyNodeItem()
                {
                    Icon = str_icon_path+"disk.png",
                    DisplayName = str,
                    Name = driveitem.Name,
                    isDir = true
                };
                //当磁盘访问就绪时才添加树子节点
                if(driveitem.IsReady) node_tmp.Children.Add(node5);
                pni.Children.Add(node_tmp);
            }
            itemList.Add(pni);
            this.treeView_Dir.ItemsSource = itemList;
            //初始化详细信息
            dataGrid_Info.DataContext = list_info;
            //将返回上一级按钮更改为不可使用
            this.btn_last_path.IsEnabled = false;
        }

        /// <summary>
        /// 获取指定目录的下一级目录
        /// </summary>
        /// <param name="flodername">文件名称</param>
        public void GetChildDirectory(string new_path)
        {
            try
            {
                //判断是否双击的硬盘分区，采用判断当前路径是否为空
                if (str_current_path == "") new_path = new_path.Substring(0, 3);
                //先打开目录
                DirectoryInfo dir = new DirectoryInfo(new_path);
                DirectoryInfo[] dir_arr = dir.GetDirectories();//获取当前目录的子目录
                string str_name = "", str_date = "", str_ty = "";
                list_info.Clear();
                //逐一获取子目录的信息
                foreach (DirectoryInfo subDir in dir_arr)
                {
                    str_name = subDir.Name;
                    str_date = string.Format("{0:yyyy/MM/dd HH:mm}", subDir.LastWriteTime);
                    if (subDir.Exists) str_ty = "文件夹";
                    else str_ty = "未知子目录";
                    list_info.Add(new FileNode(false, str_name, str_date, str_ty,"", str_icon_path+"folder.png"));
                }
                FileInfo[] file_arr = dir.GetFiles();//获取当前目录的文件
                string[] str_tmp;
                string str_tmp_icon_name = "";
                foreach (FileInfo subFile in file_arr)
                {
                    str_name = subFile.Name;
                    str_date = string.Format("{0:yyyy/MM/dd HH:mm}", subFile.LastWriteTime);
                    long kbsize = subFile.Length / 1024;//获取文件大小
                    str_tmp_icon_name = "_blank.png";//设置文件图标默认路径
                    str_tmp = str_name.Split('.');
                    if (str_tmp.Count() > 1)
                    {
                        str_ty = str_tmp[str_tmp.Count() - 1].ToLower();
                    }
                    else str_ty = "未知文件";
                    //获取图标路径
                    if (str_ty != "未知文件")
                    {
                        if (Icon_path.ContainsKey(str_ty))//判断是否存在相应的键
                        {
                            str_tmp_icon_name = Icon_path[str_ty];
                        }
                    }
                    str_tmp = null;
                    list_info.Add(new FileNode(false, str_name, str_date, str_ty, kbsize.ToString() + " KB", str_icon_path+str_tmp_icon_name));
                }
                //this.dataGrid_Info.DataContext = list_info;
                str_current_path = new_path;//新目录为当前目录
                this.txt_Current_Path.Text = str_current_path;//显示当前路径
                //将返回上一级按钮更改为可使用
                if (!this.btn_last_path.IsEnabled) this.btn_last_path.IsEnabled = true;
                choose_model = 1;
                CheckBoxStatusRemove();
                //MenuItem_MultiSelect.Header = "多选";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 判断是否是硬盘分区根目录，暴力判断:地址长度是否为3
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool JudgeIsDickRoot(string path)
        {
            //foreach(string str in list_dick_name)
            //{
            //    if (str.Equals(path)) return true;//有相同
            //}
            //return false;
            if (path.Length == 3) return true;
            else return false;
        }

        /// <summary>
        /// 移除所有选中的CheckBox
        /// </summary>
        public void CheckBoxStatusRemove()
        {
            foreach (int cb_index in list_selection)
            {
                //移除CheckBox选中
                CheckBox cb_single;
                cb_single = dataGrid_Info.Columns[0].GetCellContent(dataGrid_Info.Items[cb_index]) as CheckBox;
                cb_single.IsChecked = false;
                //移除行背景颜色（改为白色）
                DataGridRow dgr = dataGrid_Info.ItemContainerGenerator.ContainerFromItem(dataGrid_Info.Items[cb_index]) as DataGridRow;
                dgr.Background = new SolidColorBrush(Colors.White);
            }
        }

        //显示所有选中的索引
        public void ShowTest()
        {
            string str = "";
            foreach (int i in list_selection)
            {
                str = str + i.ToString() + " , ";
            }
            textBox_test.Text = "选中行索引：" + str;
        }

        //更新多行选中的颜色
        public void UpdateMultilineSelection()
        {
            int n = dataGrid_Info.Items.Count;
            for (int i = 0; i < n; i++)
            {
                //移除CheckBox选中
                CheckBox cb = dataGrid_Info.Columns[0].GetCellContent(dataGrid_Info.Items[i]) as CheckBox;
                if (cb != null) cb.IsChecked = false;
                //移除行背景颜色（改为白色）
                DataGridRow dgr = dataGrid_Info.ItemContainerGenerator.ContainerFromItem(dataGrid_Info.Items[i]) as DataGridRow;
                if (dgr != null) dgr.Background = new SolidColorBrush(Colors.White);
            }
            for (int j = 0; j < list_selection.Count; j++)
            {
                (dataGrid_Info.Columns[0].GetCellContent(dataGrid_Info.Items[list_selection[j]]) as CheckBox).IsChecked = true;
                //行背景颜色
                (dataGrid_Info.ItemContainerGenerator.ContainerFromItem(dataGrid_Info.Items[list_selection[j]]) as DataGridRow).Background = new SolidColorBrush(Color.FromRgb(204, 0, 51));
            }
        }

        //获取列表选中的文件目录
        public void GetSelectionFileDir()
        {
            list_file_dir.Clear();
            foreach (int se_index in list_selection)
            {
                string flodername = (dataGrid_Info.Columns[2].GetCellContent(dataGrid_Info.Items[se_index]) as TextBlock).Text;
                string selected_path = str_current_path + flodername;//当前选中的路径
                list_file_dir.Add(selected_path);
            }
        }

        /// <summary>
        /// 返回上级目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_last_path_Click(object sender, RoutedEventArgs e)
        {
            //判断是否已经在最上一层，不可再点击
            if (this.txt_Current_Path.Text == "我的电脑")
            {
                return;
            }
            //将当前路径的最后一个目录名称删去
            string last_path = str_current_path.Remove(str_current_path.Length - 1, 1);//先删去最后一个"\\"
            int index = last_path.LastIndexOf("\\");//找到最后一个"\\"位置
            last_path = last_path.Substring(0, index + 1);

            //判断是否回溯到硬盘分区,last_path为空也证明要回到了
            //if (JudgeIsDickRoot(str_current_path))
            if (last_path == "")
            {
                list_info.Clear();
                str_current_path = "";
                this.txt_Current_Path.Text = "我的电脑";
                foreach (string str in list_dick_name)
                {
                    //将分区硬盘信息添加到详细信息里
                    list_info.Add(new FileNode(false, str, "", "硬盘分区", "", str_icon_path + "disk.png"));
                }
                //将按钮设置为不可使用
                this.btn_last_path.IsEnabled = false;
            }
            else GetChildDirectory(last_path);
        }

        /// <summary>
        /// 整个dataGrid的鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_Info_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == null) return;
            //判断是否选中文件
            DataGrid dg_tmp = sender as DataGrid;//获取当前对象
            if (dg_tmp.SelectedItems == null || dg_tmp.SelectedItems.Count != 1)
            {
                return;
            }
            int index = dg_tmp.SelectedIndex;
            string flodername = (dg_tmp.Columns[2].GetCellContent(dg_tmp.Items[index]) as TextBlock).Text;
            string selected_path = str_current_path + flodername;//当前选中的路径
            //判断为文件还是目录
            if (File.Exists(selected_path))
            {
                try
                {
                    //打开文件
                    System.Diagnostics.Process.Start(selected_path);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return;
                
            }
            string new_path = selected_path + @"\";//准备的新目录
            GetChildDirectory(new_path);
        }

        /// <summary>
        /// DataGrid中鼠标右键按下时的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_Info_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //判断是否有选中一行
            if (dataGrid_Info.SelectedItems == null || dataGrid_Info.SelectedItems.Count == 0)
            {
                //未选中一行
                MenuItem_Open.IsEnabled = false;
                MenuItem_Refresh.IsEnabled = true;
                MenuItem_Copy.IsEnabled = false;
                MenuItem_Shear.IsEnabled = false;
                MenuItem_Paste.IsEnabled = true;
                MenuItem_Delete.IsEnabled = false;
                MenuItem_Rename.IsEnabled = false;
                MenuItem_Attribute.IsEnabled = false;
                MenuItem_Uncheck.IsEnabled = false;
                //判断是否在硬盘分区目录下
                if (txt_Current_Path.Text == "我的电脑")
                {
                    MenuItem_Refresh.IsEnabled = false;
                    MenuItem_Paste.IsEnabled = false;
                }
            }
            else
            {
                //选中了多行
                MenuItem_Refresh.IsEnabled = false;
                MenuItem_Open.IsEnabled = true;
                MenuItem_Copy.IsEnabled = true;
                MenuItem_Shear.IsEnabled = true;
                MenuItem_Paste.IsEnabled = false;
                MenuItem_Delete.IsEnabled = true;
                MenuItem_Rename.IsEnabled = true;
                MenuItem_Attribute.IsEnabled = true;
                MenuItem_Uncheck.IsEnabled = true;
                //判断是否在硬盘分区目录下
                if (txt_Current_Path.Text == "我的电脑")
                {
                    MenuItem_Copy.IsEnabled = false;
                    MenuItem_Shear.IsEnabled = false;
                    MenuItem_Delete.IsEnabled = false;
                    MenuItem_Rename.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// 鼠标右键菜单功能-打开事件，打开目录或者文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            //if (dataGrid_Info.SelectedItems == null || dataGrid_Info.SelectedItems.Count != 1) MenuItem_Open.IsEnabled = false;
            //else MenuItem_Open.IsEnabled = true;

            dataGrid_Info_MouseDoubleClick(this.dataGrid_Info, null);
        }

        /// <summary>
        /// 鼠标右键菜单功能-刷新事件，刷新当前目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Refresh_Click(object sender, RoutedEventArgs e)
        {
            //只有未选中一行时才执行
            GetChildDirectory(str_current_path);
        }


        /// <summary>
        /// 鼠标右键菜单功能-取消当前选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Uncheck_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxStatusRemove();
            list_selection.Clear();
            dataGrid_Info.SelectedItems.Clear();
        }

        /// <summary>
        /// 鼠标右键菜单功能-删除目录及其中所有文件或文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            GetSelectionFileDir();//获取选中目录
            int index = dataGrid_Info.SelectedIndex;
            string flodername = (dataGrid_Info.Columns[2].GetCellContent(dataGrid_Info.Items[index]) as TextBlock).Text;
            string str = str_current_path + flodername;//当前选中的路径
            string str_icon = "";
            string str_type = "";
            if (list_file_dir.Count > 1) str_icon = str_icon_path + "folder.png";
            else
            {
                str_icon = (dataGrid_Info.Items[index] as FileNode).IconPath;
                str_type = (dataGrid_Info.Columns[4].GetCellContent(dataGrid_Info.Items[index]) as TextBlock).Text;
            }
            Window_Delete window_del = new Window_Delete(list_file_dir, str_icon);
            window_del.ShowDialog();//新窗口关闭时才返回
            GetChildDirectory(str_current_path);//更新目录
        }

        /// <summary>
        /// 鼠标右键菜单功能-多选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_MultiSelect_Click(object sender, RoutedEventArgs e)
        {
            choose_model *= -1;
            MenuItem multiselect = sender as MenuItem;
            if (choose_model == -1)
            {
                //变为多选状态
                multiselect.Header = "取消多选";
            }
            else
            {
                //变为单选状态
                multiselect.Header = "多选";

            }
            CheckBoxStatusRemove();
            list_selection.Clear();
            ShowTest();
            dataGrid_Info.SelectedItems.Clear();
        }

        /// <summary>
        /// 鼠标右键菜单功能-复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Copy_Click(object sender, RoutedEventArgs e)
        {
            GetSelectionFileDir();//获取选中目录
            move_fileordir_model = "copy";
        }

        /// <summary>
        /// 鼠标右键菜单功能-剪切
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Shear_Click(object sender, RoutedEventArgs e)
        {
            GetSelectionFileDir();//获取选中目录
            move_fileordir_model = "shear";
        }

        /// <summary>
        /// 鼠标右键菜单功能-粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Paste_Click(object sender, RoutedEventArgs e)
        {
            
            if (list_file_dir.Count == 0)
            {
                MessageBox.Show("未 复制/剪切 任何项\n且需要未选中行时才可使用");
                return;
            }
            FileOperations fileoper = new FileOperations();
            string info = fileoper.PasteFileOrDir(list_file_dir, str_current_path, move_fileordir_model);
            GetChildDirectory(str_current_path);//刷新目录
            MessageBox.Show(info);
            if (info == "成功") list_file_dir.Clear();//成功后清除复制/剪切路径列表

        }

        /// <summary>
        /// 右键菜单功能-重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Rename_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Info.SelectedItem == null) return;
            string name = (dataGrid_Info.SelectedItem as FileNode).FileName;
            Window_Rename win_rename = new Window_Rename(str_current_path, name);
            win_rename.ShowDialog();
            GetChildDirectory(str_current_path);//更新目录
        }

        /// <summary>
        /// 鼠标右键菜单功能-属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Attribute_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Info.SelectedItem == null) return;
            string name = (dataGrid_Info.SelectedItem as FileNode).FileName;
            string filetype = (dataGrid_Info.SelectedItem as FileNode).FileType;
            string icon = (dataGrid_Info.SelectedItem as FileNode).IconPath;
            Window_Attribute win_attr = new Window_Attribute(str_current_path, name, filetype, icon);
            try
            {
                win_attr.Show();
            }catch(Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// 鼠标dataGrid中的被选中改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_Info_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int num = dataGrid_Info.SelectedItems.Count;
            //int[] arr_index = new int[num];
            //DataRowView[] dr = new DataRowView[num];
            //int z;
            //for (int i = 0; i < num; i++)
            //{
            //    //获取被选中行的行内容
            //    //dr[i] = dataGrid_Info.SelectedItems[i] as DataRowView;
            //    //获取被选中行的行号
            //    z= dataGrid_Info.Items.IndexOf(dataGrid_Info.SelectedCells[i].Item);
            //    arr_index[i] = z;
            //    CheckBox cb = dataGrid_Info.Columns[0].GetCellContent(dataGrid_Info.Items[z]) as CheckBox;
            //    cb.IsChecked = true;
            //}
            int index = dataGrid_Info.SelectedIndex;//获取选中的行号
            if (index == -1)
            {
                list_selection.Clear();
                ShowTest();
                return;
            }
            //判断当前时多选模式还是单选模式
            if (choose_model == 1)
            {
                //判断当前行是否已经勾选
                CheckBox cb_single;
                cb_single = dataGrid_Info.Columns[0].GetCellContent(dataGrid_Info.Items[index]) as CheckBox;
                if (cb_single.IsChecked == true) return;
                //表示为单选状态，清除记录的所有选项
                CheckBoxStatusRemove();
                list_selection.Clear();
                list_selection.Add(index);
            }
            else
            {
                //多选状态，不清除
                list_selection.Add(index);
                UpdateMultilineSelection();
            }
            CheckBox cb = dataGrid_Info.Columns[0].GetCellContent(dataGrid_Info.Items[index]) as CheckBox;
            cb.IsChecked = true;
            ShowTest();//显示选中索引
        }

        /// <summary>
        /// TreeView的节点展开触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Dir_Expanded(object sender, RoutedEventArgs e)
        {
            PropertyNodeItem node5 = new PropertyNodeItem()
            {
                DisplayName = "Tag No.5",
                Name = "测试用无效节点"
            };
            TreeViewItem treeitem = e.OriginalSource as TreeViewItem;
            PropertyNodeItem pro = treeitem.DataContext as PropertyNodeItem;
            if (pro.Name == "我的电脑") return;//如果是根节点则退出
            pro.Children.Clear();//清空子节点，强制重刷新（耗时）
            //提取出当前路径
            string path = pro.Name;
            //获取当前目录下的所有子目录的文件名称
            List<string> list_tree_dir = new FileOperations().GetCurrentDirectoryOnDirname(path);
            if (list_tree_dir != null)
            {
                foreach (string strdir in list_tree_dir)
                {
                    PropertyNodeItem nodedir = new PropertyNodeItem()
                    {
                        Icon=str_icon_path+"folder.png",
                        DisplayName = strdir,
                        Name = path + strdir + "\\",
                        isDir = true
                    };
                    nodedir.Children.Add(node5);//给子目录添加一个无效节点，在打开目录时删除该节点
                    pro.Children.Add(nodedir);
                }
            }
            //获取当前目录下的所有文件的名名称
            string[] str_tmp;
            string str_tmp_icon_name = "";
            int index = -1;
            List<string> list_tree_file = new FileOperations().GetCurrentDirectoryOnFilename(path);
            if (list_tree_file != null)
            {
                foreach (string strdir in list_tree_file)
                {
                    str_tmp_icon_name = "_blank.png";
                    str_tmp = strdir.Split('.');
                    //判断是否有后缀,用'.'拆分出的数组元素为两个就证明有后缀
                    if (str_tmp.Count() > 1)
                    {

                        index = str_tmp.Count() - 1;//始终将拆分出最后一个字符串作为类型
                        //获取文件类型对应图标路径
                        if (Icon_path.ContainsKey(str_tmp[index].ToLower()))//判断是否存在相应的键
                        {
                            str_tmp_icon_name = Icon_path[str_tmp[index]];
                        }
                    }
                    str_tmp = null;
                    PropertyNodeItem nodedir = new PropertyNodeItem()
                    {
                        Icon = str_icon_path + str_tmp_icon_name,
                        DisplayName = strdir,
                        Name = path + strdir,
                        isDir = false
                    };
                    pro.Children.Add(nodedir);
                }
            }
        }

        /// <summary>
        /// TreeView的鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Dir_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //判断是否选中
            if (treeView_Dir.SelectedItem == null) return;
            PropertyNodeItem pro = treeView_Dir.SelectedItem as PropertyNodeItem;
            //判断是否为文件,是文件则打开文件
            if(pro.isDir == false)
            {
                System.Diagnostics.Process.Start(pro.Name);
                return;
            }
            //如果双击的“我的电脑”,不操作
            if (pro.Name == "我的电脑") return;
            GetChildDirectory(pro.Name);
        }
        
        /// <summary>
        /// 地址栏换行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Current_Path_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //string str = txt_Current_Path.Text;
            //if(e.Key == Key.Return)
            //{
            //    MessageBox.Show(str);
            //    txt_Current_Path.Text = "xxxx";
            //    return;
            //}
            
        }
    }
}
