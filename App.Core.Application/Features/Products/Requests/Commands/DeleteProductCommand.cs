using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Features.Products.Requests.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
