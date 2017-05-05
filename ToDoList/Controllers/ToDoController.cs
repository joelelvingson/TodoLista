using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.ViewModel;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private ApplicationDbContext _context;

        public ToDoController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ToDo
        [Authorize]
        public ActionResult Edit(int Id)
        {
            var user = User.Identity.GetUserId();

            var ToDoList = _context.Todos.SingleOrDefault(t => t.Id == Id);
            var TaskList = _context.Tasks.Where(t => t.ToDoId == Id);

            if (ToDoList.User != user)
            {
                return HttpNotFound();
            }

            if (ToDoList == null)
                return HttpNotFound();

            var ToDoListView = new ToDoFormViewModel
            {
                Todo = ToDoList,
                Tasks = TaskList.ToList()
            };

            return View("Edit", ToDoListView);
        }

        [Authorize]
        public ActionResult New()
        {
            var user = User.Identity.GetUserId();
            var ToDoLists = _context.Todos.Where(m=>m.User == user);
            var ToDoList = new ListFormViewModel()
            {
                ToDos = ToDoLists.ToList()
            };


            return View("New", ToDoList);
        }
    }

}