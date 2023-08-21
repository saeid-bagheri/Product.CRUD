using App.Core.Application.DTOs.Product.Validators;
using App.Core.Application.DTOs.Product;
using App.Core.Application.Features.Products.Requests.Commands;
using App.Core.Application.Contracts.Persistence;
using App.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using App.Core.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace App.Core.Application.Features.Products.Handlers.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductDtoValidator();
            ValidationResult validationResult = validator.Validate(request.CreateProductDto);


            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult);
            }

            //get current user
            var user = _httpContextAccessor.HttpContext.User;

            var product = new Product()
            {
                Name = request.CreateProductDto.Name,
                ManufacturePhone = request.CreateProductDto.ManufacturePhone,
                IsAvailable = true,
                ProductDate = DateTime.Now,
                ManufactureEmail = user.FindFirst(ClaimTypes.Email).Value
            };
            product = await _productRepository.Add(product);
            return product.Id;
        }
    }
}
