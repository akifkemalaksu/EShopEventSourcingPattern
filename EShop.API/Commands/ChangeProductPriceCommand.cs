using EShop.API.Dtos;
using MediatR;

namespace EShop.API.Commands
{
    public class ChangeProductPriceCommand : IRequest
    {
        public required ChangeProductPriceDto ChangeProductPrice { get; set; }
    }
}
