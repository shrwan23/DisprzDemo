using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.model.ApiModels.Employee
{
    public class EmployeeUpdate : AddEmployee
    {
        [Required(ErrorMessage = "RequiredField")]
        public int Id { get; set; }
    }
}
