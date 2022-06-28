using EFMVCDemo.Context;
using EFMVCDemo.Models;
using EFMVCDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFMVCDemo.NUnitTest
{
    [TestFixture]
    public class Tests
    {
        private StudentServices _studentservices;
        MVCContext _context;
        [SetUp]
        public void Setup()
        {
            _studentservices = new StudentServices(_context);
        }

        [Test]
        public void Test1_Create()
        {
            var student = new Student();
            student.StudentId = 1;
            student.StudentName = "A";
            student.StudentAddress = "VN";
            student.StudentAge = 23;
            var create = _studentservices.Create(student);
            Assert.That(create, Is.Not.Null);
        }

        [Test]
        public void Test2_Create()
        {
            var teststudent = GetTestStudens();
            var teststudent2 = _studentservices.Create(teststudent);
            Assert.That(teststudent2, Is.Not.Null);
        }

        private Student GetTestStudens()
        {
            var testStudents = new Student();
            testStudents.StudentId = 1;
            testStudents.StudentName = "";
            testStudents.StudentAddress = "";
            testStudents.StudentAge = 1;
            return testStudents;
        }
    }
}