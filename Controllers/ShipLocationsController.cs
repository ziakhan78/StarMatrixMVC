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
    public class ShipLocationsController : Controller
    {
        private StarMatrixContext db = new StarMatrixContext();

        // GET: ShipLocations
        public ActionResult Index()
        {
            var shipLocations = db.ShipLocations.Include(s => s.Tugs);
            return View(shipLocations.ToList());
        }

        // GET: ShipLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipLocation shipLocation = db.ShipLocations.Find(id);
            if (shipLocation == null)
            {
                return HttpNotFound();
            }
            return View(shipLocation);
        }

        // GET: ShipLocations/Create
        public ActionResult Create()
        {
            ViewBag.TugId = new SelectList(db.Tugs, "TugId", "TugName");
            return View();
        }

        // POST: ShipLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipLocation shipLocation)
        {
            if (ModelState.IsValid)
            {
                db.ShipLocations.Add(shipLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TugId = new SelectList(db.Tugs, "TugId", "TugName", shipLocation.TugId);
            return View(shipLocation);
        }

        // GET: ShipLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipLocation shipLocation = db.ShipLocations.Find(id);
            if (shipLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.TugId = new SelectList(db.Tugs, "TugId", "TugName", shipLocation.TugId);
            return View(shipLocation);
        }

        // POST: ShipLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShipLocation shipLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TugId = new SelectList(db.Tugs, "TugId", "TugName", shipLocation.TugId);
            return View(shipLocation);
        }

        // GET: ShipLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipLocation shipLocation = db.ShipLocations.Find(id);
            if (shipLocation == null)
            {
                return HttpNotFound();
            }
            return View(shipLocation);
        }

        // POST: ShipLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipLocation shipLocation = db.ShipLocations.Find(id);
            db.ShipLocations.Remove(shipLocation);
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
