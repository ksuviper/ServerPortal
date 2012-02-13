using System.Web.Mvc;

namespace ServerPortal.Controllers {
  public class HomeController : Controller {
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
  }
}
