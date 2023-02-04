using MongoDB.Driver;
using System.Collections.Generic;
using TrincaChurrasAPI.Domain.Interfaces;
using TrincaChurrasAPI.Repository.Context;
using TrincaChurrasAPI.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;
using TrincaChurrasAPI.Domain.Base;
using System;
using System.Linq.Expressions;

namespace TrincaChurrasAPI.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly CosmoDbContext _context;

        public readonly DbSet<T> _DbSet;
         

        public RepositoryBase(CosmoDbContext appContext)
        {
            _DbSet = appContext.Set<T>();
            _context = appContext;
        }

        public IQueryable<T> QueryAll()
        {
            return _DbSet.AsQueryable<T>();
        }

        public T Query(string key)
        {
            return _DbSet.AsQueryable<T>().FirstOrDefault(p => p.id == key);
           
        }

        public void AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChangesAsync();
        }

        public IQueryable<T> GetFilter(Expression<Func<T, bool>> predicate)
        {
            var query = _DbSet.AsQueryable(); 
            return query.Where(predicate);
            
        }
    }
}
