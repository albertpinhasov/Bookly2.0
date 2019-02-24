using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bookly.DTOs;

namespace Bookly.Models
{
    public class ValidateDOB : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var customer = (CustomerDTO) context.ObjectInstance;

            int age =  DateTime.Now.Year - customer.DOB.Year;

            return (age > 16)
                ? ValidationResult.Success
                : new ValidationResult("You must be 16 years of age or older to sign up");
            
        }

    

    }
}