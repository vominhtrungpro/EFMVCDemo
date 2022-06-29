using EFMVCDemo.Context;
using EFMVCDemo.Models;
using EFMVCDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EFMVCDemoTest
{
    public class StudentServicesTests : DbContext
    {
        
        StudentServices _studentservices;
        MVCContext _context;
        [SetUp]
        public void Setup()
        {
            var options =
            new DbContextOptionsBuilder<DbContext>()
                .UseSqlServer("EFConnection")
                .Options;
            _context = new MVCContext(options);
            _studentservices = new StudentServices(_context);
        }

        [Test]
        [TestCase( "A", "VN", 123)]
        [TestCase( "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "VN", 23)]
        [TestCase( "A", "VN", 23)]
        public void CreateStudent( string name, string address, int age)
        {
            
            var student = new Student()
            {
                StudentAddress = address,
                StudentName = name,
                StudentAge = age
            };
            var create = _studentservices.Create(student);

            Assert.That(student.StudentAge, Is.AtMost(100));
            Assert.That(student.StudentName.Count, Is.AtMost(10));
            Assert.That(create, Is.Not.Null);

        }
    }
}