using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFMVCDemo.Models
{
    public class Subject
    {
        [Key]
        [DisplayName("Subject ID")]
        public int SubjectId { get; set; }

        [DisplayName("Subject Name")]
        [Required(ErrorMessage = " Tên không được để trống! ")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 ký tự")]
        public string? SubjectName { get; set; }

        [DisplayName("Subject Details")]
        [Required(ErrorMessage = " Chi tiết môn không được để trống! ")]
        public string? SubjectDetail { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
