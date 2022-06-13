using EFMVCDemo.Context;
using EFMVCDemo.Models;
using EFMVCDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFMVCDemo.Controllers
{
    public class StudentController : Controller
    {
        //MVCContext db;
        //public StudentController(MVCContext _db)
        //{
        //    db = _db;
        //}

        IStudentServices istudentservices;
        public StudentController(IStudentServices _istudentservices)
        {
            istudentservices = _istudentservices;
        }
        public Task<IActionResult> Index()
        {
            return istudentservices.Index();
        }
        //chuyển trang chi tiết student
        public Task<IActionResult> Details(int? id) 
        {


            return istudentservices.Details(id);

        }
        //chuyển trang create
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //method add student
        public Task<IActionResult> Create([Bind("StudentId,StudentName,StudentAddress,StudentAge")] Student student) 
        {
            return istudentservices.Create(student);
        }
        //chuyển trang edit
        public Task<IActionResult> Edit(int? id) 
        {
            return istudentservices.Edit(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //method edit
        public Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentAddress,StudentAge")] Student student) 
        {

            return istudentservices.Edit(id,student);
        }
        //chuyển trang delete
        public Task<IActionResult> Delete(int? id) 
        {
            return istudentservices.Delete(id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //method delete
        public Task<IActionResult> DeleteConfirmed(int id) 
        {
            return istudentservices.DeleteConfirmed(id);
        }
        
    }
}
