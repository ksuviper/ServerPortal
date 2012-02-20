using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ServerPortal.Models
{
    public class DownloadContext : DbContext
    {
        public DbSet<Download> Downloads { get; set; }
    }
}