using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        acsm_428eb2529de1454Entities db = new acsm_428eb2529de1454Entities();
        List<menu> OP_var;
        public void Add_items(Items parent)
        {
            do
            {
                var Category_item = OP_var.Find(x => x.CategoryName == parent.name);
                if (Category_item.IsCatecory == true)
                {
                    ((Category)parent).Add(new Category(Category_item));
                    OP_var.Remove(Category_item);
                    var Child_items = OP_var.Find(x => x.CategoryName == Category_item.Name);
                    Add_items(((Category)parent).Get(Category_item.Name));
                }
                else
                {
                    ((Category)parent).Add(new Item_category(Category_item));
                    OP_var.Remove(Category_item);
                }


            } while (OP_var.Find(x => x.CategoryName == parent.name) != null);


        }
        public void main_name()
        {
            if (Session["Name"] == null)
                Session["Name"] = db.restaurantdata.First().Name;
        }

        public Category Action_method(string name)
        {
            main_name();
            Category Temp_items = new Category(name);
            var temp_var = from a in db.menu where a.Group == name select a;
            OP_var = temp_var.ToList();

            for (int i = 0; i < OP_var.Count; i++)
            {
                byte[] Ret = OP_var[i].Image;
                System.Drawing.Image temp;
                if (Ret != null)
                {
                    try
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Ret))
                        {
                            temp = System.Drawing.Image.FromStream(ms);
                            string path = HttpContext.Server.MapPath("~/Temp_img").ToString() + "\\" + OP_var[i].ID + ".jpg";
                            temp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }
                    catch (Exception) { throw; }
                }
            }


            do
            {
                if (OP_var.Find(x => x.IsCatecory == true) != null)
                {
                    var temp_obj = OP_var.Find(x => (x.IsCatecory == true && x.CategoryName == null));
                    Temp_items.Add(new Category(temp_obj));
                    OP_var.Remove(temp_obj);
                    Add_items(Temp_items.Get(temp_obj.Name));

                }
                else
                {
                    Temp_items.Add(new Item_category(OP_var[0]));
                    OP_var.Remove(OP_var[0]);
                }
            } while (OP_var.Count != 0);
            return Temp_items;

        }
        public ActionResult Index()
        {
            main_name();
           
            return View();
        }
        public ActionResult Food()
        {
            return View(Action_method("Food"));
        }

        public ActionResult Drink()
        {
            return View(Action_method("Drink"));
        }


        public ActionResult Desert()
        {
            return View(Action_method("Desert"));
        }
    }
}