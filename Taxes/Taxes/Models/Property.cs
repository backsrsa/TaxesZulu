using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taxes.Models
{
    public class Property
    {
        [Key]
        public string PropertyId { get; set; }
        public int TaxPaerId { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public int MunicipalityId { get; set; }
        public string Address { get; set; }
        public int PropertyTypeId { get; set; }
        public string Stratus { get; set; }
        public float Area { get; set; }

        public virtual TaxPaer TaxPaer { get; set; }
        public virtual Department Department { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual PropertyType PropertyType { get; set; }

    }
}