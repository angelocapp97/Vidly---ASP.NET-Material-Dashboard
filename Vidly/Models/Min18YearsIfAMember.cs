using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var today = DateTime.Today;
            var birthdate = customer.Birthdate.Value;
            
            var age = today.Year - birthdate.Year;

            // Go back to the year the person was born in case of a leap year
            if (birthdate > today.AddYears(-age)) age--;

            if (age < 0)
                return new ValidationResult("Birthdate cannot exceed today's date.");

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}