using EShop.API.Dtos;
using MediatR;

namespace EShop.API.Commands
{
    public class ChangeProductNameCommand : IRequest
    {
        public required ChangeProductNameDto ChangeProductName { get; set; }
    }
}
