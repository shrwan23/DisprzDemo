using demo.EF.Entities;
using demo.model.Enums;
using Microsoft.EntityFrameworkCore;

namespace demo.EF
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
              (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EmployeeDB");
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Shravan",
                    Email = "shravan@gmail.com",
                    Department = Department.Admin,
                    Salary = 20000,
                    BirthDate = new DateTime(1995, 8,1),
                    ContactNo = "9106056046",
                    CreatedBy = "Init",
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = "init"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Ramesh",
                    Email = "ramesh@gmail.com",
                    Department = Department.Sales,
                    Salary = 10000,
                    BirthDate = new DateTime(1995, 8, 1),
                    ContactNo = "9106056045",
                    CreatedBy = "Init",
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = "init"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Ankit",
                    Email = "Ankit@gmail.com",
                    Department = Department.Finance,
                    Salary = 15000,
                    BirthDate = new DateTime(1995, 8, 1),
                    ContactNo = "9106056044",
                    CreatedBy = "Init",
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = "init"
                },
                new Employee
                {
                    Id = 4,
                    Name = "Lalit",
                    Email = "lalit@gmail.com",
                    Department = Department.Engineering,
                    Salary = 25000,
                    BirthDate = new DateTime(1995, 8, 1),
                    ContactNo = "9106056043",
                    CreatedBy = "Init",
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = "init"
                },
                new Employee
                {
                    Id = 5,
                    Name = "Deep",
                    Email = "deep@gmail.com",
                    Department = Department.Marketing,
                    Salary = 22000,
                    BirthDate = new DateTime(1995, 8, 1),
                    ContactNo = "9106056042",
                    CreatedBy = "Init",
                    CreatedOn = DateTime.Now,
                    LastUpdatedBy = "init"
                }
                );
        }
    }
}