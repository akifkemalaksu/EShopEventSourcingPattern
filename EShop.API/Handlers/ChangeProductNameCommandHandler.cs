using EShop.API.Commands;
using EShop.API.EventStores;
using MediatR;

namespace EShop.API.Handlers
{
    public class ChangeProductNameCommandHandler(
        ProductStream _productStream
        ) : IRequestHandler<ChangeProductNameCommand>
    {
        public async Task<Unit> Handle(ChangeProductNameCommand request, CancellationToken cancellationToken)
        {
            _productStream.NameChanged(request.ChangeProductName);

            await _productStream.SaveAsync();

            return Unit.Value;
        }
    }
}
