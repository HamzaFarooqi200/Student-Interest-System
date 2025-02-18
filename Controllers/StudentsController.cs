using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ApplicationDbContext _context;

        public StudentsController(IStudentService studentService, ApplicationDbContext context)
        {
            _studentService = studentService;
            _context = context;
        }

        // StudentsController.cs
        public IActionResult Dashboard()
        {
            var logEntry = new LogEntry
            {
                UserId = User.Identity.Name, // Assuming the user ID is stored in the Name property
                Timestamp = DateTime.Now,
                ActivityType = "ClickDashboard",
            };

            _context.LogEntries.Add(logEntry);
            _context.SaveChanges();
            // Retrieve data for other widgets
            var distinctInterests = _studentService.GetDistinctInterestsCount();
            var provincialDistribution = _studentService.GetProvincialDistribution();
            var submissionChart = _studentService.GetSubmissionChart();
            var ageDistribution = _studentService.GetAgeDistribution();
            var departmentDistribution = _studentService.GetDepartmentDistribution();
            var degreeDistribution = _studentService.GetDegreeDistribution();
            var genderDistribution = _studentService.GetGenderDistribution();
            var last30DaysActivity = _studentService.GetLast30DaysActivity();
            var last24HoursActivity = _studentService.GetLast24HoursActivity();
            var studentsStatusGrid = _studentService.GetStudentsStatusGrid();
            var mostActiveHours = _studentService.GetMostActiveHours();
            var leastActiveHours = _studentService.GetLeastActiveHours();
            var deadHours = _studentService.GetDeadHours();

            var model = new DashboardViewModel
            {
                Top5Interests = _studentService.GetTop5Interests(),
                Bottom5Interests = _studentService.GetBottom5Interests(),
                DistinctInterests = distinctInterests,
                ProvincialDistribution = provincialDistribution,
                SubmissionChart = submissionChart,
                AgeDistribution = ageDistribution,
                DepartmentDistribution = departmentDistribution,
                DegreeDistribution = degreeDistribution,
                GenderDistribution = genderDistribution,
                Last30DaysActivity = last30DaysActivity,
                Last24HoursActivity = last24HoursActivity,
                StudentsCurrentlyStudying = studentsStatusGrid.StudentsCurrentlyStudying,
                StudentsRecentlyEnrolled = studentsStatusGrid.StudentsRecentlyEnrolled,
                StudentsAboutToGraduate = studentsStatusGrid.StudentsAboutToGraduate,
                StudentsGraduated = studentsStatusGrid.StudentsGraduated,
                MostActiveHours = mostActiveHours,
                LeastActiveHours = leastActiveHours,
                DeadHours = deadHours,
                // Add other data to corresponding properties
            };

            return View(model);
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            List<string> interests = _studentService.GetInterests();

            // Pass the interests to the view
            ViewData["Interests"] = interests;

            // Create a new empty student model and pass it to the view
            return View(new Student());
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,RollNumber,Email,Gender,DOB,City,Interest,Dept,DegreeTitle,Subject,StartDate,EndtDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,RollNumber,Email,Gender,DOB,City,Interest,Dept,DegreeTitle,Subject,StartDate,EndtDate")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
        [HttpGet]
        public IActionResult GetProvincialData()
        {
            var data = _context.Student
                .GroupBy(s => s.City)
                .Select(g => g.Count())
                .ToList();

            return Json(data);
        }

        [HttpGet]
        public IActionResult GetSubmissionData()
        {
            // Modify this to get the daily submission data
            var data = new List<int> { 10, 20, 15, 25, 18 };

            return Json(data);
        }

        [HttpGet]
        public IActionResult GetAgeDistributionData()
        {
            var today = DateTime.Today;
            var data = _context.Student
                .Select(s => today.Year - s.DOB.Year - (s.DOB > today.AddYears(-s.DOB.Year) ? 1 : 0))
                .GroupBy(age => age / 10)
                .OrderBy(group => group.Key)
                .Select(group => group.Count())
                .ToList();

            return Json(data);
        }

        [HttpGet]
        public IActionResult GetDepartmentData()
        {
            var data = _context.Student
                .GroupBy(s => s.Dept)
                .Select(g => g.Count())
                .ToList();

            return Json(data);
        }
        public DbSet<LogEntry> LogEntries { get; set; }
    }
}
