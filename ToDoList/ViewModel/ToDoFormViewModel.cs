using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;

namespace ToDoList.ViewModel
{
    public class ToDoFormViewModel
    {
        public List<Tasks> Tasks { get; set; }
        public Todo Todo { get; set; }
    }
}