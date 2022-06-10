using EFMVCDemo.Context;
using EFMVCDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFMVCDemo.Controllers
{
    public class StudentController : Controller
    {
        MVCContext db;
        public StudentController(MVCContext _db)
        {
            db = _db;
        }

        //IStudentServices iss;
        //public StudentController(IStudentServices _iss)
        //{
        //    iss = _iss;
        //}
        public async Task<IActionResult> Index()
        {
            return db.Students != null ?
                        View(await db.Students.ToListAsync()) :
                        Problem("Entity set 'MVCContext.Teachers'  is null.");
        }
        public async Task<IActionResult> Details(int? id) //chuyển trang chi tiết student
        {
            if (id == null || db.Students == null)
            {
                return NotFound();
            }

            var student = await db.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);

        }
        public IActionResult Create() //chuyển trang create
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentAddress,StudentAge")] Student student) //method add student
        {
            if (ModelState.IsValid)
            {
                db.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        public async Task<IActionResult> Edit(int? id) //chuyển trang edit
        {
            if (id == null || db.Students == null)
            {
                return NotFound();
            }

            var student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentAddress,StudentAge")] Student student) //method edit
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(student);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        public async Task<IActionResult> Delete(int? id) //chuyển trang delete
        {
            if (id == null || db.Students == null)
            {
                return NotFound();
            }

            var student = await db.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) //method delete
        {
            if (db.Students == null)
            {
                return Problem("Entity set 'MVCContext.Students'  is null.");
            }
            var student = await db.Students.FindAsync(id);
            if (student != null)
            {
                db.Students.Remove(student);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool StudentExists(int id)
        {
            return (db.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
