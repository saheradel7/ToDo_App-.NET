using Microsoft.EntityFrameworkCore;

namespace ToDo.Models
{
    public class ToDoEntity : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-82R2B9J\\SQLEXPRESS;Database=ToDoDb;Trusted_Connection=True; trust server certificate = true");
            base.OnConfiguring(optionsBuilder);
           
        }

    }
}
