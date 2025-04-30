using Microsoft.AspNetCore.Mvc;

namespace COMP003B.LectureActivity6.Controllers
{
    public class StudentsController : Controller
    {
       

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefualtAsync(mbox => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Courses = from s in _context.Students
                              join e in _context.Enrollments on s.StudentId equals e.StudentId
                              join c in _context.Courses on e.CourseId equals c.CourseId
                              where s.StudentId == id
                              select c;
            return View(student);
        }
    }
}
