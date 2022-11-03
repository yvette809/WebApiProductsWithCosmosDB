namespace WebApiProducts.Models
{
    public class ProductRequest
    {
        public int ArticleNummer { get; set; } 
        public string Name { get; set; } = null!;
        public decimal Price { get; set; } 
        public string Description { get; set; } = null!;
    }
}
