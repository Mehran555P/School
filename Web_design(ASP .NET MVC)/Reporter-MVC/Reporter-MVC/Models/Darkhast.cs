using System;
using System.ComponentModel.DataAnnotations;

namespace Reporter_MVC.Models
{
    public class Darkhast
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "تاریخ ثبت الزامی است")]
        [Display(Name = "تاریخ ثبت")]
        public string regDate { get; set; }

        [Required(ErrorMessage = "نام الزامی است")]
        [StringLength(50, ErrorMessage = "نام نمی‌تواند بیش از 50 کاراکتر باشد")]
        [Display(Name = "نام")]
        public string name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        [StringLength(50, ErrorMessage = "نام خانوادگی نمی‌تواند بیش از 50 کاراکتر باشد")]
        [Display(Name = "نام خانوادگی")]
        public string family { get; set; }

        [Required(ErrorMessage = "کد ملی الزامی است")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید 10 رقم باشد")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی باید فقط عدد باشد")]
        [Display(Name = "کد ملی")]
        public string NID { get; set; }

        [Required(ErrorMessage = "نوع درخواست الزامی است")]
        [Display(Name = "نوع درخواست")]
        public string type { get; set; }

        [Required(ErrorMessage = "وضعیت الزامی است")]
        [Display(Name = "وضعیت")]
        public string state { get; set; }

        [Display(Name = "تاریخ بازگشت")]
        public string returnDate { get; set; }

        [Display(Name = "شماره سریال")]
        public string serialNumber { get; set; }

        [Display(Name = "تاریخ ارسال پستی")]
        public string postSentDate { get; set; }

        [Display(Name = "تاریخ بازگشت پستی")]
        public string postReturnDate { get; set; }

        [Display(Name = "تحویل به متقاضی")]
        public string deliveryToApplicant { get; set; }

        [Display(Name = "افسر ارجاع دهنده")]
        public string referingOffic { get; set; }

        [Required(ErrorMessage = "توضیحات ارسال مجدد الزامی است")]
        [Display(Name = "توضیحات ارسال مجدد")]
        public string resendDescription { get; set; }

        [Required(ErrorMessage = "نوع ارسال الزامی است")]
        [Display(Name = "نوع ارسال")]
        public string sendingType { get; set; }

        [Required(ErrorMessage = "هزینه الزامی است")]
        [Range(0, int.MaxValue, ErrorMessage = "هزینه باید عدد مثبت باشد")]
        [Display(Name = "هزینه")]
        public int cost { get; set; }

        [Required(ErrorMessage = "هزینه دفتر الزامی است")]
        [Range(0, int.MaxValue, ErrorMessage = "هزینه دفتر باید عدد مثبت باشد")]
        [Display(Name = "هزینه دفتر")]
        public int officeCost { get; set; }
    }

    public class NationalIdValidator
    {
        public static ValidationResult ValidateNationalId(string nid)
        {
            if (string.IsNullOrEmpty(nid) || nid.Length != 10 || !nid.All(char.IsDigit))
                return new ValidationResult("کد ملی باید 10 رقم باشد");

            // الگوریتم اعتبارسنجی کد ملی ایران
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += (10 - i) * int.Parse(nid[i].ToString());
            }
            int remainder = sum % 11;
            int controlDigit = int.Parse(nid[9].ToString());

            bool isValid = (remainder < 2 && controlDigit == remainder) ||
                         (remainder >= 2 && controlDigit == (11 - remainder));

            return isValid
                ? ValidationResult.Success
                : new ValidationResult("کد ملی معتبر نیست");
        }
    }
}