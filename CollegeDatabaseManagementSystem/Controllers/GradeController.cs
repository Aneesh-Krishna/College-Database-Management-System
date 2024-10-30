using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeDatabaseManagementSystem.Data;
using CollegeDatabaseManagementSystem.Models;

namespace CollegeDatabaseManagementSystem.Controllers
{
    public class GradeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Grade
        public async Task<IActionResult> Index()
        {
            var grade = await _context.Grades.Include(g => g.Course).Include(g => g.Student).ToListAsync();
            return View(grade);
        }

        // GET: Grade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.Course)
                .Include(g => g.Student)
                .FirstOrDefaultAsync(m => m.GradeID == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grade/Create
        public IActionResult Create()
        {
            var students = _context.Students
                .Select(s => new
                {
                    s.StudentId,
                    FullNameWithEnrollment = $"{s.FirstName} {s.LastName} ({s.EnrollmentNumber})"
                })
                .ToList();

            ViewData["StudentId"] = new SelectList(students, "StudentId", "FullNameWithEnrollment");

            // Initialize an empty course list initially
            ViewData["CourseId"] = new SelectList(Enumerable.Empty<SelectListItem>());

            return View();
        }

        // POST: Grade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeID,StudentId,CourseId,GradeValue")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _context.Grades.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var students = _context.Students
               .Select(s => new
               {
                   s.StudentId,
                   FullNameWithEnrollment = $"{s.FirstName} {s.LastName} ({s.EnrollmentNumber})"
               })
               .ToList();

            ViewData["StudentId"] = new SelectList(students, "StudentId", "FullNameWithEnrollment");

            // Initialize an empty course list initially
            ViewData["CourseId"] = new SelectList(Enumerable.Empty<SelectListItem>());

            return View(grade);
        }

        // GET: Grade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades.FirstOrDefaultAsync(g => g.GradeID==id);
            if (grade == null)
            {
                return NotFound();
            }

            var students = _context.Students
               .Select(s => new
               {
                   s.StudentId,
                   FullNameWithEnrollment = $"{s.FirstName} {s.LastName} ({s.EnrollmentNumber})"
               })
               .ToList();

            ViewData["StudentId"] = new SelectList(students, "StudentId", "FullNameWithEnrollment");

            // Initialize an empty course list initially
            ViewData["CourseId"] = new SelectList(Enumerable.Empty<SelectListItem>());

            return View(grade);
        }

        // POST: Grade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradeID,StudentId,CourseId,GradeValue")] Grade grade)
        {
            if (id != grade.GradeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Grades.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.GradeID))
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

            var students = _context.Students
               .Select(s => new
               {
                   s.StudentId,
                   FullNameWithEnrollment = $"{s.FirstName} {s.LastName} ({s.EnrollmentNumber})"
               })
               .ToList();

            ViewData["StudentId"] = new SelectList(students, "StudentId", "FullNameWithEnrollment");

            // Initialize an empty course list initially
            ViewData["CourseId"] = new SelectList(Enumerable.Empty<SelectListItem>());

            return View(grade);
        }

        // GET: Grade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.Course)
                .Include(g => g.Student)
                .FirstOrDefaultAsync(m => m.GradeID == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.GradeID == id);
        }

        public IActionResult GetCoursesByStudent(int studentId)
        {
            var student = _context.Students.Include(s => s.Department).FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                return Json(new SelectList(Enumerable.Empty<SelectListItem>()));
            }

            var courses = _context.Courses
                .Where(c => c.DepartmentId == student.DepartmentId)
                .Select(c => new { c.CourseId, c.CourseName })
                .ToList();

            return Json(new SelectList(courses, "CourseId", "CourseName"));
        }
    }
}
