using CypherMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherMVC.Controllers
{
    public class MessagesController : Controller
    {
        private FeedbackContext _context;

        public MessagesController(FeedbackContext context)
        {
            _context = context;
        }

        public ActionResult ViewAll()
        {
            var messagges = _context.Threads
                .SelectMany(x => x.Messages).OrderByDescending(c => c.Created).ToList()
                .GroupBy(y => y.MessageThreadId).Select(grp => grp.FirstOrDefault()).ToList();
                

            return View(messagges);
        }

        public ActionResult Reply(int id)
        {          
            var thread = _context.Threads.First(x => x.MessageThreadId == id)
                .Messages.OrderBy(x => x.Created).ToList();

            if(thread != null)
            {
                ReplyVM vm = new ReplyVM()
                {
                    Messages = thread,
                    Subject = thread.FirstOrDefault().Subject,
                    MessageThreadId = id
                };

                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Reply(int id, string content)
        {
            var thread = _context.Threads.FirstOrDefault(x => x.MessageThreadId == id);        

            if (thread != null)
            {
                var newMsg = new Message();
                newMsg.Subject = thread.Messages.First().Subject;
                newMsg.Created = DateTime.Now;
                newMsg.Content = content;
                newMsg.MessageThreadId = id;
                var index = HttpContext.User.Identity.Name.IndexOf("\\") + 1;
                newMsg.Author = HttpContext.User.Identity.Name.Substring(index);

                _context.Messages.Add(newMsg);
                _context.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
    }
}