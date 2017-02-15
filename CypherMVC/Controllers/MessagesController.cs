using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherMVC.Controllers
{
    public class MessagesController : Controller
    {
        
        public ActionResult ViewAll()
        {
            return View();
        }

        public ActionResult Reply()
        {
            return View();
        }
    }
}