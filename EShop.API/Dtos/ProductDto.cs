namespace EShop.API.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public required int UserId { get; set; }

        public required string Name { get; set; }

        public required int Stock { get; set; }

        public required decimal Price { get; set; }
    }
}
