using System.ComponentModel.DataAnnotations;

namespace b3_chuchinhnguyen.Models
{
    public class category
    {
        [Required(ErrorMessage = "ID is required")]
        public int ID { get; set;}
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage =" Name cannot exceed 100 characters or 100 characters or lower than 2 characters")]
        public string? Name { get; set;} = String.Empty;
        // Navigation property to Product
        public List<Product>? Products { get; set;}
    }
}
