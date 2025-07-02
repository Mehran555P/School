using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reporter_MVC.Models
{
    [Table("GlobalDetails")] 
    public class GlobalDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // برای Identity بودن
        public int Id { get; set; }

        [Required]
        public int groupCode { get; set; }

        [Required]
        public int groupId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")] // مشخص کردن نوع دقیق فیلد
        public string value { get; set; }
    }
}