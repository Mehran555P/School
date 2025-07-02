using System;
using System.ComponentModel.DataAnnotations;

namespace Reporter_MVC.Models
{
    public class Darkhast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string regDate { get; set; } // تاریخ ثبت

        [Required]
        public string name { get; set; } // نام

        [Required]
        public string family { get; set; } // نام خانوادگی

        [Required]
        public string NID { get; set; } // کد ملی

        [Required]
        public string type { get; set; } // نوع درخواست

        [Required]
        public string state { get; set; } // وضعیت

        public string returnDate { get; set; } // تاریخ بازگشت
        public string serialNumber { get; set; } // شماره سریال
        public string postSentDate { get; set; } // تاریخ ارسال پستی
        public string postReturnDate { get; set; } // تاریخ بازگشت پستی
        public string deliveryToApplicant { get; set; } // تحویل به متقاضی
        public string referingOffic { get; set; } // افسر ارجاع دهنده

        [Required]
        public string resendDescription { get; set; } // توضیحات ارسال مجدد

        [Required]
        public string sendingType { get; set; } // نوع ارسال

        [Required]
        public int cost { get; set; } // هزینه

        [Required]
        public int officeCost { get; set; } // هزینه دفتر
    }
}