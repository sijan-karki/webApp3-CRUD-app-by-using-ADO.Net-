using System.ComponentModel.DataAnnotations;
namespace WebApp3BySijan.Models
{
    public class Employee
    {
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Name must be 2 to 60 character long.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        internal static void Add(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
