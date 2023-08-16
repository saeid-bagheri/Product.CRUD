using App.Core.Application.DTOs;
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
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
