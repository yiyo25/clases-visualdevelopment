﻿using App.Data.DataAccess;
using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class GenericRepository<TEntity> : 
                                IGenericRepository<TEntity>
        where TEntity:class
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            this._context = context;
        }

        public bool Add(TEntity entity)
        {

            _context.Set<TEntity>().Add(entity);

            return true;
        }

        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public List<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> orderBy = null
           )
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (filter != null)
            {
                query.Where(filter);

            }

            if(filter != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
           
        }

        public TEntity GetById<TId>(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public bool Remove(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Set<TEntity>().Remove(entity);

            return true;
        }

        public bool Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return true;
        }
    }
}
