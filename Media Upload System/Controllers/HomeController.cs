using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Media_Upload_System.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string Type) //, FormCollection frm)
        {
            try
            {
                if (file!= null && file.ContentLength>0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(Server.MapPath("/Media/" + Type), filename);
                    file.SaveAs(filepath);
                }
                ViewBag.message = "Uploaded file, saved successfully in a folder! "+Type;
          
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.message = "Uploaded file NOT saved in a folder! " + Type;
                return RedirectToAction("Index");
            }
            

        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}