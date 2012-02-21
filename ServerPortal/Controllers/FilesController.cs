using System.IO;
using System.Web;
using System.Web.Mvc;
using FileDownloadInMvc3.Models;

namespace FileDownloadInMvc3.Controllers
{
    public class FilesController : Controller
    {
        public FileDownloadResult Download(string file)
        {
            try
            {
                var fileData = file.GetFileData(Server.MapPath("~/Content/Files"));
                return new FileDownloadResult(file, fileData);
            }
            catch (FileNotFoundException)
            {
                throw new HttpException(404, string.Format("The file {0} was not found.", file) );
            }
        }
    }
}
