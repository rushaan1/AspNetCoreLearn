using AspNetCoreLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
                var vv = (double)value;

                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
                if (otherProperty != null) 
                {
                    List<Product> list = (List<Product>)otherProperty.GetValue(validationContext.ObjectInstance)!;

                    int? totalPrice = 0;
                    foreach (Product product in list)
                    {
                        totalPrice += (int?)product.Price * product.Quantity;
                    }

                    if (vv != totalPrice)
                    {
                        return new ValidationResult(errorMessage);
                    }
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
