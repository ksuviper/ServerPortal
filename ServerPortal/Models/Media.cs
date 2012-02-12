using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ServerPortal.Models
{
    public class MediaInfo
    {
        public String FileName { get; set; }
        public String Path { get; set; }
        public Boolean isFolder { get; set; }
        public String Size { get; set; }
    }

    public class Media
    {
        public List<MediaInfo> _MediaList = new List<MediaInfo>();
        public void getDirList(string CurPath)
        {            
            _MediaList.Clear();

            string[] Dirs = Directory.GetDirectories(CurPath);
            foreach (string Item in Dirs)
            {
                _MediaList.Add(new MediaInfo
                {
                    FileName = new DirectoryInfo(Item).Name,
                    isFolder = true,
                    Path = Path.GetFullPath(Item),
                    Size = ""
                });
                
            }
            string[] Files = Directory.GetFiles(CurPath);
            foreach (string Item in Files)
            {
                _MediaList.Add(new MediaInfo
                {
                    FileName = Path.GetFileName(Item),
                    isFolder = false,
                    Path = Path.GetFullPath(Item),
                    Size = new FileInfo(Item).Length.ToString()
                });
            }
               
        }
    }
}