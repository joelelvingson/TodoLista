using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ToDoId { get; set; }
        public bool status { get; set; }
    }
}