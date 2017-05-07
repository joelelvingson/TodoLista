using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Dto;
using ToDoList.Models;
using System.Data.Entity;

namespace ToDoList.Controllers.API
{
    public class TaskController : ApiController
    {
        private ApplicationDbContext _context;

        public TaskController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<TaskDto> GetTasks(int ToDoI)
        {
            //int ToDoId = Convert.ToInt32(ToDoI);
            var TaskQuery = _context.Tasks.Where(t=>t.ToDoId == ToDoI);


            return TaskQuery.ToList().Select(Mapper.Map<Tasks, TaskDto>);
        }

        [HttpPost]
        public IHttpActionResult CreateToDo(TaskDto TaskDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var Tasks = Mapper.Map<TaskDto, Tasks>(TaskDto);
            _context.Tasks.Add(Tasks);
            _context.SaveChanges();

            TaskDto.Id = Tasks.Id;

            return Created(new Uri(Request.RequestUri + "/" + Tasks.Id), TaskDto);
        }


        [HttpPut]
        public void UpdateTask(TaskDto taskDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
   
            var taskInDb = _context.Tasks.SingleOrDefault(c => c.Id == taskDto.Id);

            if (taskInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            Mapper.Map(taskDto, taskInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteTask(int Id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);



            var TasksInDb = _context.Tasks.SingleOrDefault(c => c.Id == Id);

            if (TasksInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Tasks.Remove(TasksInDb);
            _context.SaveChanges();
        }

    }
}
