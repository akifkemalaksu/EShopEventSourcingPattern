using EShop.API.Contexts;
using EShop.API.Dtos;
using EShop.API.Queries;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.API.Handlers
{
    public class GetAllProductsQueryHandler(
        AppDbContext _dbContext
        ) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _dbContext.Products
                .ProjectToType<ProductDto>()
                .ToListAsync(cancellationToken);

            return products;
        }
    }
}
