using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Division { get; set; }
        public string? Role { get; set; }
    }
}