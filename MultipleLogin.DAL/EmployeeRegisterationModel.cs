using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleLogin.DAL
{
    public class EmployeeRegisterationModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }  

        [Required]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }   

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public IFormFile Avathar { get; set; }  

        [Required]
        public IFormFile Resume { get; set; }

        [Required]
        public IFormFile EducationalCertificate { get; set; }

        [Required]
        public string Experience { get; set; }

        [Required]
        public IFormFile IDProof { get; set; }

        [Required]
        public string YearofPassout { get; set; }  

        [Required]
        public string Category { get; set; }
    }
}
