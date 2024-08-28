using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int UserId { get; set; }
    }
}
