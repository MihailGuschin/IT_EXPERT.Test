using IT_EXPERT.Test.Entities.Enums;
using System;
using System.Collections.Generic;

namespace IT_EXPERT.Test.Entities
{
    public class Todo: BaseEntity
    {
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
        public Category Category { get; set; }
        public string Color { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
