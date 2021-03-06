﻿using CypherMVC.Models;
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
            var context = new FeedbackContext();

            var dash = new DashBoardVM()
            {
                Messages = context.Threads
                    .SelectMany(x => x.Messages).OrderByDescending(c => c.Created).ToList()
                    .GroupBy(y => y.MessageThreadId).Select(grp => grp.FirstOrDefault()).ToList().Take(5),
                Tasks = context.Tasks.OrderByDescending(x => x.Created).Take(5)
            };

            return View(dash);
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

            var admins = context.Admins.OrderByDescending(x => x.Votes.Count).ToList();

            Session["HasVoted"] = true;

            return PartialView("SurveyResults", admins);
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