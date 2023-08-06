using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.EF
{
    public class AuditFields
    {
        public bool IsActive { get; set; } = true;

        [StringLength(20, ErrorMessage = "StringMinMaxLength")]
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "RequiredField")]
        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        [StringLength(20, ErrorMessage = "StringMinMaxLength")]
        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

    }
}
