using EShop.Shared.Events.Interfaces;

namespace EShop.Shared.Events
{
    public class ProductNameChangedEvent : IEvent
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
