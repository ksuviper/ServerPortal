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
        
        private static Dir _DirList = new Dir();
        public ActionResult Dir(string DirPath = "c:\\")
        {
            ViewBag.Message = "Directory Listing for: " + DirPath;

            _DirList.getDirList(DirPath);
            return View(_DirList._DirList);
        }

        private static Files _File = new Files();
        public ActionResult Files(string FilePath)
        {
            ViewBag.Message = "File Info";
            _File.getFileInfo(FilePath);
            return View(_File);
        }
    }
}
