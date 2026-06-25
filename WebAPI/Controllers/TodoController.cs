using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController (ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_todoService.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetbyID(int id)
        {
            var todo = _todoService.GetById(id);
            return todo != null
                ? Ok(id)
                : NotFound();
        }

        [HttpPost]
        public IActionResult Create(TodoItem todo_test)
        {
           var todo = _todoService.Create(todo_test);
           return todo == true
                ? Created()
                : BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todoService.Delete(id);
            return todo == true
                 ? Ok()
                 : NotFound();
        }
    }
}
