using EFMVCDemo.Context;
using EFMVCDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFMVCDemo.Services
{
    public class StudentServices : Controller, IStudentServices
    {
        MVCContext db;
        public StudentServices(MVCContext _db)
        {
            db = _db;
        }
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Create([Bind(new[] { "StudentId,StudentName,StudentAddress,StudentAge" })] Student student)
        {



            if (ModelState.IsValid)
            {
                db.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
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

        public async Task<IActionResult> DeleteConfirmed(int id)
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

        public async Task<IActionResult> Details(int? id)
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

        public async Task<IActionResult> Edit(int? id)
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

        public async Task<IActionResult> Edit(int id, [Bind(new[] { "StudentId,StudentName,StudentAddress,StudentAge" })] Student student)
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

        public async Task<IActionResult> Index()
        {
            return db.Students != null ?
                        View(await db.Students.ToListAsync()) :
                        Problem("Entity set 'MVCContext.Teachers'  is null.");
        }
        private bool StudentExists(int id)
        {
            return (db.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
