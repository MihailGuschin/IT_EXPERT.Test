using AutoMapper;
using IT_EXPERT.Test.DAL;
using IT_EXPERT.Test.DTOs;
using IT_EXPERT.Test.Entities;
using IT_EXPERT.Test.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IT_EXPERT.Test.Services
{
    public class TodoService: ITodoService
    {
        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;

        public TodoService(ApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TodoDto> GetAll(Guid[] ids, string title)
        {
            IQueryable<Todo> query = _dbContext.Todos.Include(x => x.Comments);

            if(ids != null && ids.Any())
            {
                query = query.Where(x => ids.Contains(x.Id));
            }
            if(!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title == title);
            }
            var list = query.ToList();

            return _mapper.Map<List<TodoDto>>(list);
        }

        public TodoDto Get(Guid id)
        {
            var result = _dbContext.Todos
                .Include(x => x.Comments)
                .SingleOrDefault(x => x.Id == id);

            return _mapper.Map<TodoDto>(result);
        }

        public TodoDto AddTodo(TodoDtoCreate model)
        {
            var entity = _mapper.Map<Todo>(model);
            _dbContext.Todos.Add(entity);
            _dbContext.SaveChanges();

            var result = _dbContext.Todos.Single(x => x.Id == entity.Id);
            result.CreatedDate = DateTime.Now;
            return _mapper.Map<TodoDto>(result);
        }

        public void Delete(Guid id)
        {
            var result = _dbContext.Todos
                .Include(x => x.Comments)
                .Single(x => x.Id == id);

            _dbContext.Remove(result);
            _dbContext.SaveChanges(true);
        }

        public TodoDto Update(Guid id, TodoDtoUpdate model)
        {
            var result = _dbContext.Todos
                .Include(x => x.Comments)
                .Single(x => x.Id == id);

            result.Title = model.Title;

            _dbContext.SaveChanges();

            var updated = _dbContext.Todos
                .Include(x => x.Comments)
                .SingleOrDefault(x => x.Id == id);

            return _mapper.Map<TodoDto>(updated);
        }
    }
}
