using EShop.API.Commands;
using EShop.API.EventStores;
using MediatR;

namespace EShop.API.Handlers
{
    public class DeleteProductCommandHandler(
        ProductStream _productStream
        ) : IRequestHandler<DeleteProductCommand>
    {
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _productStream.Deleted(request.Id);

            await _productStream.SaveAsync();

            return Unit.Value;
        }
    }
}
