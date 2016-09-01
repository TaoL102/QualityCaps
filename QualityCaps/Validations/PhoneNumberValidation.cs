using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QualityCaps.Validations
{

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        public class ValidatePhoneNumber : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                string PhoneHome = (string)validationContext.ObjectType.GetProperty("PhoneHome").GetValue(validationContext.ObjectInstance, null);

                string PhoneWork = (string)validationContext.ObjectType.GetProperty("PhoneWork").GetValue(validationContext.ObjectInstance, null);

                string PhoneMobile = (string)validationContext.ObjectType.GetProperty("PhoneMobile").GetValue(validationContext.ObjectInstance, null);

                //check at least one has a value
                if (string.IsNullOrEmpty(PhoneHome) && string.IsNullOrEmpty(PhoneWork) && string.IsNullOrEmpty(PhoneMobile))
                    return new ValidationResult("At least one phone number is required!");

                return ValidationResult.Success;
            }
        }
    
}