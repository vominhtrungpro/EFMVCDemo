using EFMVCDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFMVCDemo.Services
{
    public interface IStudentServices
    {
        public List<Student> GetAllStudent();

        public void DetailAStudent(int? id);

    }
}
