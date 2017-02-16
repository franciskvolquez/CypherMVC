using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CypherMVC.Models;

namespace CypherMVC.Controllers
{
    public class TaskController : Controller
    {
      
        public ActionResult ViewAll()
        {
            return View();
        }

        public ActionResult CreateEdit()
        {
            var list = new List<SelectListItem>()
            {
               new SelectListItem() {Text = "Business Enquiry", Value = "4" },
               new SelectListItem() {Text = "Payment", Value= "1"},
               new SelectListItem() {Text = "UI Issue", Value= "2"},
               new SelectListItem() {Text = "Question", Value= "3"},
            };

            ViewBag.Categories = list;
            return View();
        }
    }
}