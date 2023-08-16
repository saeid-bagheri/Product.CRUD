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

namespace App.Core.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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


            var product = await _productRepository.Get(request.UpdateProductDto.Id);
            _mapper.Map(request.UpdateProductDto, product);
            await _productRepository.Update(product);

            return Unit.Value;
        }
    }
}
