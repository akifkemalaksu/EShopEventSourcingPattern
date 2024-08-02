namespace EShop.API.Dtos
{
    public class ChangeProductNameDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
