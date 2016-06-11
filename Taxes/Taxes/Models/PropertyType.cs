using System.ComponentModel.DataAnnotations;

namespace Taxes.Models
{
    public class PropertyType
    {
        [Key]
        public int PropertyTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}