using EShop.API.Dtos;
using EShop.Shared.Events;
using EventStore.ClientAPI;
using Mapster;

namespace EShop.API.EventStores
{
    public class ProductStream : AbstractStream
    {
        public static readonly string StreamName = "ProductStream";

        public ProductStream(IEventStoreConnection eventStoreConnection) : base(StreamName, eventStoreConnection)
        {
        }

        public void Created(CreateProductDto createProduct)
        {
            var productCreatedEvent = createProduct.Adapt<ProductCreatedEvent>();
            productCreatedEvent.Id = Guid.NewGuid();
            Events.AddLast(productCreatedEvent);
        }

        public void NameChanged(ChangeProductNameDto changeProductName)
        {
            var productNameChangedEvent = changeProductName.Adapt<ProductNameChangedEvent>();
            productNameChangedEvent.Id = Guid.NewGuid();
            Events.AddLast(productNameChangedEvent);
        }

        public void PriceChanged(ChangeProductPriceDto changeProductPrice)
        {
            var productPriceChangedEvent = changeProductPrice.Adapt<ProductPriceChangedEvent>();
            productPriceChangedEvent.Id = Guid.NewGuid();
            Events.AddLast(productPriceChangedEvent);
        }

        public void Deleted(Guid id)
        {
            var productDeletedEvent = new ProductDeletedEvent
            {
                Id = id
            };
            Events.AddLast(productDeletedEvent);
        }
    }
}
