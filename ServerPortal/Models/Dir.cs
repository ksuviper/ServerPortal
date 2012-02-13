using System.Collections.Generic;
using System.IO;

namespace ServerPortal.Models {

  public class Dir {
    public string Name { get; set; }
    public string Path { get; set; }
    public long Size { get; set; }

    public List<Dir> Directories { get; set; }
    public List<File> Files { get; set; }

    public Dir() {
      Directories = new List<Dir>();
      Files = new List<File>();
    }

    public Dir(string path, bool initializeChildren = false)
      : this(new DirectoryInfo(path), initializeChildren) { }

    public Dir(DirectoryInfo info, bool initializeChildren = false)
      : this() {
      Name = info.Name;
      Path = info.FullName;

      if (initializeChildren) {
        foreach (var item in info.GetDirectories()) {
          Directories.Add(new Dir(item, false));

        }

        foreach (var item in info.GetFiles()) {
          Files.Add(new File(item));
        }
      }
    }
  }
}