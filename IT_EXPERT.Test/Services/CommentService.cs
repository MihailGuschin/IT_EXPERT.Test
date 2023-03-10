using AutoMapper;
using IT_EXPERT.Test.DAL;
using IT_EXPERT.Test.DTOs;
using IT_EXPERT.Test.Entities;
using IT_EXPERT.Test.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace IT_EXPERT.Test.Services
{
    public class CommentService: ValidationService<Comment>, ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _dbContext;
        public CommentService(IMapper mapper, ApplicationContext dbContext): base(dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<CommentDto> GetByTodoId(Guid todoId)
        {
            var result = _dbContext.Comments.Where(x => x.TodoId == todoId).ToList();
            return _mapper.Map<List<CommentDto>>(result);
        }

        public CommentDto Create(Guid todoId, CommentDto model)
        {
            if( Exist(x => x.Text, model.Text))
            {
                throw new ValidationException($"property {nameof(model.Text)} exist");
            }

            model.TodoId = todoId;
            var entity = _mapper.Map<Comment>(model);
            _dbContext.Comments.Add(entity);
            _dbContext.SaveChanges();

            var result = _dbContext.Comments.Single(x => x.Id == entity.Id);
            return _mapper.Map<CommentDto>(result);
        }
    }
}
