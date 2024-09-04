using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using UniversityManagementSystem.API.Models;
using UniversityManagementSystem.BLL.Service;
using UniversityManagementSystem.BLL.ViewModel.Request;
using UniversityManagementSystem.DLL.DbContext;

namespace UniversityManagementSystem.API.Controllers
{
    public class ProductController : APIBaseController
    {

        private readonly IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllData());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAData(int id)
        { 
            return Ok(await _productService.GetProductById(id));
        }


        [HttpPost]
        public async Task<IActionResult> Insert(ProductInsertViewModel request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price

            };

            return Ok(await _productService.AddProduct(product));
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, ProductInsertViewModel request)
        {
            return Ok(await _productService.UpdateProduct(id, request));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }

    }
}
