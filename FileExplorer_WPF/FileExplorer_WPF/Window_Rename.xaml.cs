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

namespace FileExplorer_WPF
{
    /// <summary>
    /// Window_Rename.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Rename : Window
    {
        string str_dir,str_name;
        char[] symbol_arr = { '/', '\\', ':', '*', '?', '<', '>', '|' };
        bool judge = false;//判断是否找到了违规字符
        public Window_Rename(string dir,string name)
        {
            ResizeMode = System.Windows.ResizeMode.NoResize;//设置窗口不能调整大小
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            str_dir = dir;
            str_name = name;
            Window_Load();
            //文字加载完了再绑定内容改变事件
            textBox_name.TextChanged += TextBox_name_TextChanged;
        }
        /// <summary>
        /// 界面数据初始化
        /// </summary>
        public void Window_Load()
        {
            textBox_name.Text = str_name;
            label_symbol.Content = "/ \\ : * ? '' < > |";
        }


        /// <summary>
        /// 当文本框内的内容改变时的触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = textBox_name.Text;
            judge=false;
            if (str == "") return;
            foreach (char ch_name in str)
            {
                foreach (char ch in symbol_arr)
                {
                    if (ch_name == 34 || ch_name == ch)
                    {
                        judge = true;
                        break;
                    }
                }
                if (judge) break;
            }
            //如果有非法字符则警告
            if (judge)
            {
                this.label.Foreground = new SolidColorBrush(Colors.Red);
                this.label_symbol.Foreground = new SolidColorBrush(Colors.Red);
                Console.Beep();
            }
            else
            {
                this.label.Foreground = new SolidColorBrush(Colors.Black);
                this.label_symbol.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        /// <summary>
        /// 点击确定的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_yes_Click(object sender, RoutedEventArgs e)
        {
            //  不允许出现 /\:*?"<>|
            string newname = textBox_name.Text;
            if (judge)
            {
                Console.Beep();
                return;
            }
            //如果名称没变，直接退出
            if (newname == str_name)
            {
                this.Close();
                return;
            } 
            try
            {
                if (Directory.Exists(str_dir + str_name))
                {
                    //如果是文件夹
                    Directory.Move(str_dir + str_name, str_dir + newname);
                }
                else if (File.Exists(str_dir + str_name))
                {
                    //如果是文件
                    File.Move(str_dir + str_name, str_dir + newname);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

    }
}
