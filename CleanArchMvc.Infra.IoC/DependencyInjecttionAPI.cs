using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjecttionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<iCategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}