using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MailingApp.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(MailingApp.Models.MyModel model)
        {
            MailMessage mm = new MailMessage("youremail@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("youremail@gmail.com", "Yourpassword");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail has been sent successfully";
            return RedirectToAction("Index");

        }
    }
}