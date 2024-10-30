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
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            var enrollment = await _context.Enrollments
                .Include(e => e.Course).Include(e => e.Student).ToListAsync();
            return View(enrollment);
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollment/Create
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



        // POST: Enrollment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentID,StudentId,CourseId,Semester,Year")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Enrollments.Add(enrollment);
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

            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID==id);
            if (enrollment == null)
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

            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentID,StudentId,CourseId,Semester,Year")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Enrollments.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentID))
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

            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return BadRequest();
            }
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == id);
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
