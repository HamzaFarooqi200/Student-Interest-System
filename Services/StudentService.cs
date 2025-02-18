using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<LogEntry> GetLogEntries()
        {
            // Assuming you have a DbSet<LogEntry> in your ApplicationDbContext
            return ((DbSet<LogEntry>)_dbContext.LogEntries).ToList();
        }
        public Dictionary<int, int> GetAgeDistribution()
        {
            var today = DateTime.Today;

            var ageDistribution = _dbContext.Student
            .ToDictionary(student => student.ID * 1000 + CalculateAge(student.DOB), student => 1, EqualityComparer<int>.Default); ;

            return ageDistribution;

        }
        private int CalculateAge(DateTime dob)
        {
            // Calculate age based on the current date
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob.AddYears(age) > today)
            {
                age--;
            }
            return age;
        }
        public List<string> GetBottom5Interests()
        {
            var bottom5Interests = _dbContext.Student
            .GroupBy(s => s.Interest)
            .OrderBy(group => group.Count())
            .Take(5)
            .Select(group => group.Key)
            .ToList();

            return bottom5Interests;
        }

        public List<int> GetDeadHours()
        {
            var deadHours = new List<int> { 2, 3, 4, 5, 6 };

            return deadHours;
        }

        public Dictionary<string, int> GetDegreeDistribution()
        {
            var degreeDistribution = _dbContext.Student
            .GroupBy(s => s.DegreeTitle)
            .ToDictionary(g => g.Key, g => g.Count());

            return degreeDistribution;
        }

        public Dictionary<string, int> GetDepartmentDistribution()
        {
            var departmentDistribution = _dbContext.Student
            .GroupBy(s => s.Dept)
            .ToDictionary(g => g.Key, g => g.Count());

            return departmentDistribution;
        }

        public int GetDistinctInterestsCount()
        {
            var distinctInterestsCount = _dbContext.Student
            .Select(s => s.Interest)
            .Distinct()
            .Count();

            return distinctInterestsCount;
        }

        public Dictionary<string, int> GetGenderDistribution()
        {
            var genderDistribution = _dbContext.Student
            .GroupBy(s => s.Gender)
            .ToDictionary(g => g.Key, g => g.Count());

            return genderDistribution;
        }

        public List<string> GetInterests()
        {
            // Implementation to fetch interests from the database
            List<string> interests = _dbContext.Student.Select(s => s.Interest).Distinct().ToList();
            return interests;
        }

        public List<int> GetLast24HoursActivity()
        {
            DateTime twentyFourHoursAgo = DateTime.Now.AddHours(-24).Date; // Include only date part

            var activityCounts = _dbContext.LogEntries
                .Where(entry => entry.Timestamp >= twentyFourHoursAgo) // Filter by date
                .GroupBy(entry => entry.Timestamp.Hour)
                .OrderBy(group => group.Key)
                .Select(group => group.Count())
                .ToList();

            return activityCounts;
        }

        public List<int> GetLast30DaysActivity()
        {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var activityCounts = _dbContext.LogEntries
                .Where(entry => entry.Timestamp >= thirtyDaysAgo)
                .GroupBy(entry => entry.Timestamp.Date)
                .OrderBy(group => group.Key)
                .Select(group => group.Count())
                .ToList();

            return activityCounts;

        }


        public List<int> GetLeastActiveHours()
        {
            var leastActiveHours = _dbContext.LogEntries
            .GroupBy(entry => entry.Timestamp.Hour)
            .OrderBy(group => group.Count())
            .Take(5) // Adjust the number based on your requirement (e.g., 5 least active hours)
            .Select(group => group.Key)
            .ToList();

            return leastActiveHours;
        }

        public List<int> GetMostActiveHours()
        {
            var mostActiveHours = _dbContext.LogEntries
            .GroupBy(entry => entry.Timestamp.Hour)
            .OrderByDescending(group => group.Count())
            .Take(5) // Adjust the number based on your requirement (e.g., 5 most active hours)
            .Select(group => group.Key)
            .ToList();

            return mostActiveHours;
        }

        public Dictionary<string, int> GetProvincialDistribution()
        {
            var provincialDistribution = _dbContext.Student
            .GroupBy(s => s.City)
            .ToDictionary(g => g.Key, g => g.Count());

            return provincialDistribution;
        }

        public StudentsStatusGrid GetStudentsStatusGrid()
        {
            var currentDate = DateTime.Now.Date;

            var studentsStatusGrid = new StudentsStatusGrid
            {
                StudentsCurrentlyStudying = _dbContext.Student.Count(s => s.StartDate <= currentDate && s.EndtDate >= currentDate),
                StudentsRecentlyEnrolled = _dbContext.Student.Count(s => s.StartDate >= currentDate.AddDays(-30)),
                StudentsAboutToGraduate = _dbContext.Student.Count(s => s.EndtDate >= currentDate && s.EndtDate <= currentDate.AddDays(30)),
                StudentsGraduated = _dbContext.Student.Count(s => s.EndtDate < currentDate)
            };

            return studentsStatusGrid;
        }

        public List<int> GetSubmissionChart()
        {
            var submissionChart = _dbContext.Student
            .GroupBy(s => s.StartDate.Date)
            .OrderBy(group => group.Key)
            .Select(group => group.Count())
            .ToList();

            return submissionChart;
        }

        public List<string> GetTop5Interests()
        {
            var top5Interests = _dbContext.Student
            .GroupBy(s => s.Interest)
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key)
            .Take(5)
            .ToList();

            return top5Interests;
        }
    }
}
