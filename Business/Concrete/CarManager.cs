using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = CheckRules(
                CheckIfModelYearExpired(car),
                CheckIfBrandLimitExceeded(car)
            );

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(Messages.Listed, _carDal.GetAll()); 
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(Messages.Listed, _carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(Messages.Listed, _carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(Messages.Listed, _carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IResult CheckIfBrandLimitExceeded(Car car)
        {
            var brands = _carDal.GetAll(c => c.BrandId == car.BrandId);

            if (brands.Count >= 5)
            {
                return new ErrorResult(Messages.BrandLimitExceeded);
            }

            return new SuccessResult();
        }

        public IResult CheckIfModelYearExpired(Car car)
        {
            var carAge = DateTime.Now.Year - car.ModelYear;

            if (carAge > 20)
            {
                return new ErrorResult(Messages.ModelYearExpired);
            }

            return new SuccessResult();
        }

        private IResult CheckRules(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.Success)
                {
                    return new ErrorResult(rule.Message);
                }
            }

            return new SuccessResult();
        }
    }
}
