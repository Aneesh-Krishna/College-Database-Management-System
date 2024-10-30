using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeDatabaseManagementSystem.Data;
using CollegeDatabaseManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace CollegeDatabaseManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attendance
        public async Task<IActionResult> Index()
        {
            var attendance = await _context.Attendances.Include(a => a.Course).Include(a => a.Student).ToListAsync();
            return View(attendance);
        }

        // GET: Attendance/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Course)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendance/Create
        [Authorize(Roles = "Admin")]
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


        // POST: Attendance/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceId,StudentId,CourseId,Date,Status")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Attendances.Add(attendance);
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

            return View(attendance);
        }

        // GET: Attendance/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId==id);
            if (attendance == null)
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


            return View(attendance);
        }

        // POST: Attendance/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceId,StudentId,CourseId,Date,Status")] Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Attendances.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AttendanceId))
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

            return View(attendance);
        }

        // GET: Attendance/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Course)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendance/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId==id);
            if (attendance == null)
            {
                return BadRequest();
            }
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendances.Any(e => e.AttendanceId == id);
        }

        public IActionResult GetEnrolledCourses(int studentId)
        {
            var enrolledCourses = _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Select(e => new
                {
                    e.Course.CourseId,
                    e.Course.CourseName
                })
                .ToList();

            return Json(new SelectList(enrolledCourses, "CourseId", "CourseName"));
        }

    }
}
