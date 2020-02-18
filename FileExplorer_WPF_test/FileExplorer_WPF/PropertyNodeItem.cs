using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer_WPF
{
    class PropertyNodeItem
    {
        public string Icon { get; set; }//图标地址
        public string DisplayName { get; set; }//文件名称
        public string Name { get; set; }//提示路径
        public bool isDir { get; set; }//是否为目录
                 
        public ObservableCollection<PropertyNodeItem> Children { get; set; }//子目录
        public PropertyNodeItem()
        {
            Children = new ObservableCollection<PropertyNodeItem>();
        }
}
}

/*
 <TreeView.Resources>
                <Style TargetType="TreeViewItem">
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="#CCE8FF"></Setter>
                        </Trigger>
                        <Trigger Property="IsExpanded" Value="True">
                            <Setter Property="Background" Value="#CC0033"></Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </TreeView.Resources>
 
private void treeView_Files_Expanded(object sender, RoutedEventArgs e)
    {
        //获取当前节点//treeitem.UpdateLayout();
        TreeViewItem treeitem = e.OriginalSource as TreeViewItem;
        PropertyNodeItem p = treeitem.DataContext as PropertyNodeItem;
        TreeViewItem tv_tmp = new TreeViewItem();
        //判断是否时根目录
        if (treeitem.Header.ToString() == "我的电脑")
        {
            int num = treeitem.Items.Count;
            //把所有的盘符下的根目录都显示
            for (int i = 0; i < num; i++)
            {
                tv_tmp = treeitem.ItemContainerGenerator.Items[i] as TreeViewItem;
                string path = tv_tmp.Header.ToString() + "\\";
                tv_tmp.Items.Add(new TreeViewItem());
            }
        }
        else
        {
            //判断是否有空白目录，有则删除
            for (int i = 0; i < treeitem.Items.Count; i++)
            {
                if ((treeitem.ItemContainerGenerator.Items[i] as TreeViewItem).Header == null)
                {
                    treeitem.Items.RemoveAt(i);
                }
            }

            //添加完整子目录
            //如果已经添加过了就不添加了
            treeitem.Items.Clear();//强制从新添加，耗费时间
            string path = GetTreeItemPath(treeitem);
            List<string> list_tree = new FileOperations().GetTreeViewDirectory(path);
            TreeViewItemAddChildNodes(treeitem, list_tree);
            treeitem.IsExpanded = true;
            int n = treeitem.Items.Count;
            //给每个子节点下添加一个空节点
            for (int i = 0; i < n; i++)
            {
                tv_tmp = treeitem.ItemContainerGenerator.Items[i] as TreeViewItem;
                tv_tmp.Items.Add(new TreeViewItem());
            }
        }
        treeitem.IsExpanded = true;
    }
}
     <!--<Image Source="{Binding Icon}" Width="16" Height="16" Margin="0,0,2,2"/>-->
                            
     */
