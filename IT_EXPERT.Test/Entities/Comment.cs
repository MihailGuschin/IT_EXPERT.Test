using System;

namespace IT_EXPERT.Test.Entities
{
    public class Comment: BaseEntity
    {
        public string Text { get; set; }
        public Guid TodoId { get; set; }
        public Todo Todo { get; set; }
    }
}
