using Education_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Education_Management_System.ViewModel
{
    public class DipartmentsCoursesVM
    {
        public string Name { get; set; }
        public string ImageUrl { set; get; }
        public decimal Salary { set; get; }
        public string Address { set; get; }

        public int DepID { set; get; }
        public int CourseID { set; get; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Course> courses { get; set; } = new List<Course>();
    }
}
