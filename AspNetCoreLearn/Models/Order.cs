using AspNetCoreLearn.AdditionalAttributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearn.Models
{
    public class Order
    {
        [BindNever]
        private int? OrderNo { get; set; }

        [Required]
        [OrderDateAttribute("2000-01-01")]
        DateTime OrderDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        double InvoicePrice { get; set; }

        [Required]
        List<Product> Products { get; set; }
    }
}
