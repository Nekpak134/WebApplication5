using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.dbcontext;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        officeEntities db = new officeEntities();
        public ActionResult Index()
        {
           var result= db.employees.ToList();
            List<empmodel> e = new List<empmodel>();
            foreach (var item in result)
            {
                e.Add(new empmodel { id = item.id, Name = item.Name, password = item.password, RollNo = item.RollNo, email = item.email });
            }
            return View(e);
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
        public ActionResult delete(int? id)
        {
            var delete = db.employees.Where(m => m.id == id).First();
            db.employees.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult details(int? id)
        {
            var details = db.employees.Where(x => x.id == id).First();
            empmodel m = new empmodel();
            m.id = details.id;
            m.Name = details.Name;
            m.password = details.password;
            m.RollNo = details.RollNo;
            m.email = details.email;
            return View(m);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(empmodel e)
        {
            employee p = new employee();
            p.id = e.id;
            p.Name = e.Name;
            p.RollNo = e.RollNo;
            p.email = e.email;
            p.password = e.password;
           
            if(e.id==0)
            {
                db.employees.Add(p);
                db.SaveChanges();
            }
            else
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult edit(int? id)
        {
            var e = db.employees.Where(m => m.id == id).First();
            empmodel p = new empmodel();
            p.id = e.id;
            p.Name = e.Name;
            p.RollNo = e.RollNo;
            p.email = e.email;
            p.password = e.password;
            ViewBag.edit = "edit";
            return View("create", p);
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(namemodel n)
        {
            var l = db.names.Where(m => m.username == n.username).FirstOrDefault();
            if(l==null)
            {
                TempData["username"] = "username is invalid";
            }
            else
            {
                if(l.username==n.username && l.userpassword==n.userpassword)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["password"] = "password is wrong";
                }
            }
            return View();
        }
    }
}