using System.Web.Mvc;
using ServerPortal.Models;

namespace ServerPortal.Controllers {
  public class HomeController : Controller {
    DownloadContext DLTrack = new DownloadContext();
      
    public ActionResult Index() {
      ViewBag.Message = "Welcome the the Server Portal";

      return View();
    }

    public ActionResult About() {
      return View();
    }

    public ActionResult Dir(string DirPath = "c:\\") {
      ViewBag.Message = "Directory Listing for: " + DirPath;

      var dir = new Models.Dir(DirPath, true);
      return View(dir);
    }

    public ActionResult Files(string FilePath) {
      ViewBag.Message = "File Info";

      var file = new Models.File(FilePath);
      return View(file);
    }

    public ActionResult DLFile(string DlPath)
    {
        
        var DL = new Models.Download
        {
            Filename = DlPath,
            DownloadDate = System.DateTime.Now,
            IPAddress = HttpContext.Request.UserHostAddress
        };

        var file = new Models.File(DlPath);

        if (ModelState.IsValid)
        {
            DLTrack.Downloads.Add(DL);
            DLTrack.SaveChanges();
        }

        var contentDisposition = string.Format("attachment; filename={0}", DlPath);
        Response.AddHeader("Content-Disposition", contentDisposition);
        Response.ContentType = "application/force-download";
        Response.Write(DlPath);
        
        return View(DL);
    }

    public ActionResult History()
    {
        var Downloads = new Models.History(true);
        
        return View(Downloads);
    }
  }
}
