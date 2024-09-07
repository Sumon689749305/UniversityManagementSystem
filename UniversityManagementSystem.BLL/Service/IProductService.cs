using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.API.Models;
using UniversityManagementSystem.BLL.ViewModel.Request;
using UniversityManagementSystem.DLL.DbContext;
using UniversityManagementSystem.DLL.Repository;
using UniversityManagementSystem.DLL.uow;

namespace UniversityManagementSystem.BLL.Service
{
   
    public interface IProductService
    {
        Task<List<Product>> GetAllData();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product request);
        Task<Product> UpdateProduct(int id,ProductInsertViewModel request);
        Task<Product> DeleteProduct(int id);
    }
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> GetAllData()
        {
            return await _unitOfWork.ProductRepository.FindAll().ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.ProductRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync(); 
        }


        public async Task<Product> AddProduct(Product product)
        {
            _unitOfWork.ProductRepository.Create(product);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return product;
            }

            throw new Exception("something went wrong");
        }

        public async Task<Product> UpdateProduct(int id, ProductInsertViewModel request)
        {
            var product = await GetProductById(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            if (!request.Name.IsNullOrEmpty())
            {
                product.Name = request.Name;
            }
            if (!request.Description.IsNullOrEmpty())
            {
                product.Description = request.Description;
            }

            _unitOfWork.ProductRepository.Update(product);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return product;
            }
            throw new Exception("Something went wrong");
        }
        public async Task<Product> DeleteProduct(int id)
        {
            var product= await GetProductById(id);

            if (product == null)
            {
                throw new Exception("Product Not Found");
            }

            _unitOfWork.ProductRepository.Delete(product);

            if(await _unitOfWork.SaveChangesAsync())
            {  return product; }
            throw new Exception("something went wrong");

        }
    }

}
