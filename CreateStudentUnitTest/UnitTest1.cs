using EFMVCDemo.Context;
using EFMVCDemo.Controllers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CreateStudentUnitTest
{
    public class Tests
    {
        private DbContextOptions<MVCContext> _db;
        private StudentController _studentcontroller;
        public Tests(DbContext db)
        {
            var dbName = $"Data Source=PC-TRUNGVO\\SQLEXPRESS;Initial Catalog=EFDataDemo;Integrated Security=True";
            _db = new DbContextOptionsBuilder<MVCContext>()
                .UseSqlServer(dbName)
                .Options;
        }
        [SetUp]
        public void Setup()
        {
            _studentcontroller = new StudentController(_db);
        }
        [Test]
        public void IndexGetsAllStudent()
        {
            //Arrange 
            var fakeProductRepo = new FakeProductsRepository();
            var productsController = new ProductsController(fakeProductRepo);

            //Act
            var result = productsController.Index(1) as ViewResult;

            //Assert
            var model = result.Model as List<Product>;
            Assert.AreEqual(2, model.Count);
        }
    }
}