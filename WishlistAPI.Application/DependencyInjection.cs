using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.Services;
using WishlistAPI.Domain.Interfaces;

namespace WishlistAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IPresentService, PresentService>();
            services.AddTransient<IWishlistService, WishlistService>();
            services.AddTransient<IPresentTypeService, PresentTypeService>();

            return services;
        }
    }
}
