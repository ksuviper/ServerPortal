using System;
using System.IO;

namespace ServerPortal.Models {
  public class File {
    public File() { }
    public File(string path) : this(new FileInfo(path)) { }
    public File(FileInfo fileInfo) {
      Name = fileInfo.Name;
      Path = fileInfo.DirectoryName;
      DlPath = fileInfo.FullName;
      Size = fileInfo.Length;
      DateMod = fileInfo.LastWriteTime;
      DateCreated = fileInfo.CreationTime;
    }

    public string Name { get; set; }
    public string Path { get; set; }
    public string DlPath { get; set; }
    public long Size { get; set; }
    public DateTime DateMod { get; set; }
    public DateTime DateCreated { get; set; }
  }
}