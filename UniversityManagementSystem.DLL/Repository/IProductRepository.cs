using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.API.Models;
using UniversityManagementSystem.DLL.DbContext;

namespace UniversityManagementSystem.DLL.Repository
{
    public interface IProductRepository :IRepositoryBase<Product>
    {
    }
    public class ProductRepository : RepositoryBase<Product> , IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
