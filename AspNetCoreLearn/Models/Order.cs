using AspNetCoreLearn.AdditionalAttributes;
using AspNetCoreLearn.CustomModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearn.Models
{
    public class Order
    {
        [BindNever]
        public int? OrderNo { get; set; }

        [OrderDateAttribute("2000-01-01")]
        [Required(ErrorMessage = "OrderDate is a required key!")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "InvoicePrice is a required key!")]
        [Range(1, int.MaxValue)]
        [InvoicePriceAttribute()]
        public double? InvoicePrice { get; set; }

        [Required(ErrorMessage = "Products is a required key!")]
        [ProductsExistAttribute]
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
