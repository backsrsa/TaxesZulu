﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxes.Models
{
    public class TaxPaer
    {
        [Key]
        public int TaxPaerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage =
                        "The field {0} can contain maximun {1} and minimum {2} characters",
                        MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage =
                     "The field {0} can contain maximun {1} and minimum {2} characters",
                     MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "E-Mail"), DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(80, ErrorMessage =
                     "The field {0} can contain maximun {1} and minimum {2} characters",
                     MinimumLength = 7)]
        [Index("TaxPaer_UserName_Index", IsUnique = true)]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(20, ErrorMessage =
                   "The field {0} can contain maximun {1} and minimum {2} characters",
                   MinimumLength = 7)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int MunicipalityId { get; set; }
        
        [StringLength(80, ErrorMessage =
                 "The field {0} can contain maximun {1} and minimum {2} characters",
                 MinimumLength = 7)]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(20, ErrorMessage =
               "The field {0} can contain maximun {1} and minimum {2} characters",
               MinimumLength = 5)]
        [Index("TaxPaer_Document_Index", IsUnique = true)]
        public string Document { get; set; }

        public virtual Department Department { get; set; }
        
        public virtual Municipality Municipality { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual ICollection<Property> Properties { get; set; }


    }
}