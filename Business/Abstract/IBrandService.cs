using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResult Delete(Brand entity);
        IResult Add(Brand entity);
        IResult Update(Brand entity);
    }
}
