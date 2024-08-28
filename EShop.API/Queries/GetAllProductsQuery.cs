using EShop.API.Dtos;
using MediatR;

namespace EShop.API.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
