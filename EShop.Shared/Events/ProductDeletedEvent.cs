using EShop.Shared.Events.Interfaces;

namespace EShop.Shared.Events
{
    public class ProductDeletedEvent : IEvent
    {
        public Guid Id { get; set; }
    }
}
