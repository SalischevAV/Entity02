using Entity02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity02.Controllers
{
    public class HobbyController : Controller
    {
        private PeopleContext db = new PeopleContext();
        // GET: Hobby
        public ActionResult Index()
        {
            return View(db.Hobbyes.Include(h => h.Workers).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Workers = db.Workers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hobby sameHobby, int[] selectedWorkers)
        {
            if (selectedWorkers != null)
            {
                sameHobby.Workers = new List<Worker>();
                var workers = db.Workers.Where(w => selectedWorkers.Contains(w.Id));
                foreach(var item in workers)
                {
                    sameHobby.Workers.Add(item);
                }
            }
            db.Hobbyes.Add(sameHobby);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Workers = db.Workers.ToList();
            if (id == null)
            {
                return HttpNotFound();
            }
            Hobby sameHobby = db.Hobbyes.Find(id);
            if(sameHobby == null)
            {
                return HttpNotFound();
            }            
            return View(sameHobby);
        }

        [HttpPost]
        public ActionResult Edit (Hobby sameHobby, int[] selectedWorkers)
        {
            Hobby updatedHobby = db.Hobbyes.Find(sameHobby.Id);
            updatedHobby.HobbyName = sameHobby.HobbyName;
            updatedHobby.Workers.Clear();

            if(selectedWorkers != null)
            {
                var workers = db.Workers.Where(w => selectedWorkers.Contains(w.Id));
                foreach (var item in workers)
                {
                    updatedHobby.Workers.Add(item);
                }
            }
            db.Entry(updatedHobby).State = EntityState.Modified;
            db.SaveChanges();           

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Hobby sameHobby = db.Hobbyes.Find(id);
            if(sameHobby == null)
            {
                return HttpNotFound();
            }

            return View(sameHobby);
        }

        [HttpPost]
        public ActionResult Delete(Hobby sameHobby)
        {
            db.Entry(sameHobby).State = EntityState.Deleted;
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
