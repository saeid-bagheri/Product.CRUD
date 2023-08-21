using App.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.Contracts.Application
{
    public interface IIsUserManufactureProduct
    {
        bool Execute(Product product);
    }
}
