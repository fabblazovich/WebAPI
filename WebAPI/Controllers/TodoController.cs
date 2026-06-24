using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();


        [HttpGet("{id}")]
        public IActionResult GetbyID(int id)
        {
            var todo = TodoItem.Items.FirstOrDefault(x => x.ID == id);
            if (todo == null) return NotFound();
            else return Ok(todo);
        }

        [HttpPost]
        public IActionResult Create(TodoItem todo)
        {
            TodoItem.Items.Add(todo);
            return Created();
        }


        [HttpDelete ("{id}")]
        public IActionResult Delete(int id) => Delete(id);
    }

    
}
