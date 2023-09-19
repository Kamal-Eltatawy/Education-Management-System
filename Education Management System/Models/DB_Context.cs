using Microsoft.EntityFrameworkCore;

namespace Education_Management_System.Models
{
    public class DB_Context : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Education_Mangment_System;Integrated Security=True;Encrypt=False");
        }
    }
}
