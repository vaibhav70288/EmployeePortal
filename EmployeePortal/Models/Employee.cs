using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class Employee
    {
        [Key]
        public int? EmployeeId { get; set; }

        [Required]
        [StringLength(maximumLength: 50,ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100,ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }

        [DisplayName("Contact No")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The Mobile number must be 10 digits long.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The Mobile number must be a 10-digit number.")]
        [Required]
        public string Mobile { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DOB { get; set; }
    }
}