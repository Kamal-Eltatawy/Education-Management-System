namespace Education_Management_System.ViewModel
{
    public class StudentDegreeNameColorCourses
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Color { get; set; }
        public List<CoursesVM> courses { get; set; } = new List<CoursesVM>();

    }
}
