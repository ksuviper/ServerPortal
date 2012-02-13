using System;

namespace ServerPortal.Models {
  public static class Extensions {

    static readonly string[] _FormatSize = { "B", "KB", "MB", "GB", "TB", "XB" };
    public static string FormatSize(this long sz) {
      double nsz = sz;
      for (int i = 0; i <= _FormatSize.Length - 1; i++) {
        nsz /= i == 0 ? 1 : i > 1 ? 1000 : 1024;
        if (nsz < 1024 || i == _FormatSize.Length - 1) {
          return Math.Round(nsz, 1) + " " + _FormatSize[i];
        }
      }
      return "0 B";
    }

  }
}