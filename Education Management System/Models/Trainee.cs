using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Education_Management_System.Models
{
    public class Trainee
    {
      
        public int ID { set; get; }
        [MaxLength(50)]
        public string Name { set; get; }
        public string ImageUrl { set; get; }
        [MaxLength (50)]
        public string Address { set; get; }

        public int Grade { set; get; }

        [ForeignKey("Department")]
        public int DepID {get; set;}
        public Department Department { set; get; }

        List<CrsResult> crsResults { set; get; } = new List<CrsResult>();
    }
}
