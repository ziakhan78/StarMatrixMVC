using StarMatrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StarMatrix.Controllers
{
    public class TowageController : Controller
    {
        private StarMatrixContext db = new StarMatrixContext();

        [Route("Towage")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Towage/Present-Fleet")]
        public ActionResult PresentFleet()
        {
            return View();
        }

        [Route("Towage/Live-Location")]
        public ActionResult LiveLocation()
        {
            return View();
        }

        [Route("Towage/Availability")]
        public  ActionResult Availability()
        {
            var shipLocations = db.ShipLocations.Include(s => s.Tugs);
            return View(shipLocations.ToList());
        }

        [Route("Towage/Get-A-Quote")]
        public ActionResult GetAQuote()
        {
            return View();
        }

        [Route("Towage/Jobs-Undertaken")]
        public ActionResult JobsUndertaken()
        {
            return View();
        }
    }
}