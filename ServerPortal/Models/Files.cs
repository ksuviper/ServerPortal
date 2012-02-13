using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ServerPortal.Models
{
    public class FiInfo
    {
        public String Name { get; set; }
        public String Path { get; set; }
        public String Size { get; set; }
        public String DateMod { get; set; }
        public String DateCreated { get; set; }
    }
    
    public class Files
    {
        public FiInfo fInfo = new FiInfo();
        public void getFileInfo(String FilePath)
        {
            fInfo.Name = new FileInfo(FilePath).Name;
            fInfo.Path = new FileInfo(FilePath).DirectoryName;
            fInfo.Size = (new FileInfo(FilePath).Length / 1024).ToString();
            fInfo.DateMod = new FileInfo(FilePath).LastWriteTime.ToString();
            fInfo.DateCreated = new FileInfo(FilePath).CreationTime.ToString();
        }
    }
}