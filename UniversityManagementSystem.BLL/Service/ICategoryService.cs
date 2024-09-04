using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.DLL.DbContext;

using UniversityManagementSystem.API.Models;
using UniversityManagementSystem.BLL.ViewModel.Request;



namespace UniversityManagementSystem.BLL.Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetAData(int id);
        Task<Category> AddCategory(Category request);
        Task<Category> UpdateCategory(int id, CategoryInsertViewModel request);
        Task<Category> DeleteCategory(int id);
        //Task<int> AddNumber(int id);
        //Task<int> GetNumber();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        // private int _myNUmber = 1;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.AsQueryable().ToListAsync();
        }

        public async Task<Category> GetAData(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> AddCategory(Category category)
        {
            _context.Categories.Add(category);

            if (await _context.SaveChangesAsync() > 0)
            {
                return category;
            }

            throw new Exception("something went wrong");
        }

        public async Task<Category> UpdateCategory(int id, CategoryInsertViewModel request)
        {
            var category = await GetAData(id);

            if (category == null)
            {
                throw new Exception("category not found");
            }

            if (!request.Name.IsNullOrEmpty())
            {
                category.Name = request.Name;
            }

            if (!request.ShortName.IsNullOrEmpty())
            {
                category.ShortName = request.ShortName;
            }

            _context.Categories.Update(category);

            if (await _context.SaveChangesAsync() > 0)
            {
                return category;
            }

            throw new Exception("something went wrong");
        }


        public async Task<Category> DeleteCategory(int id)
        {
            var category = await GetAData(id);

            if (category == null)
            {
                throw new Exception("category not found");
            }

            _context.Categories.Remove(category);

            if (await _context.SaveChangesAsync() > 0)
            {
                return category;
            }

            throw new Exception("something went wrong");
        }

        //public async Task<int> AddNumber(int id)
        //{
        //    _myNUmber = _myNUmber + id;
        //    return _myNUmber;
        //}

        //public async Task<int> GetNumber()
        //{
        //    return _myNUmber;
        //}
    }
}