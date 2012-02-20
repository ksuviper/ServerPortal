using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ServerPortal.Models
{
    public class Download
    {
        public int DownloadID { get; set; }
        public string Filename { get; set; }
        public DateTime DownloadDate { get; set; }
        public string IPAddress { get; set; }

    }
}