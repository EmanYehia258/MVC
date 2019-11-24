using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LasttaskMVC.Models;
namespace LasttaskMVC.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities2 db = new NorthwindEntities2();
        // GET: Home
        public ActionResult Index()
        {
          var list=  db.Products.ToList();
            return View(list);
        }
        public ActionResult insrt()
        {
            return View();
        }
        
        public ActionResult insert(User u)
        {
         
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pasword)
        {
            if (email == "admin@gmail.com" && pasword == "admin")
            {
                return RedirectToAction("admin");
            }
            else
            {
                try
                {
                    int id = db.Users.Where(a => a.email == email).ToList().FirstOrDefault().ID;
                    int idd = db.Users.Where(u => u.password == pasword).ToList().FirstOrDefault().ID;
                    if (id >= 0 && idd >= 0 && id == idd)
                    {
                        string name = db.Users.Where(a => a.ID == id).ToList().FirstOrDefault().name;
                        TempData["name"] = name;
                        return RedirectToAction("welcome");

                    }
                    else
                    {
                        return RedirectToAction("error");
                    }
                }
                catch (Exception e)
                {
                    return RedirectToAction("error");
                }
            }
            
        }
        public ActionResult welcome()
        {
            return View();
        }
        public ActionResult error()
        {
            return View();
        }
   
        public ActionResult admin()
        {
            return View();
        }

    }
}