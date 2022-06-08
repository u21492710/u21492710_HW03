using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Media_Upload_System.Models;

namespace Media_Upload_System.Controllers
{
    public class FileDownloadController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
        
            string[] filePaths = Directory.GetFiles(Server.MapPath("/Media/Documents"));
           // string[] filePaths1 = Directory.GetFiles(Server.MapPath("/Media/Images"));
           // string[] filePaths2 = Directory.GetFiles(Server.MapPath("/Media/Videos"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath),filepath = "Documents" });
            }
            //foreach (string filePath in filePaths1)
            //{
              //  files.Add(new FileModel { FileName = Path.GetFileName(filePath), filepath = "Images" });
               // }
           // foreach (string filePath in filePaths2)
            //{
               // files.Add(new FileModel { FileName = Path.GetFileName(filePath), filepath = "Videos" });
               // }
            return View(files);
        }

        public FileResult DownloadFile(string fileName, string filePath1)
        {



            string path = Server.MapPath("~/Media/") + filePath1 + "/" + fileName;


            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName, string filePath2)
        {
   
            string path = Server.MapPath("~/Media/") + filePath2 + "/" + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}