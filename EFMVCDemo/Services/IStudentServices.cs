using EFMVCDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFMVCDemo.Services
{
    public interface IStudentServices
    {
        public Task<IActionResult> Index();

        public Task<IActionResult> Details(int? id);

        public IActionResult Create();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Create([Bind("StudentId,StudentName,StudentAddress,StudentAge")] Student student);

        public Task<IActionResult> Edit(int? id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentAddress,StudentAge")] Student student);

        public Task<IActionResult> Delete(int? id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> DeleteConfirmed(int id);



    }
}
