using demo.EF;
using demo.model.ApiModels.Employee;
using Microsoft.EntityFrameworkCore;

namespace demo.dataServices
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> Get();
        Task<Employee> Get(int id);
        Task<Employee> Add(AddEmployee employee);
        Task<Employee> Update(EmployeeUpdate employee);
        Task<Employee> Delete(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<List<Employee>> Get()
        {
            using (var context = new ApiContext())
            {
                var employeees = await context.Employees.Select(x => toEmpApiModel(x)).ToListAsync();

                return employeees;
            }
        }

        public async Task<Employee> Get(int id)
        {
            Employee emp;
            using (var context = new ApiContext())
            {
                var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                emp = toEmpApiModel(employee);
            }

            return emp;
        }

        public async Task<Employee> Add(AddEmployee employee)
        {

            Employee emp;
            using (var context = new ApiContext())
            {
                var obj =await context.Employees.AddAsync(new EF.Entities.Employee
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    BirthDate = employee.BirthDate,
                    ContactNo = employee.ContactNo,
                    Department = employee.Department,
                    IsActive = employee.IsActive,
                    Salary = employee.Salary,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "shravan",
                    LastUpdatedOn = DateTime.Now,
                    LastUpdatedBy = "shravan",
                });
                context.SaveChanges();
                emp = toEmpApiModel(obj.Entity);
            }

            return emp;
        }

        public async Task<Employee> Update(EmployeeUpdate employee)
        {
            Employee emp;
            using (var context = new ApiContext())
            {
                var obj = context.Employees.FirstOrDefault(x => x.Id == employee.Id);
                obj.Name = employee.Name;
                obj.Email = employee.Email;
                obj.BirthDate = employee.BirthDate;
                obj.ContactNo = employee.ContactNo;
                obj.Department = employee.Department;
                obj.IsActive = employee.IsActive;
                obj.Salary = employee.Salary;
                obj.LastUpdatedOn = DateTime.Now;
                obj.LastUpdatedBy = "shravan";
                await context.SaveChangesAsync();
                emp = toEmpApiModel(obj);
            }

            return emp;
        }

        public async Task<Employee> Delete(int id)
        {
            Employee emp;
            using (var context = new ApiContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.Id == id);
                emp = toEmpApiModel(employee);
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }

            return emp;
        }

        private Employee toEmpApiModel(EF.Entities.Employee x)
        {
            if (x == null)
                return null;

            return new Employee
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                BirthDate = x.BirthDate,
                ContactNo = x.ContactNo,
                Department = x.Department,
                IsActive = x.IsActive,
                Salary = x.Salary,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                LastUpdatedOn = x.LastUpdatedOn,
                LastUpdatedBy = x.LastUpdatedBy,
            };
        }
    }
}