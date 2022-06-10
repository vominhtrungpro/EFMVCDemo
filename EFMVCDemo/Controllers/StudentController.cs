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

        IStudentServices iss;
        public StudentController(IStudentServices _iss)
        {
            iss = _iss;
        }
        public Task<IActionResult> Index()
        {
            return iss.Index();
        }
        public Task<IActionResult> Details(int? id) //chuyển trang chi tiết student
        {


            return iss.Details(id);

        }
        public IActionResult Create() //chuyển trang create
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Create([Bind("StudentId,StudentName,StudentAddress,StudentAge")] Student student) //method add student
        {
            return iss.Create(student);
        }
        public  Task<IActionResult> Edit(int? id) //chuyển trang edit
        {
            return  iss.Edit(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentAddress,StudentAge")] Student student) //method edit
        {

            return iss.Edit(id,student);
        }
        public  Task<IActionResult> Delete(int? id) //chuyển trang delete
        {
            return  iss.Delete(id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  Task<IActionResult> DeleteConfirmed(int id) //method delete
        {
            return  iss.DeleteConfirmed(id);
        }
        
    }
}
