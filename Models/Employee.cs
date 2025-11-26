using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi")]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string? Division { get; set; }

        [Required]
        public string? Role { get; set; }
    }
}