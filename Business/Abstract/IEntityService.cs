using Core.Utilities.Results;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityService<T> where T: class, IEntity, new()
    {
        IDataResult<List<T>> GetAll();
        IResult Delete(T entity);
        IResult Add(T entity);
        IResult Update(T entity);
    }
}
