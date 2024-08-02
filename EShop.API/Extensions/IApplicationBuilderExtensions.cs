using EventStore.ClientAPI;

namespace EShop.API.Extensions
{
    public static class IHostApplicationBuilderExtensions
    {
        public static IHostApplicationBuilder AddEventStore(this IHostApplicationBuilder builder)
        {
            var connection = EventStoreConnection.Create(connectionString: builder.Configuration.GetConnectionString("EventStore"));

            connection.ConnectAsync().Wait();

            builder.Services.AddSingleton(connection);

            using var logFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddConsole();
            });
            var logger = logFactory.CreateLogger<Program>();

            connection.Connected += (sender, args) =>
            {
                logger.LogInformation("EventStore connection established at {time}", DateTime.Now);
            };

            connection.ErrorOccurred += (sender, args) =>
            {
                logger.LogError(args.Exception, "Error occurred in EventStore at {time}: {message}", DateTime.Now, args.Exception.Message);
            };

            return builder;
        }
    }
}
