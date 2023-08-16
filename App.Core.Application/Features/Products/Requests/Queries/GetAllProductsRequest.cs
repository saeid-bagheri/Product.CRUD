using App.Core.Application.DTOs;
using App.Core.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Features.Products.Requests.Queries
{
    public class GetAllProductsRequest : IRequest<List<ProductDto>>
    {
    }
}
