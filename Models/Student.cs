
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public string Interest { get; set; }
        public string Dept { get; set; }
        public string DegreeTitle { get; set; }
        public string Subject { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndtDate { get; set; }
        public Student()
        {

        }
    }
}
