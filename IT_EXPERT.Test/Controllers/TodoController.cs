using IT_EXPERT.Test.DTOs;
using IT_EXPERT.Test.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IT_EXPERT.Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]Guid[] ids, [FromQuery]string? title)
        {
            var result = _todoService.GetAll(ids, title);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _todoService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(TodoDtoCreate model)
        {
            var result = _todoService.AddTodo(model);
            result.CreatedDate = DateTime.Now;
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _todoService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TodoDtoUpdate model)
        {
            var result = _todoService.Update(id, model);
            return Ok(result);
        }
    }
}
