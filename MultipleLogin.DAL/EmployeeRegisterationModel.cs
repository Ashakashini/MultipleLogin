using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        
        public IFormFile Avathar { get; set; }  

        public string AvatarFileName { get; set; }

        [NotMapped]
        public IFormFile Resume { get; set; }

        public string ResumeFileName { get; set; }

        [NotMapped] 
        public IFormFile EducationalCertificate { get; set; }

        public string EducationalCertificateFileName { get; set; }

        [Required]
        public string Experience { get; set; }

        [NotMapped] 
        public IFormFile IDProof { get; set; }

        public string IDProofFileName { get; set; } 

        [Required]
        public string YearofPassout { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
