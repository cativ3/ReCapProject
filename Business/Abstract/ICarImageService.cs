using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Delete(CarImage entity);
        IResult Add(CarImage entity, IFormFile file);
        IResult Update(CarImage entity);
    }
}
