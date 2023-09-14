
using Library_management_project.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Library_Management.Controllers
{
    public class HomeController : Controller
    {
        LibraryEntities3 db = new LibraryEntities3();



        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";



            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Member()
        {
            return View();
        }





        [HttpGet]
        public ActionResult Login()
        {
            var l1 = db.Members.Select(x => x.Role).Distinct().OrderBy(y => y);
            ViewBag.Roles = new SelectList(l1.ToList());
            return View();
        }



        [HttpPost]
        public ActionResult Login(FormCollection f1)
        {
            var l1 = db.Members.Select(x => x.Role).Distinct().OrderBy(y => y);
            ViewBag.Roles = new SelectList(l1.ToList());



            string s1 = Request["t1"];
            string s2 = Request["t2"];
            string s3 = Request["Roles"];



            var temp = db.Members.FirstOrDefault(X => X.Email == s1 && X.Password == s2 && X.Role == s3);
            if (temp != null)
            {



                if (temp.Role == "Admin")
                    return RedirectToAction("Admin", "Home");
                else
                    return RedirectToAction("Member", "Home");

            }
            else



                return Content("<script language='javascript' type='text/javascript'>alert('Login Failed Please Enter the Correct Username or Password or Role!');</script>");
        }





    }
}
