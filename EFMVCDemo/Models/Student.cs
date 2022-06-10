using System.ComponentModel.DataAnnotations;

namespace EFMVCDemo.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        public string StudentAddress { get; set; }

        public int StudentAge { get; set; }
    }
}
