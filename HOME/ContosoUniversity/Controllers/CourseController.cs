using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Domain.Interfaces;
using ContosoUniversity.Domain.Entities.Base;

namespace ContosoUniversity.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
         protected CrudRepository<Course> _repository;
        public CourseController()
        {
             _repository = new CrudRepository<Course>();
        }
               // ...
        [HttpGet]
        [Route("")]
        public IActionResult Get(){
        return Ok(_repository.GetAll());
        }
        // ...
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id){
        return Ok(_repository.GetById(id));
        }
        // ...
        [HttpGet]
        [Route("findBy")]
        public IActionResult Get([FromQuery]Course course){
        Func<Course, bool> filter = x => x.Name.Contains(course.Name);
        return Ok(_repository.FindBy(filter));
        }
    }
}