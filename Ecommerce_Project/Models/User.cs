using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.Models
{
    public class User
    {
        [Key]
        public int Uid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string UserName { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Confirmpwd { get; set; }
        [Required]

        public string Gender { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]


        public string PhoneNumber { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public int Pincode { get; set; }
        [Required]

        public int RoleId { get; set; }

    }
}
