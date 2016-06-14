using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxes.Models
{
    public class Municipality
    {
        [Key]
        public int MunicipalityId { get; set; }

        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Index("Municipality_Name_Index", IsUnique = true)]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximum {1} and minimum {2} characters",
          MinimumLength = 1)]
        public string Name { get; set; }

        public virtual Department Department { get; set; }

    }
}