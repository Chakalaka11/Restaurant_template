using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {
        acsm_428eb2529de1454Entities db = new acsm_428eb2529de1454Entities();
        public void main_name()
        {
            if(Session["Name"] == null)
                Session["Name"] = db.restaurantdata.First().Name;
        }
        // GET: Home
       
        public ActionResult Index()
        {
            main_name();
            //System.Drawing.Image temp_save = System.Drawing.Bitmap.FromFile(HttpContext.Server.MapPath("~/App_Data/demo.jpeg"));
            //byte[] Ret;
            //try
            //{
            //    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            //    {
            //        temp_save.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        Ret = ms.ToArray();
            //    }
            //    db.menu.Find(1).Image = Ret;
            //    db.SaveChanges();
            //}
            //catch (Exception) { }

            return View();
        }
        public ActionResult About()
        {
            main_name();
            //System.Drawing.Image temp_save = System.Drawing.Bitmap.FromFile(HttpContext.Server.MapPath("~/App_Data/demo.jpeg"));
            //byte[] Ret;
            //try
            //{
            //    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            //    {
            //        temp_save.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        Ret = ms.ToArray();
            //    }
            //    db.menu.Find(1).Image = Ret;
            //    db.SaveChanges();
            //}
            //catch (Exception) { }
            string[] parser = { "(parser)" };
            string temp = db.restaurantdata.First().About;
            string[] About_text = temp.Split(parser, StringSplitOptions.RemoveEmptyEntries);
            return View(About_text);
        }
        public ActionResult Contacts()
        {
            main_name();
            string[] location_data = {
                db.restaurantdata.First().STLocation,
                db.restaurantdata.First().MapLocation,
                db.restaurantdata.First().WorkTime,
                db.restaurantdata.First().Email_telephone
            };
            return View(location_data);
        }
    }
}