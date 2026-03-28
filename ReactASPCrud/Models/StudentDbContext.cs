using Microsoft.AspNetCore.Hosting.Server;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

namespace ReactASPCrud.Models
{
    public class StudentDbContext : DbContext    //inherits from DbContext parent class
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)   //options let the DbContext(Parent) class know which database, which provider and what msg to show after successful connection with DB
        {
        }

        public DbSet<Student> Students { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=mydb;Trusted_Connection=True;TrustServerCertificate=True;");

        //}
    }
}
