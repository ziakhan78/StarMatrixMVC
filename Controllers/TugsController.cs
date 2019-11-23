using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarMatrix.Models;

namespace StarMatrix.Controllers
{
    public class TugsController : Controller
    {
        private StarMatrixContext db = new StarMatrixContext();

        // GET: Tugs
        public ActionResult Index()
        {
            return View(db.Tugs.ToList());
        }

        // GET: Tugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tug tug = db.Tugs.Find(id);
            if (tug == null)
            {
                return HttpNotFound();
            }
            return View(tug);
        }

        // GET: Tugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TugId,TugName,BollardPullName,EngineHPName,ClassTypeName")] Tug tug)
        {
            if (ModelState.IsValid)
            {
                db.Tugs.Add(tug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tug);
        }

        // GET: Tugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tug tug = db.Tugs.Find(id);
            if (tug == null)
            {
                return HttpNotFound();
            }
            return View(tug);
        }

        // POST: Tugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TugId,TugName,BollardPullName,EngineHPName,ClassTypeName")] Tug tug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tug);
        }

        // GET: Tugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tug tug = db.Tugs.Find(id);
            if (tug == null)
            {
                return HttpNotFound();
            }
            return View(tug);
        }

        // POST: Tugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tug tug = db.Tugs.Find(id);
            db.Tugs.Remove(tug);
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
