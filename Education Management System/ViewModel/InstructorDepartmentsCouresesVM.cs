using Education_Management_System.Models;

namespace Education_Management_System.ViewModel
{
    public class InstructorDepartmentsCouresesVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { set; get; }
        public decimal Salary { set; get; }
        public string Address { set; get; }

        public int DepID {  get; set; }
        List<Department > Departments { get; set; } = new List<Department>();

        public int CourseID { get; set; }
        List<Course> Courses { get; set; } = new List<Course>();

    }
}
