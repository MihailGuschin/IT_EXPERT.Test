using IT_EXPERT.Test.DTOs;

namespace IT_EXPERT.Test.Services.Interfaces
{
    public interface ITodoService
    {
        List<TodoDto> GetAll(Guid[] ids, string title);
        TodoDto Get(Guid id);
        TodoDto AddTodo(TodoDtoCreate model);
        void Delete(Guid id);
        TodoDto Update(Guid id, TodoDtoUpdate model);
    }
}
