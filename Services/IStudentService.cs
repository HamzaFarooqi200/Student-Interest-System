// IStudentService.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IStudentService
    {
        List<string> GetInterests();

        List<string> GetTop5Interests();

        List<string> GetBottom5Interests();

        int GetDistinctInterestsCount();

        Dictionary<string, int> GetProvincialDistribution();

        List<int> GetSubmissionChart();

        Dictionary<int, int> GetAgeDistribution();

        Dictionary<string, int> GetDepartmentDistribution();

        Dictionary<string, int> GetDegreeDistribution();

        Dictionary<string, int> GetGenderDistribution();

        List<int> GetLast30DaysActivity();

        List<int> GetLast24HoursActivity();

        StudentsStatusGrid GetStudentsStatusGrid();

        List<int> GetMostActiveHours();

        List<int> GetLeastActiveHours();

        List<int> GetDeadHours();
        List<LogEntry> GetLogEntries();

        // Add other methods as needed
    }

    public class StudentsStatusGrid
    {
        public int StudentsCurrentlyStudying { get; set; }
        public int StudentsRecentlyEnrolled { get; set; }
        public int StudentsAboutToGraduate { get; set; }
        public int StudentsGraduated { get; set; }
    }
}
