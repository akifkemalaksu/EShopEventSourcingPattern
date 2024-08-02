namespace EShop.API.Dtos
{
    public class CreateProductDto
    {
        public required int UserId { get; set; }

        public required string Name { get; set; }

        public required int Stock { get; set; }

        public required decimal Price { get; set; }
    }
}
