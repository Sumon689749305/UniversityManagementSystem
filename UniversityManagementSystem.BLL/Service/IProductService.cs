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
        private readonly ApplicationDbContext _productRepository;

        public ProductService(ApplicationDbContext context) 
        {
            _productRepository = context;
        }

        public async Task<List<Product>> GetAllData()
        {
            return await _productRepository.Products.AsQueryable().ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.Products.FirstOrDefaultAsync(x => x.Id == id); 
        }


        public async Task<Product> AddProduct(Product product)
        {
            _productRepository.Products.Add(product);

            if (await _productRepository.SaveChangesAsync() > 0)
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

            _productRepository.Products.Update(product);

            if (await _productRepository.SaveChangesAsync() > 0)
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

            _productRepository.Products.Remove(product);

            if(await _productRepository.SaveChangesAsync() > 0)
            {  return product; }
            throw new Exception("something went wrong");

        }
    }

}
