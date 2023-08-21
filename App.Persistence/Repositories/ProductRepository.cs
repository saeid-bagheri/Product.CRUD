using App.Core.Application.Contracts.Persistence;
using App.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Product>> GetAllByManufacturer(string manufactureEmail)
        {
            var products = await _Context.Products.Where(p => p.ManufactureEmail == manufactureEmail).ToListAsync();
            return products;
        }
    }
}
