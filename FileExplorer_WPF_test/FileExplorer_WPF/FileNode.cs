using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer_WPF
{
    /// <summary>
    /// DataGrid区域的信息类
    /// </summary>
    class FileNode
    {
        public bool IsSelected { get; set; }//是否选中
        public string FileName { get; set; }//文件名称
        public string FileDate { get; set; }//文件日期
        public string FileType { get; set; }//文件类型
        public string FileSize { get; set; }//文件大小
        public string IconPath { get; set; }//图标路径
        public FileNode(bool isselect,string filename,string filedate,string filetype,string filesize,string iconpath)
        {
            this.IsSelected = isselect;
            this.FileName = filename;
            this.FileDate = filedate;
            this.FileType = filetype;
            this.FileSize = filesize;
            this.IconPath = iconpath;
        }
    }
}
