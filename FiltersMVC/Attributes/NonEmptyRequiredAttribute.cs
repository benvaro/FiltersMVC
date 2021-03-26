using System;
using System.ComponentModel.DataAnnotations;

namespace FiltersMVC.Attributes
{
    public class NonEmptyRequiredAttribute : ValidationAttribute
    {
        public NonEmptyRequiredAttribute()
        {
            ErrorMessage = "Cannot be empty";
        }
        public NonEmptyRequiredAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public override bool IsValid(object value)
        {
            return !String.IsNullOrWhiteSpace(value?.ToString());
        }
    }
}