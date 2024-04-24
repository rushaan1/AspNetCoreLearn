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
            Console.WriteLine("womp womp");
            this.minDate = Convert.ToDateTime(minDate);
            this.errM = errM;
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Console.WriteLine("womp womp1");
            if (value != null)
            {
                DateTime vv = (DateTime)value;
                if (vv < minDate)
                {
                    Console.WriteLine("womp womp2");
                    return new ValidationResult(errM);
                }
                return ValidationResult.Success;
            }
            else 
            {
                Console.WriteLine("Value is null!");
            }
            return null;
        }
    }
}
