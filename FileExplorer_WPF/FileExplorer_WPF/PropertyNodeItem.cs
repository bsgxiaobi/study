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
