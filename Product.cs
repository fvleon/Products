using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI
{
    public class Product
    {
        [Key]
        public int idProduct { get; set; }
        public string productName { get; set; } = string.Empty;
        public string productDescription { get; set; } = string.Empty;

    }
}
