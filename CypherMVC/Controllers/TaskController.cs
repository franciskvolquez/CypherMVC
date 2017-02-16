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

        public ActionResult CreateEdit(int id = 0)
        {
            var context = new FeedbackContext();

            ViewBag.Categories = context.Categories.Select(
                x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            
            if (id != 0)
            {
                return View(context.Tasks.FirstOrDefault(x => x.Id == id));
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateEdit(Task task)
        {
            var context = new FeedbackContext();

            if(ModelState.IsValid)
            {
                var editTask = context.Tasks.FirstOrDefault(x => x.Id == task.Id);
                if (editTask != null)
                {
                    //Updating task 
                    editTask.Title = task.Title;
                    editTask.Description = task.Description;
                    editTask.AssignedToId = task.AssignedToId;
                    editTask.DueDate = task.DueDate;
                    editTask.AssociatedMessageId = task.AssociatedMessageId;
                    editTask.Completed = task.Completed;
                    editTask.Notes = task.Notes;
                    context.Entry(editTask).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    //New Task
                    context.Tasks.Add(task);
                    task.Created = DateTime.Now;
                }
                context.SaveChanges();
                return RedirectToAction("ViewAll");
            }

            ViewBag.Categories = context.Categories.Select(
                x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View(task);
        }
    }
}