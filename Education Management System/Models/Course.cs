using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Education_Management_System.Models
{
    public class Course
    {
        public int ID { set; get; }
        [MaxLength(50)]
        public string Name { set; get; }
        public int Degree { set; get; }
        public int MinDegree { set; get; }

        [ForeignKey("Department")]
        public int DepID { set; get; }
        public Department? Department { set; get; }

       public  List<Instructor>? Instructors { set; get; } = new List<Instructor>();
       public  List<CrsResult>? crsResults { get; set; } = new List<CrsResult>();
    }
}
