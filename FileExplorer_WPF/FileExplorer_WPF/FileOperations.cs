using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileExplorer_WPF
{
    class FileOperations
    {
        public FileOperations()
        {
        }
        //粘贴被选中的所有文件及文件夹List
        public string PasteFileOrDir(List<string> list_source,string target_path, string instruction)
        {
            try
            {
                foreach(string path in list_source)
                {
                    //判断源地址是否为文件夹
                    if (Directory.Exists(path))
                    {
                        string srcflodername = target_path + Path.GetFileName(path);
                        //Directory.CreateDirectory(srcflodername);
                        MoveFile(path, srcflodername);
                        if(instruction == "shear") Directory.Delete(path, true);//如果为剪切，删除该目录下所有文件
                    }
                    else if (File.Exists(path))
                    {
                        string desfilepath = target_path + "\\" + Path.GetFileName(path);
                        File.Copy(path, desfilepath, true);//同文件名覆盖
                        if (instruction == "shear") File.Delete(path);
                    }
                }
                return "成功";
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();//返回异常信息
            }
        }
        
        //粘贴单个文件夹,深度遍历
        public void MoveFile(string srcpath,string despath)
        {
            //判断目标地址是否存在
            if (!Directory.Exists(despath))
            {
                Directory.CreateDirectory(despath);
            }
            //获取源路径下的所有文件
            string[] strfiles_arr = Directory.GetFiles(srcpath);
            foreach(string srcfilepath in strfiles_arr)
            {
                string desfilepath = despath + "\\" + Path.GetFileName(srcfilepath);
                //if (File.Exists(desfilepath)) continue;
                File.Copy(srcfilepath, desfilepath,true);//同文件名覆盖
            }
            //获取源路径下的所有目录(文件夹)
            string[] srcfolder_arr = Directory.GetDirectories(srcpath);
            foreach(string srcfloderpath in srcfolder_arr)
            {
                MoveFile(srcfloderpath, despath + "\\" + Path.GetFileName(srcfloderpath));
            }
            
        }


        //获取当前目录的子目录名字
        public List<string> GetCurrentDirectoryOnDirname(string path)
        {
            try
            {
                List<string> list_info = new List<string>();
                //先找到所有子目录名
                DirectoryInfo dir = new DirectoryInfo(path);
                DirectoryInfo[] dir_arr = dir.GetDirectories();//获取当前目录的子目录
                foreach (DirectoryInfo subDir in dir_arr)
                {
                    list_info.Add(subDir.Name);
                }
                return list_info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //获取当前目录下的文件名
        public List<string> GetCurrentDirectoryOnFilename(string path)
        {
            try
            {
                List<string> list_info = new List<string>();
                //先找到所有子目录名
                DirectoryInfo dir = new DirectoryInfo(path);
                
                //再获取所有文件名
                FileInfo[] file_arr = dir.GetFiles();//获取当前目录的文件
                foreach (FileInfo subFile in file_arr)
                {
                    list_info.Add(subFile.Name);
                }
                return list_info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //获取图标路径键值对
        public static Dictionary<string,string> GetIconPath(string str_path)
        {
            Dictionary<string, string> icon_path = new Dictionary<string, string>();
            //先定位到目录
            DirectoryInfo dir = new DirectoryInfo(str_path);
            FileInfo[] file_arr = dir.GetFiles();//获取当前目录的文件
            string str_type = "";
            int index = 0;
            foreach (FileInfo subFile in file_arr)
            {
                str_type = subFile.Name;
                str_type = str_type.Split('.')[0];
                icon_path.Add(str_type, subFile.Name);
            }
            return icon_path;
        }
    }
}
