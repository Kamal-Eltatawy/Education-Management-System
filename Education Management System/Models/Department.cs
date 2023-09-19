using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Education_Management_System.Models
{
    public class Department
    {
        [Key]
        public int ID {set; get; }

        [MaxLength(50)]
        public string Name { set; get; }

        [MaxLength(50)]
        public string Manager {  set; get; }
        public  List<Instructor> Instructors { set; get; } = new List<Instructor>();
        public List<Trainee> Trainees { set; get; } = new List<Trainee>();
        public List <Course> Courses { set; get; } = new List<Course>();

    }
}
