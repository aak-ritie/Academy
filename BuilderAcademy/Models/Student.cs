using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BuilderAcademy.Models
{
    public class Student
    {
        [Key]//dataAnnotation
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Address")]
        [Range(1, 100, ErrorMessage = "Display order must be between 1 to 100")]
        public string Address { get; set; }

    }
}
