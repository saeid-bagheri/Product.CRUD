using App.Core.Application.DTOs.Product;
using App.Core.Application.Features.Products.Requests.Queries;
using App.Core.Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Features.Products.Handlers.Queries
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
