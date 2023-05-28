﻿using Microsoft.EntityFrameworkCore;
using MoviesCollection.Api.Context;
using System.Linq.Expressions;

namespace MoviesCollection.Api.Repository
{
  public class Repository<T> : IRepository<T> where T : class
  {
    protected ApiDbContext _context;

    public Repository(ApiDbContext context)
    {
      _context = context;
    }

    public void Add(T entity)
    {
      _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
      _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> Get()
    {
      return _context.Set<T>().AsNoTracking();
    }

    public async Task<T> GetById(Expression<Func<T, bool>> predicate)
    {
      return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
    }

    public void Update(T entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      _context.Set<T>().Update(entity);
    }
  }
}
