using App.Core.Application.Features.Products.Requests.Commands;
using App.Core.Application.Persistence.Contracts;
using App.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Features.Products.Handlers.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);
            var id = await _productRepository.Add(product);
            return id;
        }
    }
}
