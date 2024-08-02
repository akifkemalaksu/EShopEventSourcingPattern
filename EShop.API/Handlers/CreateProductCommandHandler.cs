using EShop.API.Commands;
using EShop.API.EventStores;
using MediatR;

namespace EShop.API.Handlers
{
    public class CreateProductCommandHandler(
        ProductStream _productStream
        ) : IRequestHandler<CreateProductCommand>
    {
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _productStream.Created(request.CreateProduct);

            await _productStream.SaveAsync();

            return Unit.Value;
        }
    }
}
