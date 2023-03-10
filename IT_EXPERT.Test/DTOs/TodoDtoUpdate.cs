using System.ComponentModel.DataAnnotations;

namespace IT_EXPERT.Test.DTOs
{
    public class TodoDtoUpdate
    {
        [Required]
        public string Title { get; set; }
    }
}
