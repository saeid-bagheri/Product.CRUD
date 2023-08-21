using App.Core.Application.Contracts.Application;
using App.Core.Application.Profiles;
using App.Core.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application._IocConfigs
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddHttpContextAccessor();
            services.AddScoped<IIsUserManufactureProduct, IsUserManufactureProduct>();

            return services;
        }
    }
}
