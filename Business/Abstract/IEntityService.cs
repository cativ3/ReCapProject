using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityService<T> where T: class, IEntity, new()
    {
        List<T> GetAll();
        void Delete(T entity);
        void Add(T entity);
        void Update(T entity);
    }
}
