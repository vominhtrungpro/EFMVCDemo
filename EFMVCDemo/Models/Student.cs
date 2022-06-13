using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFMVCDemo.Models
{
    public class Student
    {

        // Attribute
        [Key]
        [DisplayName("Student ID")]
        public int StudentId { get; set; }

        [DisplayName("Student Name")]
        [Required(ErrorMessage =" Tên không được để trống! ")]
        [MaxLength(20,ErrorMessage = "Tối đa 20 ký tự")]
        public string? StudentName { get; set; }

        [DisplayName("Student Address")]
        [Required(ErrorMessage =" Địa chỉ không được để trống! ")]
        public string? StudentAddress { get; set; }

        [DisplayName("Student Age")]
        [Required(ErrorMessage =" Tuổi không được để trống! ")]
        [Range(0, 100, ErrorMessage = " Từ 1 đến 100 ")]
        public int StudentAge { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
