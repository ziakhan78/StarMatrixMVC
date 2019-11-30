using StarMatrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net.Mail;
using System.IO;
using System.Net;

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
        public ActionResult Availability()
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Towage towage)
        {
            if (ModelState.IsValid)
            {
                SendEmail(towage);
                return View("GetAQuote");
            }

            return View("GetAQuote");
        }

        [AllowAnonymous]
        [NonAction]
        public void SendEmail(Towage obj)
        {
            try
            {
                string ReadFileName = "";
                MailMessage mail = new MailMessage();

                //mail.To.Add(obj.Email);
                mail.To.Add("mail@starmatrixltd.com");
                mail.Bcc.Add("zia@goradiainfotech.com");
                //mail.Bcc.Add("finefixengineering@gmail.com");
                mail.From = new MailAddress("mail@starmatrixltd.com");
                //mail.Subject = obj.Subject;               

                mail.Subject = "Towage - Get a Quote";

                mail.IsBodyHtml = true;
                string PathVal = Server.MapPath("~");

                ReadFileName = PathVal + "/mail/Towage_GetAQuote.htm";

                string strMessage = "";
                StreamReader sr1 = new StreamReader(ReadFileName);

                strMessage = sr1.ReadToEnd();

                strMessage = strMessage.Replace("XXXDeparturePort", obj.DeparturePort);
                strMessage = strMessage.Replace("XXXDestinationPort", obj.DestinationPort);
                strMessage = strMessage.Replace("XXXEstimatedDisplacement", obj.EstimatedDisplacement);
                strMessage = strMessage.Replace("XXXTowingDraft", obj.TowingDraft);
                strMessage = strMessage.Replace("XXXDimensions", obj.Dimensions);
                strMessage = strMessage.Replace("XXXEstimatedLaycan", obj.EstimatedLaycan);
                strMessage = strMessage.Replace("XXXTypeofTow", obj.TypeofTow);
                strMessage = strMessage.Replace("XXXMinimumBPRequirements", obj.MinimumBPRequirements);
                

                mail.Body = strMessage;
                sr1.Close();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Credentials = new NetworkCredential("mail@starmatrixltd.com", "d&m3#BR8");
                emailClient.Port = 587;
                emailClient.Host = "smtp.gmail.com";
                emailClient.EnableSsl = true;
                emailClient.Send(mail);

                ModelState.Clear();
                ViewBag.Message = "Your enquiry has been submitted successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.ErrMessage = "Problem while sending email, Please check details.";
            }

        }
    }
}