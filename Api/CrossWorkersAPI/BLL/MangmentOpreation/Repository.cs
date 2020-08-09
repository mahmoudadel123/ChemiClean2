using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Linq.Expressions;

namespace BLL.MangmentOpreation
{

    //repositry class to write main functions body 
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly crossoverContext _dbContext;
        public DbSet<T> _dbSet => _dbContext.Set<T>();
        public DbSet<T> DbSet { get { return _dbSet; } }
        public IQueryable<T> Entities => _dbSet;
        public Repository(crossoverContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// get all in IQueryable 
        /// </summary>
        /// <returns></returns>

        public IQueryable<T> IQueryable()
        {
            return _dbSet.AsQueryable();
        }
        /// <summary>
        /// get Iqueryable with linq expressions as conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> IQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        /// <summary>
        /// get single element by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(params object[] id)
        {
            return _dbSet.Find(id);
        }


    }

}

