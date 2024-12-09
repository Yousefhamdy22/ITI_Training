using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PearlySoft.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Employee")]
        [Required(ErrorMessage = "You have to provide a valid full name.")]
        [MinLength(15, ErrorMessage = "Full name mustn't be less than 15 characters.")]
        [MaxLength(60, ErrorMessage = "Full name mustn't exceed 60 characters.")]
        public string FullName { get; set; }

        [DisplayName("Occupation")]
        [Required(ErrorMessage = "You have to provide a valid position.")]
        [MinLength(5, ErrorMessage = "Position mustn't be less than 5 characters.")]
        [MaxLength(30, ErrorMessage = "Position mustn't exceed 30 characters.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "You have to provide a valid salary.")]
        [Range(8500, 85_000, ErrorMessage = "Salary must be between 8500 EGP and 85000 EGP.")]
        public decimal Salary { get; set; }

        [DisplayName("National Id")]
        [Required(ErrorMessage = "You have to provide a valid national Id.")]
        [MinLength(14, ErrorMessage = "National Id mustn't be less than 14 digits.")]
        [MaxLength(14, ErrorMessage = "National Id mustn't exceed 14 digits.")]
        public string NationalId { get; set; }

        [DisplayName("Phone No")]
        [RegularExpression("^01\\d{9}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNo { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [NotMapped]
        [Compare("Email", ErrorMessage = "Email and confirm email do not match.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Secret Code")]
        [MinLength(4, ErrorMessage = "Secret Code mustn't be less than 4 characters.")]
        [DataType(DataType.Password)]
        public string SecretCode { get; set; }

        [DisplayName("Confirm Secret Code")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("SecretCode", ErrorMessage = "Secret code and confirm secret code do not match.")]
        public string ConfirmSecretCode { get; set; }

        [DisplayName("Is Available")]
        public bool IsActive { get; set; }

        [Range(0, 100, ErrorMessage = "Appraisal must be between 0 and 100")]
        public byte Appraisal { get; set; }

        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DisplayName("Attendance Time")]
        [DataType(DataType.Time)]
        public DateTime AttendanceTime { get; set; }

        [DisplayName("Hiring Date and Time")]
        public DateTime HiringDateTime { get; set; }

        [ValidateNever]
        public string? Notes {  get; set; }

        [DisplayName("Department")]
        //Foreign Key Property
        [Range(1, int.MaxValue, ErrorMessage = "Select a valid department.")]
        public int DepartmentId { get; set; }

        //Navigation Property
        [ValidateNever]
        public Department Department { get; set; }
        [ValidateNever]
        [DisplayName("Image")]
        public string? ImagePath { get; set; }

        [NotMapped]
        [ValidateNever]
        public IFormFile ImageFile { get; set; }
    }
}
