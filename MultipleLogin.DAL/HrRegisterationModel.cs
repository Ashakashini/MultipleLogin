using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleLogin.DAL
{
    public class HrRegisterationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateofBirth { get; set; }
        public string Department { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public string City { get; set; }
        public string state { get; set; }

        public string Avathar { get; set; }

    }
}
