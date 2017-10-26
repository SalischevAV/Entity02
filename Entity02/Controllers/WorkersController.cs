using Entity02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Entity02.Controllers
{
    public class WorkersController : Controller
    {
        private PeopleContext db = new PeopleContext();
        // GET: Workers
        public ActionResult Index()
        {
            var workersList = db.Workers.Include(w => w.Company).Include(w => w.Hobbyes);
            return View(workersList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Hobbyes = db.Hobbyes.ToList();
            ViewBag.Companyes = new SelectList(db.Companyes, "Id", "CompanyName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Worker john, int[] selectedHobbyes)
        {
            if(selectedHobbyes != null)
            {
                john.Hobbyes = new List<Hobby>();
                var hobbyes = db.Hobbyes.Where(h => selectedHobbyes.Contains(h.Id));
                foreach (var item in hobbyes)
                {
                    john.Hobbyes.Add(item);
                }
            }

            db.Entry(john).State = EntityState.Added;
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
            Worker john = db.Workers.Find(id);
            if (john == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hobbyes = db.Hobbyes.ToList();
            ViewBag.Companyes = new SelectList(db.Companyes, "Id", "CompanyName");
            return View(john);
        }

        [HttpPost]
        public ActionResult Edit(Worker john, int[] selectedHobbyes)
        {
            Worker updatetdWorker = db.Workers.Find(john.Id);
            updatetdWorker.Name = john.Name;
            updatetdWorker.Surname = john.Surname;
            updatetdWorker.CompanyId = john.CompanyId;
            updatetdWorker.Hobbyes.Clear();

            if(selectedHobbyes != null)
            {
                var hobbyes = db.Hobbyes.Where(h => selectedHobbyes.Contains(h.Id));
                foreach (var item in hobbyes)
                {
                    updatetdWorker.Hobbyes.Add(item);
                }
            }

            db.Entry(updatetdWorker).State = EntityState.Modified;
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

            Worker john = db.Workers.Find(id);

            if (john == null)
            {
                return HttpNotFound();
            }
            return View(john);
        }

        [HttpPost]
        public ActionResult Delete(Worker john)
        {
            db.Entry(john).State = EntityState.Deleted;
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