using System.ComponentModel.DataAnnotations;

namespace MicroserviceProducts.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Descripation { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}