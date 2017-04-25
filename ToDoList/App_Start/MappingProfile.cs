using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;
using ToDoList.Dto;

namespace ToDoList.App_Start
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Todo, ToDoDto>();
            Mapper.CreateMap<ToDoDto, Todo>();

            Mapper.CreateMap<Tasks, TaskDto>();
            Mapper.CreateMap<TaskDto, Tasks>();
        }
    }
}