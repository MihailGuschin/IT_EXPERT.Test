using IT_EXPERT.Test.DTOs;
using IT_EXPERT.Test.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IT_EXPERT.Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{todoId}")]
        public IActionResult GetByTodoId(Guid todoId)
        {
            var result = _commentService.GetByTodoId(todoId);
            return Ok(result);
        }

        [HttpPost("{todoId}")]
        public IActionResult Create(Guid todoId, CommentDto model)
        {
            try
            {
                var result = _commentService.Create(todoId, model);
                return Ok(result);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
