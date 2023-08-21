using App.Core.Application.Features.Products.Requests.Commands;
using App.Core.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Application.Contracts.Application;

namespace App.Core.Application.Features.Products.Handlers.Commands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IIsUserManufactureProduct _isUserManufactureProduct;

        public DeleteProductHandler(IProductRepository productRepository, IMapper mapper,
                                    IIsUserManufactureProduct isUserManufactureProduct)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _isUserManufactureProduct = isUserManufactureProduct;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);

            if (product == null)
            {
                throw new Exception($"محصول با شناسه {request.Id} وجود ندارد");
            }

            if (!_isUserManufactureProduct.Execute(product))
            {
                throw new Exception("تنها سازنده محصول امکان حذف آن را دارد.");
            }


            await _productRepository.Delete(product);
            return Unit.Value;
        }
    }
}
