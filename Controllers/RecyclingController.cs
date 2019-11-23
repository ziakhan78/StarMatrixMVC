using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarMatrix.Controllers
{
    public class RecyclingController : Controller
    {
        [Route("Recycling")]
        public ActionResult Index()
        {
            return View();
        }


        [Route("Recycling/Complex-Jobs-Undertaken")]
        public ActionResult ComplexJobsUndertaken()
        {
            return View();
        }

        [Route("Recycling/One-Stop-Shop")]
        public ActionResult OneStopShop()
        {
            return View();
        }

        [Route("Recycling/Get-A-Quote")]
        public ActionResult GetAQuote()
        {
            return View();
        }

        [Route("Recycling/Location-We-Recycle")]
        public ActionResult LocationWeRecycle()
        {
            return View();
        }

        [Route("Recycling/Green-Recycling")]
        public ActionResult GreenRecycling()
        {
            return View();
        }
    }
}