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
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string DateofBirth { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Avathar { get; set; }

        [Required]
        public string Resume { get; set; }

        [Required]
        public string EducationalCertificate {get; set;}

        [Required]
        public string Experience { get; set;}

        [Required]
        public string IDProof {  get; set; }

        [Required]
        public string YearofPassout { get; set; }

        [Required]
        public string Category {  get; set; }

    }
}
