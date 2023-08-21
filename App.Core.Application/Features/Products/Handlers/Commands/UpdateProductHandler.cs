using App.Core.Application.DTOs.Product.Validators;
using App.Core.Application.Exceptions;
using App.Core.Application.Features.Products.Requests.Commands;
using App.Core.Application.Contracts.Persistence;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using App.Core.Application.Services;
using App.Core.Application.Contracts.Application;

namespace App.Core.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IIsUserManufactureProduct _isUserManufactureProduct;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper,
                                    IIsUserManufactureProduct isUserManufactureProduct)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _isUserManufactureProduct = isUserManufactureProduct;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductDtoValidator();
            ValidationResult validationResult = validator.Validate(request.UpdateProductDto);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult);
            }

            //get product
            var product = await _productRepository.Get(request.UpdateProductDto.Id);

            if (product == null)
            {
                throw new Exception($"محصول با شناسه {request.UpdateProductDto.Id} وجود ندارد");
            }


            if (!_isUserManufactureProduct.Execute(product))
            {
                throw new Exception("تنها سازنده محصول امکان ویرایش آن را دارد.");
            }

            _mapper.Map(request.UpdateProductDto, product);
            await _productRepository.Update(product);

            return Unit.Value;
        }
    }
}
