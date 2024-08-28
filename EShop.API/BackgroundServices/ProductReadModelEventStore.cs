
using EShop.API.Contexts;
using EShop.API.EventStores;
using EShop.API.Models;
using EShop.Shared.Events;
using EShop.Shared.Events.Interfaces;
using EventStore.ClientAPI;
using Microsoft.OpenApi.Writers;
using System.Text;
using System.Text.Json;

namespace EShop.API.BackgroundServices
{
    public class ProductReadModelEventStore(
        IEventStoreConnection _eventStoreConnection,
        ILogger<ProductReadModelEventStore> _logger,
        IServiceProvider _service
        ) : BackgroundService
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _eventStoreConnection.ConnectToPersistentSubscriptionAsync(ProductStream.StreamName, ProductStream.GroupName, EventAppeal, autoAck: false);
        }

        private async Task EventAppeal(EventStorePersistentSubscriptionBase arg1, ResolvedEvent arg2)
        {
            _logger.LogInformation("The message is processing.");

            var type = Type.GetType($"{Encoding.UTF8.GetString(arg2.Event.Metadata)}, {typeof(IEvent).Assembly.GetName()}");

            var eventData = Encoding.UTF8.GetString(arg2.Event.Data);

            var @event = JsonSerializer.Deserialize(eventData, type);

            using var scope = _service.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            Product product = null;
            switch (@event)
            {
                case ProductCreatedEvent productCreatedEvent:

                    product = new Product()
                    {
                        Name = productCreatedEvent.Name,
                        Id = productCreatedEvent.Id,
                        Price = productCreatedEvent.Price,
                        Stock = productCreatedEvent.Stock,
                        UserId = productCreatedEvent.UserId
                    };
                    context.Products.Add(product);
                    break;

                case ProductNameChangedEvent productNameChangedEvent:

                    product = context.Products.Find(productNameChangedEvent.Id);
                    if (product != null)
                    {
                        product.Name = productNameChangedEvent.Name;
                    }
                    break;

                case ProductPriceChangedEvent productPriceChangedEvent:
                    product = context.Products.Find(productPriceChangedEvent.Id);
                    if (product != null)
                    {
                        product.Price = productPriceChangedEvent.Price;
                    }
                    break;

                case ProductDeletedEvent productDeletedEvent:
                    product = context.Products.Find(productDeletedEvent.Id);
                    if (product != null)
                    {
                        context.Products.Remove(product);
                    }
                    break;
            }

            await context.SaveChangesAsync();

            arg1.Acknowledge(arg2.Event.EventId);
        }
    }
}
