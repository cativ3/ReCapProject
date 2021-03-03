using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Delete(Customer entity);
        IResult Add(Customer entity);
        IResult Update(Customer entity);
    }
}
