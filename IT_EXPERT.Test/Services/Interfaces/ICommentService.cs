using IT_EXPERT.Test.DTOs;

namespace IT_EXPERT.Test.Services.Interfaces
{
    public interface ICommentService
    {
        CommentDto Create(Guid todoId, CommentDto model);
        List<CommentDto> GetByTodoId(Guid id);
    }
}
