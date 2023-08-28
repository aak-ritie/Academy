using BuilderAcademy.Models;
using System.Collections.Generic;

namespace BuilderAcademy.Data
{
    public class AppDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//This constructor is used to initialize an instance of the AppDbContext class with the provided DbContextOptions<AppDbContext> and pass them to the base class constructor.
        {

        }
        public DbSet<Student> studentsTable { get; set; }
    }
}
