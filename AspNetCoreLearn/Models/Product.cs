using AspNetCoreLearn.CustomModelBinders;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearn.Models
{
    public class Product
    {
        [Required]
        [Range(1, int.MaxValue)]
        int ProductCode { get; set; }

        [Required]
        [InvoicePriceAttribute()]
        public double Price { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        int Quantity { get; set; }
    }
}
