using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ServerPortal.Models
{
    public class DirInfo
    {
        public String Name { get; set; }
        public String Path { get; set; }
        public Boolean isFolder { get; set; }
        public String Size { get; set; }
    }

    public class Dir
    {
        public List<DirInfo> _DirList = new List<DirInfo>();
        public void getDirList(string CurPath)
        {
            _DirList.Clear();

            string[] Dirs = Directory.GetDirectories(CurPath);
            foreach (string Item in Dirs)
            {
                _DirList.Add(new DirInfo
                {
                    Name = new DirectoryInfo(Item).Name,
                    isFolder = true,
                    Path = Path.GetFullPath(Item),
                    Size = ""
                });
                
            }
            string[] Files = Directory.GetFiles(CurPath);
            foreach (string Item in Files)
            {
                _DirList.Add(new DirInfo
                {
                    Name = Path.GetFileName(Item),
                    isFolder = false,
                    Path = Path.GetFullPath(Item),
                    Size = (new FileInfo(Item).Length / 1024).ToString()
                });
            }
               
        }
    }
}