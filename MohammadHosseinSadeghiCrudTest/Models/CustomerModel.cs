using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadHosseinSadeghiCrudTest.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[^0-9]", ErrorMessage = "PhoneNumber must be numeric")]

        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(16)]
        [MinLength(16)]
        [RegularExpression("[^0-9]", ErrorMessage = "BankAccountNumber must be numeric")]
        public string BankAccountNumber { get; set; }

      
    }
}
