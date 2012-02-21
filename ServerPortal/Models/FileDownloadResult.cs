using System;
using System.Web.Mvc;

namespace FileDownloadInMvc3.Models
{
    public class FileDownloadResult : ContentResult
    {
        private string fileName;
        private byte[] fileData;
        public FileDownloadResult(string fileName, byte[] fileData)
        {
            this.fileName = fileName;
            this.fileData = fileData;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if(string.IsNullOrEmpty(this.fileName))
                throw new Exception("A file name is required.");
            if (this.fileData == null)
                throw new Exception("File data is required.");
            var contentDisposition = string.Format("attachment; filename={0}", this.fileName);
            context.HttpContext.Response.AddHeader("Content-Disposition", contentDisposition);
            ContentType = "application/force-download";
            context.HttpContext.Response.BinaryWrite(this.fileData);
        }
    }
}