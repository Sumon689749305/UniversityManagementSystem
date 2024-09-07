using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.DLL.DbContext;
using UniversityManagementSystem.DLL.Repository;
using UniversityManagementSystem.DLL.uow;

namespace UniversityManagementSystem.DLL
{
    public static class DLLDependency
    {
        public static IServiceCollection AddDLLDependency(this IServiceCollection services)
        {
            //services.AddScoped<ICategoryRepository, CategoryRepository>();

            //services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
