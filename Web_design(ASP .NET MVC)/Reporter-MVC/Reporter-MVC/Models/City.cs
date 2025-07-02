using System.ComponentModel.DataAnnotations;

namespace Reporter_MVC.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; } // نام شهر

        [Required]
        public string code { get; set; } // کد شهر

        [Required]
        public string fromCode { get; set; } // کد مبدا

        [Required]
        public string toCode { get; set; } // کد مقصد

        [Required]
        public string stateName { get; set; } // نام استان
    }
}