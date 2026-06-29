using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WebAPI.DTO;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController (ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult Get(bool? isDone, string? search)
        {
            var todos = _todoService.GetAll(isDone, search);
            return Ok(todos);
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
                 ? NoContent()
                 : NotFound();
        }

        [HttpPost("{id}")]

        public IActionResult Update (int id, UpdateToDoRequest todo)
        {
            var updated = _todoService.Update(id, todo);

            return updated == true
                ? NoContent()
                : NotFound();
        }
    }
}
