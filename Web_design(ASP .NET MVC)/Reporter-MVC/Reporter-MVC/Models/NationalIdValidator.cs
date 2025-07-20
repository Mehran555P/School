using System;
using System.ComponentModel.DataAnnotations;

namespace Reporter_MVC.Models
{
    public static class NationalIdValidator
    {
        public static ValidationResult ValidateNationalId(object value, ValidationContext context)
        {
            string nid = value?.ToString();

            if (string.IsNullOrEmpty(nid))
                return new ValidationResult("کد ملی الزامی است");

            if (nid.Length != 10 || !long.TryParse(nid, out _))
                return new ValidationResult("کد ملی باید ۱۰ رقمی و عددی باشد");

            // الگوریتم اعتبارسنجی کد ملی
            int checkDigit = Convert.ToInt32(nid[9].ToString());
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += Convert.ToInt32(nid[i].ToString()) * (10 - i);
            }

            int remainder = sum % 11;
            bool isValid = (remainder < 2 && checkDigit == remainder) ||
                          (remainder >= 2 && checkDigit == 11 - remainder);

            return isValid
                ? ValidationResult.Success
                : new ValidationResult("کد ملی وارد شده معتبر نیست");
        }
    }
}