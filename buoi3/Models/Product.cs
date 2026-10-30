namespace b3_chuchinhnguyen.Models
{
    public class Product
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
        public String Description { get; set; } = string.Empty;
        // Foreign key to Category
        public int CategoryID { get; set; }
        // Navigation property to Category
        public category? category { get; set; }
    }
}
