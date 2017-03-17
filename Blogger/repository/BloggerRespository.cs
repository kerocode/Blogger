using Blogger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Blogger.repository
{
    public class BloggerBaseRespository<T> : IBloggerRepository<T>
        where T : class, IEntity, new()
    {
        private BloggingContext _context;
        public BloggerBaseRespository(BloggingContext context)
        {
            _context = context;
        }

        #region Insert
        /// <summary>
        /// Inserts an value using a new connection.
        /// </summary>
        /// <typeparam name="T">The type of the value to insert.</typeparam>
        /// <param name="entity">The <typeparamref name="T"/> to insert.</param>
        public void Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }
        #endregion

        #region Update

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;

        }
        #endregion

        #region GetAll
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        #endregion

        #region Find
        public T FindById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        #endregion

        #region Remove
        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
        #endregion

        public T FindById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T FindById(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefault();
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }
    }
}
