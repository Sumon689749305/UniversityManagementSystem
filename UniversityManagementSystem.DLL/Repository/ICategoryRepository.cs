﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.API.Models;
using UniversityManagementSystem.DLL.DbContext;

namespace UniversityManagementSystem.DLL.Repository
{
    public interface ICategoryRepository: IRepositoryBase<Category>
    {
    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }   }
