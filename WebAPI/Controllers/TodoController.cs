using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
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
                ? Ok(todo)
                : NotFound();
        }

        [HttpPost]
        public IActionResult Create(CreateToDoRequest todo_test)
        {
            var todo = new TodoItem
            {
                Description = todo_test.Description,   
                IsDone = todo_test.IsDone,
                Title = todo_test.Title,
            };
             var created = _todoService.Create(todo);

           return created == true
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
