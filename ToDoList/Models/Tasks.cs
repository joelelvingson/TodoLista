﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ToDoId { get; set; }
        public bool status { get; set; }

    }
}