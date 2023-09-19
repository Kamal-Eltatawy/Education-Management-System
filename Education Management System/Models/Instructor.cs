using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Education_Management_System.Models
{
    public class Instructor
    {   
        public int ID { set; get; }
        [MaxLength(50)]
        public string Name { set; get; }
        public string ImageUrl { set; get; }
        [Column(TypeName = "Money")]
        public decimal Salary { set; get; }
        [MaxLength(50)]
        public string Address { set; get; }

        [ForeignKey("Department")]
        public int DepID { set; get; }
        public Department Department { set; get; }

        [ForeignKey("Course")]
        public int CourseID { set; get; }
        public Course Course { set; get; }
    }
}
