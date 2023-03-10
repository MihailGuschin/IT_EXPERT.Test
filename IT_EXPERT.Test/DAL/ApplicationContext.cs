using IT_EXPERT.Test.Entities;
using IT_EXPERT.Test.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace IT_EXPERT.Test.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid todoId = Guid.NewGuid(); 
            modelBuilder.Entity<Todo>().HasData(
                new Todo[]
                {
                    new Todo
                    {
                        Id = todoId,
                        Title = "Create a ticket",
                        Category = Category.Analytics,
                        Color = "red",
                        CreatedDate = DateTime.Now.ToUniversalTime(),
                    },
                    new Todo
                    {
                        Id = Guid.NewGuid(),
                        Title = "Request information",
                        Category = Category.Bookkeeping,
                        Color = "green",
                        CreatedDate = DateTime.Now.ToUniversalTime(),
                    }
                });
            modelBuilder.Entity<Todo>().HasAlternateKey(x => new { x.Category, x.Title });

            modelBuilder.Entity<Comment>().HasData(
                new Comment[]
                {
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        TodoId = todoId,
                        Text = "first comment..."
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        TodoId = todoId,
                        Text = "second comment..."
                    }
                });
        }
    }
}
