using EFMVCDemo.Context;
using EFMVCDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFMVCDemo.Services
{
    public class StudentServices : IStudentServices
    {
        MVCContext db;
        public StudentServices(MVCContext _db)
        {
            db = _db;
        }
        public void DetailAStudent(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudent()
        {
            return (db.Students.Select(s => s).ToList());
        }
    }
}
