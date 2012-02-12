using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerPortal.Models;

namespace ServerPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome the the Server Portal";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        private static Media _DirList = new Media();
        public ActionResult Media(string DirPath = "c:\\")
        {
            ViewBag.Message = "File Listing for: " + DirPath;

            _DirList.getDirList(DirPath);
            return View(_DirList._MediaList);
        }
    }
}
