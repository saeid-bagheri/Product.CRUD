using App.Core.Application.Contracts.Persistence;
using App.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        private readonly AppDbContext _Context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }
    }
}
