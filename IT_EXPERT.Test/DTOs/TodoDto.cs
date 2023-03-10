using IT_EXPERT.Test.Entities.Enums;

namespace IT_EXPERT.Test.DTOs
{
    public class TodoDto: BaseDto
    {
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
        public Category Category { get; set; }
        public string Color { get; set; }
        public string Hash { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
