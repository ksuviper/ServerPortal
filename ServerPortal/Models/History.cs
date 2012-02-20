using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerPortal.Models
{
    public class History
    {
        DownloadContext DLTrack = new DownloadContext();

        public string Name { get; set; }
        public int DLCnt { get; set; }

        public List<History> Downloads { get; set; }

        public History() 
        {
            Downloads = new List<History>();
        }

        public History(bool initializeChildren = false)
        : this() {            
            if (initializeChildren)
            {
                //var DLHist = from d in DLTrack.Downloads
                //             select d;
                var DlHist = from dl in DLTrack.Downloads
                             where dl.Filename != ""
                             group dl by dl.Filename
                             into grp
                             select new
                             {
                                 fName = grp.Key,
                                 Count = grp.Select(x => x.Filename).Count()
                             };
                
                foreach (var row in DlHist.ToList())
                {
                    History HistItem = new History();
                    HistItem.Name = row.fName;
                    HistItem.DLCnt = row.Count;
                    Downloads.Add(HistItem);

                }
            }
        }
      
    }
}