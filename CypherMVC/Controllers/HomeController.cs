using CypherMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Survey()
        {
            var context = new FeedbackContext();
            var admins = context.Admins.OrderByDescending(x => x.Votes.Count).ToList();

            if(Session["HasVoted"] != null)
            {
                return PartialView("SurveyResults", admins);
            }

            return PartialView(admins);
        }

        [HttpPost]
        public ActionResult Survey(int adminId)
        {
            var context = new FeedbackContext();
            context.Votes.Add(new Vote() { AdminId = adminId });
            context.SaveChanges();

            Session["HasVoted"] = true;

            return RedirectToAction("Index");
        }

        public ActionResult Suggestion()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult Suggestion(string suggestion)
        {
            //Send email, return true or false for success 
            var emailSent = true;

            return PartialView("SuggestionResult", emailSent);
        }
    }
}