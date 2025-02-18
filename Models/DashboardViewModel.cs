using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class DashboardViewModel
    {
        public List<string> Top5Interests { get; set; }
        public List<string> Bottom5Interests { get; set; }
        public int DistinctInterests { get; set; }

        // Add properties for other widgets
        public Dictionary<string, int> ProvincialDistribution { get; set; }
        public List<int> SubmissionChart { get; set; }
        public Dictionary<int, int> AgeDistribution { get; set; }
        public Dictionary<string, int> DepartmentDistribution { get; set; }
        public Dictionary<string, int> DegreeDistribution { get; set; }
        public Dictionary<string, int> GenderDistribution { get; set; }
        public List<int> Last30DaysActivity { get; set; }
        public List<int> Last24HoursActivity { get; set; }

        // Students Status Grid
        public int StudentsCurrentlyStudying { get; set; }
        public int StudentsRecentlyEnrolled { get; set; }
        public int StudentsAboutToGraduate { get; set; }
        public int StudentsGraduated { get; set; }

        // Most, Least, Dead Active Hours
        public List<int> MostActiveHours { get; set; }
        public List<int> LeastActiveHours { get; set; }
        public List<int> DeadHours { get; set; }
    
    }
}
