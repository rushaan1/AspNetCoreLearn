using AspNetCoreLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearn.CustomModelBinders
{
    public class InvoicePriceAttribute : ValidationAttribute
    {
        private string errorMessage = "Invoice Price and sum of product prices do not match!";
        public InvoicePriceAttribute() { }
        public InvoicePriceAttribute(string msg) { errorMessage = msg; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) 
            {
                var vv = (int)value;

                List<Product>? list = (validationContext.Items["Products"] as List<Product>);

                int totalPrice = 0;
                foreach (Product product in list) 
                {
                    totalPrice += (int) product.Price;
                }

                if (vv != totalPrice) 
                {
                    return new ValidationResult(errorMessage);
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
