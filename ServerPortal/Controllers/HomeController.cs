using System.IO;
using System.Web;
using System.Web.Mvc;
using ServerPortal.Models;
using FileDownloadInMvc3.Models;

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

        try
        {
            var fileData = FileDownloadInMvc3.Models.ExtensionMethods.GetFileData(file.Name, file.Path);
            return new FileDownloadResult(file.Name, fileData);
        }
        catch (FileNotFoundException)
        {
            throw new HttpException(404, string.Format("The file {0} was not found.", file));
        }                
        //return View(DL);
    }

    public ActionResult History()
    {
        var Downloads = new Models.History(true);
        
        return View(Downloads);
    }
  }
}
