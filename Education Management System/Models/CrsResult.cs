using System.ComponentModel.DataAnnotations.Schema;


namespace Education_Management_System.Models
{
    public class CrsResult
    {
        public int ID { set; get; }
        public int Degree { set; get; }

        [ForeignKey("Trainee")]
        public int TraineeID { set; get; }
        public Trainee Trainee { set; get; }

        [ForeignKey("Course")]
        public int CourseID { set; get; }
        public Course Course { set; get; }
    }
}
