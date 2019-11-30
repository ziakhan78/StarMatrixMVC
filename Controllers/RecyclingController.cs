using StarMatrix.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recycling recycling)
        {
            if (ModelState.IsValid)
            {
                SendEmail(recycling);
                return View("GetAQuote");
            }

            return View("GetAQuote");
        }

        [AllowAnonymous]
        [NonAction]
        public void SendEmail(Recycling obj)
        {
            try
            {
                string ReadFileName = "";
                MailMessage mail = new MailMessage();

               // mail.To.Add(obj.Email);
                mail.To.Add("mail@starmatrixltd.com");
                
                mail.Bcc.Add("zia@goradiainfotech.com");
                //mail.Bcc.Add("finefixengineering@gmail.com");
                mail.From = new MailAddress("mail@starmatrixltd.com");
                //mail.Subject = obj.Subject;               

                mail.Subject = "Recycling - Get a Quote";

                mail.IsBodyHtml = true;
                string PathVal = Server.MapPath("~");

                ReadFileName = PathVal + "/mail/Recycling_GetAQuote.htm";

                string strMessage = "";
                StreamReader sr1 = new StreamReader(ReadFileName);

                strMessage = sr1.ReadToEnd();

                strMessage = strMessage.Replace("XXXTypeofUnit", obj.Typeofunit);
                strMessage = strMessage.Replace("XXXEstimatedLigthship", obj.EstimatedLigthship);
                strMessage = strMessage.Replace("XXXLocation", obj.Location);
                strMessage = strMessage.Replace("XXXLaidUp", obj.LaidUp);

                strMessage = strMessage.Replace("XXXStatus", obj.Status);
                strMessage = strMessage.Replace("XXXDeliveryLaycan", obj.DeliveryLaycan);
                strMessage = strMessage.Replace("XXXDimensions", obj.Dimensions);
                strMessage = strMessage.Replace("XXXHKC", obj.HKC);

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