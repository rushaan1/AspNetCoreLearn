using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearn.AdditionalAttributes
{
    public class OrderDateAttribute : ValidationAttribute
    {
        private DateTime minDate;
        private string errM = "Date should be greater than Year 2000!";
        public OrderDateAttribute(string minDate) 
        {
            this.minDate = Convert.ToDateTime(minDate);
        }

        public OrderDateAttribute(string minDate, string errM)
        {
            this.minDate = Convert.ToDateTime(minDate);
            this.errM = errM;
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) 
            {
                DateTime vv = (DateTime)value;
                if (vv < minDate) 
                {
                    return new ValidationResult(errM);
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
