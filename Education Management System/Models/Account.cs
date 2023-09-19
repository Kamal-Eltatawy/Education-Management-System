using System.ComponentModel.DataAnnotations;


namespace Education_Management_System.Models
{
    public class Account
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string UserName { set; get; }
        [MaxLength(50)]
        public string Password { set; get; }
    }
}
