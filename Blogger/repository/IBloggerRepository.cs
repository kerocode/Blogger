using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blogger.repository
{
    public interface IBloggerRepository<T> where T : class, IEntity, new()
    {

        IEnumerable<T> GetAll();
        IEnumerable<T> AllIncluding( params Expression<Func<T, object>>[] includeProperties);
        T FindById(int key);
        T FindById(Expression<Func<T, bool>> predicate);
        T FindById(Expression<Func<T, bool>> predicate,params Expression<Func<T,object>>[]includeProperties);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void Update(T entity);
        void Add(T item);
        void Commit();
    }
}
