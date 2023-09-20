using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.Models
{
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]

        public int Cid { get; set; }
        [Required]
        public string? Cname { get; set; }
    }
}
