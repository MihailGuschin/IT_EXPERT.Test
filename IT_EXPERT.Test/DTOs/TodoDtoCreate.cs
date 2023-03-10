using IT_EXPERT.Test.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace IT_EXPERT.Test.DTOs
{
    public class TodoDtoCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [RegularExpression("red|green|blue")]
        public string Color { get; set; }
    }
}
