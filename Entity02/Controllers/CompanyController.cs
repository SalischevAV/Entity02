using Entity02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity02.Controllers
{
    public class CompanyController : Controller
    {
        private PeopleContext db = new PeopleContext();
        // GET: Company
        public ActionResult Index()
        {
            return View(db.Companyes.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company sameCompany)
        {
            db.Entry(sameCompany).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Company sameCompany = db.Companyes.Find(id);
            if (sameCompany == null)
            {
                return HttpNotFound();
            }
            return View(sameCompany);
        }

        [HttpPost]
        public ActionResult Edit (Company sameCompany)
        {
            db.Entry(sameCompany).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete (int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Company sameCompany = db.Companyes.Find(id);
            if(sameCompany == null)
            {
                return HttpNotFound();
            }
            return View(sameCompany);
        }

        [HttpPost]
        public ActionResult Delete (int id)
        {
            Company deletedCompany = db.Companyes.Find(id);
            db.Companyes.Remove(deletedCompany);
           // db.Entry(sameCompany).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}