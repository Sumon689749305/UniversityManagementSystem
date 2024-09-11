using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.API.Models;
using UniversityManagementSystem.DLL.DbContext;

namespace UniversityManagementSystem.DLL.Repository
{
    public interface ICategoryProductRepository:IRepositoryBase<CategoryProduct>
    {
    }
    public class CategoryProductRepository : RepositoryBase<CategoryProduct>, ICategoryProductRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryProductRepository(ApplicationDbContext context) : base(context)
        {
            _context=context;
        }
    }
}
