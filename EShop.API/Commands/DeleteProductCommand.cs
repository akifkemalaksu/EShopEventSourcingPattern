using MediatR;

namespace EShop.API.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
