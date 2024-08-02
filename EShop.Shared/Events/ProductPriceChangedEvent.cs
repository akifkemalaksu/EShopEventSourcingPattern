using EShop.Shared.Events.Interfaces;

namespace EShop.Shared.Events
{
    public class ProductPriceChangedEvent : IEvent
    {
        public Guid Id { get; set; }

        public required decimal Price
        {
            get; set;
        }
    }
}
