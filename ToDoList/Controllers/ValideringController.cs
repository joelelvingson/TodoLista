using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ValideringController : Controller
    {

        private ApplicationDbContext _context;

        public ValideringController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Validering
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Todo val)
        {
            var hej = new Todo
            {
                Name = val.Name
            };
            _context.Todos.Add(hej);
            _context.SaveChanges();

            return View("Svar", hej);
        }
    }
}