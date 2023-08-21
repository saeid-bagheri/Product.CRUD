using App.Core.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
