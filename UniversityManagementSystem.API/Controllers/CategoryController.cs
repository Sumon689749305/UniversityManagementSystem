﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.API.Models;
using UniversityManagementSystem.BLL.Service;
using UniversityManagementSystem.BLL.ViewModel.Request;
using UniversityManagementSystem.DLL.DbContext;

namespace UniversityManagementSystem.API.Controllers
{
    public class CategoryController : APIBaseController
    {
        private readonly ICategoryService _categoryService;
       

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAData(int id)
        {
            return Ok(await _categoryService.GetAData(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CategoryInsertViewModel request)
        {
            var category = new Category()
            {
                Name = request.Name,
                ShortName = request.ShortName
            };

            return Ok(await _categoryService.AddCategory(category));
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, CategoryInsertViewModel request)
        {
            return Ok(await _categoryService.UpdateCategory(id, request));
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _categoryService.DeleteCategory(id));
        }
    }
}