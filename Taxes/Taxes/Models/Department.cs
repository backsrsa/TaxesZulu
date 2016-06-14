using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxes.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Index("Department_Name_Index", IsUnique = true)]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximum {1} and minimum {2} characters",
          MinimumLength = 1)]
        public string Name { get; set; }

        public virtual ICollection<Municipality> Municipalities { get; set; }
    }
}