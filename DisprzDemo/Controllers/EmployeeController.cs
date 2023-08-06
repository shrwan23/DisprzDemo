using demo.dataServices;
using demo.model.ApiModels.Employee;
using DisprzDemo.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;

namespace DisprzDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMailService _mailService;
        
        public EmployeeController(IEmployeeRepository employeeRepo, ILogger<EmployeeController> logger, IMailService mailService)
        {
            _employeeRepo = employeeRepo;
            _logger = logger;
            _mailService = mailService;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            var list = _employeeRepo.Get();
            
            return list;
        }

        [HttpGet]
        [Route("{id}")]
        public Employee GetEmployee(int id)
        {
            var emp = _employeeRepo.Get(id);

            return emp;
        }

        [HttpPost]
        [Route("{id}/welcome")]
        public async Task<ActionResult> Welcome(int id)
        {
            try
            {
                var emp = _employeeRepo.Get(id);

                if(emp != null)
                {
                    await _mailService.SendWelcomeEmailAsync(emp);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Add([FromBody] AddEmployee employee) 
        {
            if (ModelState.IsValid)
            {
                var emp = await _employeeRepo.Add(employee);

                return emp;
            }
            else
            {
                return BadRequest(ModelState);
            }
          
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> Update([FromBody] EmployeeUpdate employee)
        {
            if (ModelState.IsValid)
            {
                var emp = await _employeeRepo.Update(employee);

                return emp;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var emp = await _employeeRepo.Delete(id);

                return emp;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(ModelState);
            }
        }
    }
}