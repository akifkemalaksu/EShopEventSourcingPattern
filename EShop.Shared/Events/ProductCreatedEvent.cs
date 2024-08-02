using EShop.Shared.Events.Interfaces;

namespace EShop.Shared.Events
{
    public class ProductCreatedEvent : IEvent
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required decimal Price { get; set; }

        public required int Stock { get; set; }

        public required int UserId { get; set; }
    }
}
