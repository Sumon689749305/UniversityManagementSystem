﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.DLL.DbContext;

namespace UniversityManagementSystem.DLL.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task Create(T model);
        void CreateRange(List<T> models);
        void Update(T model);
        void UpdateRange(List<T> models);
        void Delete(T model);
        void DeleteRange(List<T> models);

       
    }
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task Create(T model)
        {
            await _context.Set<T>().AddAsync(model);
        }

        void IRepositoryBase<T>.CreateRange(List<T> models)
        {
            throw new NotImplementedException();
        }

        public async Task CreateRange(List<T> models)
        {
            await _context.Set<T>().AddRangeAsync(models);
        }

        public void Update(T model)
        {
            _context.Set<T>().Update(model);
        }

        public void UpdateRange(List<T> models)
        {
            _context.Set<T>().UpdateRange(models);
        }

        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }

        public void DeleteRange(List<T> models)
        {
            _context.Set<T>().RemoveRange(models);
        }

      

    }

}
