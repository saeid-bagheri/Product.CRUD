using App.Core.Application.Features.Products.Requests.Commands;
using App.Core.Application.Persistence.Contracts;
using AutoMapper;
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
            var product = await _productRepository.Get(request.UpdateProductDto.Id);
            _mapper.Map(request.UpdateProductDto, product);
            await _productRepository.Update(product);

            return Unit.Value;
        }
    }
}
