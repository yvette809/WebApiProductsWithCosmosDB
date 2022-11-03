using System.Data.SqlTypes;

namespace WebApiProducts.Models
{
    public class ProductEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ArticleNummer { get; set; } 
        public string Name { get; set; } = null!;
        public decimal Price { get; set; } 
        public string Description { get; set; } = null!;
    }
}
