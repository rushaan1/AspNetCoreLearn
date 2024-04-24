using AspNetCoreLearn.CustomModelBinders;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearn.Models
{
    public class Product
    {
        [Required(ErrorMessage = "ProductCode is a required key!")]
        [Range(1, int.MaxValue)]
        public int? ProductCode { get; set; }

        [Required(ErrorMessage = "Price is a required key!")]
        [Range(1, int.MaxValue)]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Quantity is a required key!")]
        [Range(1,int.MaxValue)]
        public int? Quantity { get; set; }
    }
}
