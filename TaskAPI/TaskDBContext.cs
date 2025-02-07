using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;
using Task = TaskAPI.Models.Task;

namespace TaskAPI
{
    public class TaskDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TaskDB.db");
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
