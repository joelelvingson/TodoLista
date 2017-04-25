﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Models;
using ToDoList.Dto;
using AutoMapper;

namespace ToDoList.Controllers.API
{
    public class ToDoController : ApiController
    {
        private ApplicationDbContext _context;

        public ToDoController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<ToDoDto> GetToDos(string query = null)
        {
            var ToDoQuery = _context.Todos;

            //if (!string.IsNullOrWhiteSpace(query))
            //    ToDoQuery = ToDoQuery.Where(t => t.Name.Contains(query));

            return ToDoQuery.ToList().Select(Mapper.Map<Todo, ToDoDto>);
        }

        [HttpPost]
        public IHttpActionResult CreateToDo(ToDoDto ToDoDto)
        {
            var toDo = Mapper.Map<ToDoDto, Todo>(ToDoDto);
            _context.Todos.Add(toDo);
            _context.SaveChanges();

            ToDoDto.Id = toDo.Id;

            return Created(new Uri(Request.RequestUri + "/" + toDo.Id), ToDoDto);
        }

        [HttpDelete]
        public void DeleteToDo(int Id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);



            var ToDoInDb = _context.Todos.SingleOrDefault(c => c.Id == Id);
            var TasksInDb = _context.Tasks.Where(e => e.ToDoId == Id);
            if (ToDoInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Todos.Remove(ToDoInDb);
            if(TasksInDb != null)
            {
                foreach (var tasks in TasksInDb)
                {
                    _context.Tasks.Remove(tasks);
                }
            }


            _context.SaveChanges();
        }


    }
}
