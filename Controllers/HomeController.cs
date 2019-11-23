using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using StarMatrix.Models;


namespace StarMatrix.Controllers
{
    public class HomeController : Controller
    {
        private StarMatrixContext db = new StarMatrixContext();
        public ActionResult Index()
        {
            var shipLocations = db.ShipLocations.Include(s => s.Tugs);
            return View(shipLocations.ToList());

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
      

        [Route("Download")]
        public ActionResult Download()
        {
            return View();
        }

        

        [Route("Location-Map")]
        public ActionResult LocationMap()
        {
            return View();
        }


        [Route("Location")]
        public ActionResult Location()
        {
            var shipLocations = db.ShipLocations.Include(s => s.Tugs);
            return View(shipLocations.ToList());
        }




        [Route("Contact")]
        public ActionResult Contact()
        {

            return View();
        }

        [Route("Sitemap")]
        public ActionResult Sitemap()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            //if (this.IsCaptchaValid("Captcha is not valid"))
            //{
            if (ModelState.IsValid)
            {
                // feedback.DateAdded = DateTime.Now;
                // feedback.Ipaddress = GetIpaddress(); ;

                // db.Feedback.Add(feedback);
                // db.SaveChanges();
                SendEmail(feedback);
                return View("Contact");
            }
            //}
            //ViewBag.ErrMessage = "Error: captcha is not valid.";
            return View("Contact");
        }

        [AllowAnonymous]
        [NonAction]
        public void SendEmail(Feedback obj)
        {
            try
            {
                string ReadFileName = "";
                MailMessage mail = new MailMessage();

                mail.To.Add(obj.Email);
                //mail.To.Add("info@finefixengineering.com");
                // mail.To.Add("info@drtanaz.com");
                mail.Bcc.Add("zia@goradiainfotech.com");
                //mail.Bcc.Add("finefixengineering@gmail.com");
                mail.From = new MailAddress("mail@starmatrixltd.com");
                //mail.Subject = obj.Subject;               

                mail.Subject = "Feedback Enquiry Mail";

                mail.IsBodyHtml = true;
                string PathVal = Server.MapPath("~");

                ReadFileName = PathVal + "/mail/feedback.htm";

                string strMessage = "";
                StreamReader sr1 = new StreamReader(ReadFileName);

                strMessage = sr1.ReadToEnd();

                strMessage = strMessage.Replace("XXXname", obj.Name);
                strMessage = strMessage.Replace("XXXmobile", obj.Mobile);
                strMessage = strMessage.Replace("XXXemail", obj.Email);
                strMessage = strMessage.Replace("XXXmessage", obj.Message);

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