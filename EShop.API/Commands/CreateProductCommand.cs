using EShop.API.Dtos;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace EShop.API.Commands
{
    public class CreateProductCommand : IRequest
    {
        public required CreateProductDto CreateProduct { get; set; }
    }
}
