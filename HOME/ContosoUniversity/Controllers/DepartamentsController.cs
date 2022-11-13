using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Domain.Interfaces;
using ContosoUniversity.Domain.Entities.Base;


namespace ContosoUniversity.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentsController : ControllerBase
    {
         protected CrudRepository<Departaments> _repository;
        public DepartamentsController()
        {
             _repository = new CrudRepository<Departaments>();
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
        public IActionResult Get([FromQuery]Departaments departaments){
        Func<Departaments, bool> filter = x => x.Name.Contains(departaments.Name);
        return Ok(_repository.FindBy(filter));
        }
        
    }
}