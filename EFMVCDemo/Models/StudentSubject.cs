namespace EFMVCDemo.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student student { get; set; }

        public int SubjectId { get; set; }

        public Subject subject { get; set; }
    }
}
