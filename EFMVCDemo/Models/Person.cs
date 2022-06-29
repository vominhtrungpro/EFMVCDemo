using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFMVCDemo.Models
{
    public class Person
    {

        // Attribute
        [Key]
        [DisplayName("Person ID")]
        public int PersonId { get; set; }

        [DisplayName("Person Name")]
        [Required(ErrorMessage = " Tên không được để trống! ")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 ký tự")]
        public string? PersonName { get; set; }

        [DisplayName("Person Address")]
        [Required(ErrorMessage = " Địa chỉ không được để trống! ")]
        public string? PersonAddress { get; set; }

        [DisplayName("Person Age")]
        [Required(ErrorMessage = " Tuổi không được để trống! ")]
        [Range(0, 100, ErrorMessage = " Từ 1 đến 100 ")]
        public int PersonAge { get; set; }

    }
}