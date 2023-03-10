using System.ComponentModel.DataAnnotations;

namespace IT_EXPERT.Test.DTOs
{
    public class CommentDto
    {
        [Required]
        public string Text { get; set; }
        public Guid TodoId { get; set; }
    }
}
