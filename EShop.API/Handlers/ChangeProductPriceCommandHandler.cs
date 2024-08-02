using EShop.API.Commands;
using EShop.API.EventStores;
using MediatR;

namespace EShop.API.Handlers
{
    public class ChangeProductPriceCommandHandler(
        ProductStream _productStream
        ) : IRequestHandler<ChangeProductPriceCommand>
    {
        public async Task<Unit> Handle(ChangeProductPriceCommand request, CancellationToken cancellationToken)
        {
            _productStream.PriceChanged(request.ChangeProductPrice);

            await _productStream.SaveAsync();

            return Unit.Value;
        }
    }
}
