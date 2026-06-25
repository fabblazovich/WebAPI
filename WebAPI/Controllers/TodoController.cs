using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            TodoItem.FillList();

            return Ok(TodoItem.TodoItems);
        }


        [HttpGet("{id}")]
        public IActionResult GetbyID(int id)
        {
            var todo = TodoItem.TodoItems.FirstOrDefault(x => x.ID == id);
            return todo is null 
                ?  NotFound()
                :  Ok(todo);
        }

        [HttpPost]
        public IActionResult Create(TodoItem todo)
        {
            TodoItem.TodoItems.Add(todo);
            return Created();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = TodoItem.TodoItems.FirstOrDefault(x => x.ID == id);
            if (todo is null) return NotFound(id);

            TodoItem.DeleteToDo(id);

            return Ok();
        }
    }

    
}
