using AspNetCoreLearn.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearn.AdditionalAttributes
{
    // only this class code copied from Andrew Beckers! 
    public class ProductsExistAttribute : ValidationAttribute

    {

        public string DefaultErrorMessage { get; set; } = "Order should have at least one product";



        public ProductsExistAttribute()

        {

        }



        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)

        {

            //check if the value of "Products" property is not null

            if (value != null)

            {

                List<Product> products = (List<Product>)value;



                //if no products

                if (products.Count == 0)

                {

                    //return validation error

                    return new ValidationResult(DefaultErrorMessage);

                }



                //No validation error

                return ValidationResult.Success;

            }

            return null;

        }

    }
}
