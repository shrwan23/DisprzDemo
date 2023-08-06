using demo.model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.model.ApiModels.Employee
{
    public class AddEmployee
    {
        [Required(ErrorMessage = "RequiredField")]
        [StringLength(40, MinimumLength =3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "RequiredField", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "InvalidMailId")]
        public string Email { get; set; }
        [Required(ErrorMessage = "RequiredField")]
        [StringLength(12, MinimumLength =6)]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "RequiredField")]
        public Department Department { get; set; }
        [Required(ErrorMessage = "RequiredField")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "RequiredField")]
        public int Salary { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
