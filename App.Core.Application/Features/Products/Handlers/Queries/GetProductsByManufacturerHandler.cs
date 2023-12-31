﻿using App.Core.Application.Contracts.Persistence;
using App.Core.Application.DTOs.Product;
using App.Core.Application.Features.Products.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Features.Products.Handlers.Queries
{
    public class GetProductsByManufacturerHandler : IRequestHandler<GetProductsByManufacturerRequest, List<ProductDto>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsByManufacturerHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductsByManufacturerRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllByManufacturer(request.ManufactureEmail);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
