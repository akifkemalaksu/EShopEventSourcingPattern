using EShop.API.Commands;
using EShop.API.Dtos;
using EShop.API.EventStores;
using EShop.API.Extensions;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddEventStore();
builder.Services.AddSingleton<ProductStream>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/products", async (CreateProductDto createProduct, IMediator mediator) =>
{
    var response = await mediator.Send(new CreateProductCommand { CreateProduct = createProduct });

    Results.NoContent();
});

app.MapPut("api/products/change-name", async (ChangeProductNameDto changeProductName, IMediator mediator) =>
{
    var response = await mediator.Send(new ChangeProductNameCommand { ChangeProductName = changeProductName });

    Results.NoContent();
});

app.MapPut("api/products/change-price", async (ChangeProductPriceDto changeProductPrice, IMediator mediator) =>
{
    var response = await mediator.Send(new ChangeProductPriceCommand { ChangeProductPrice = changeProductPrice });

    Results.NoContent();
});

app.MapDelete("api/products/{id}", async (Guid id, IMediator mediator) =>
{
    var response = await mediator.Send(new DeleteProductCommand { Id = id });

    Results.NoContent();
});

app.Run();
