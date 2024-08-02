namespace EShop.API.Dtos
{
    public class ChangeProductPriceDto
    {
        public Guid Id { get; set; }

        public required decimal Price { get; set; }

    }
}
