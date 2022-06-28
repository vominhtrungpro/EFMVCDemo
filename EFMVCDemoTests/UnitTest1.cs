using EFMVCDemo;
using EFMVCDemo.Context;
using EFMVCDemo.Controllers;
using EFMVCDemo.Models;

namespace EFMVCDemoTests
{
    public class Tests
    {
        private StudentTest _studentTest;
        MVCContext _db;
        [SetUp]
        public void Setup()
        {
            _studentTest = new StudentTest(_db);
        }

        [Test]
        public void GetSingleStudent_ShouldReturnCorrectStudent()
        {
            var testStudents = GetTestStudens();
            Student s = _studentTest.GetStudent(1);

            Assert.AreEqual(testStudents[0].StudentId, s.StudentId);
        }

        [Test]
        public void GetAllStudent_ShouldReturnAllProducts()
        {
            var countTestStudents = GetTestStudens().Count();
            var countMethodStudent = _studentTest.GetAllStudents().Count();

            Assert.AreEqual(countTestStudents, countMethodStudent);
        }
        private List<Student> GetTestStudens()
        {
            var testStudents = new List<Student>();
            testStudents.Add(new Student { StudentId = 1 });
            return testStudents;
        }
    }
}