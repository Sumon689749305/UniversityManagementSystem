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
using UniversityManagementSystem.DLL.Repository;
using UniversityManagementSystem.DLL.uow;



namespace UniversityManagementSystem.BLL.Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetAData(int id);
        Task<Category> AddCategory(Category request);
        Task<Category> UpdateCategory(int id, CategoryInsertViewModel request);
        Task<Category> DeleteCategory(int id);

    }

    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _unitOfWork.CategoryRepository.FindAll().ToListAsync();
        }

        public async Task<Category> GetAData(int id)
        {
            return await _unitOfWork.CategoryRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category> AddCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Create(category);

            if (await _unitOfWork.SaveChangesAsync())
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

            _unitOfWork.CategoryRepository.Update(category);

            if (await _unitOfWork.SaveChangesAsync())
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

            _unitOfWork.CategoryRepository.Delete(category);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return category;
            }

            throw new Exception("something went wrong");
        }
    }
}