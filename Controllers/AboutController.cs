using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarMatrix.Controllers
{
    public class AboutController : Controller
    {
        [Route("About")]
        public ActionResult Index()
        {
            return View();
        }

        //[Route("About-Star-Matrix")]
        //public IActionResult About()
        //{
        //    return View();
        //}


        [Route("About/Demolition-Recycling")]
        public ActionResult DemolitionRecycling()
        {
            return View();
        }

        [Route("About/Towage")]
        public ActionResult Towage()
        {
            return View();
        }

    }
}