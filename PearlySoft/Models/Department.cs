using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace PearlySoft.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to provide a valid name.")]
        [MinLength(2, ErrorMessage = "Name mustn't be less than 2 characters.")]
        [MaxLength(20, ErrorMessage = "Name mustn't exceed 20 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You have to provide a valid description.")]
        [MinLength(5, ErrorMessage = "Description mustn't be less than 5 characters.")]
        [MaxLength(50, ErrorMessage = "Description mustn't exceed 50 characters.")]
        public string Description { get; set; }

        //Navigation Property
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }
    }
}
