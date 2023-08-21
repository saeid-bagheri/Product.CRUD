using App.Core.Application.Contracts.Application;
using App.Core.Application.Contracts.Persistence;
using App.Core.Application.DTOs.Product;
using App.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Services
{
    public class IsUserManufactureProduct : IIsUserManufactureProduct
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsUserManufactureProduct(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Execute(Product product)
        {
            //get current user
            var user = _httpContextAccessor.HttpContext.User;
            var userEmail = user.FindFirst(ClaimTypes.Email).Value;

            return userEmail == product.ManufactureEmail;
        }
    }
}
