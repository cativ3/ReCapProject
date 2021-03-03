using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using System.IO;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage entity, IFormFile file)
        {
            var result = CheckRules(
                CheckIfImageLimitExceeded(entity)    
            );

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            
            entity.ImagePath = FileHelper.Add(file);
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(Messages.Listed, _carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = CheckIfCarImagesNull(carId);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        private List<CarImage> CheckIfCarImagesNull(int carId)
        {
            var newPath = @"\images\default_logo.png";
            var images = _carImageDal.GetAll(c => c.CarId == carId);

            if (!images.Any())
            {
                return new List<CarImage> { new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = newPath } };
            }

            return images;
            
        }

        private IResult CheckIfImageLimitExceeded(CarImage entity)
        {
            var cars = _carImageDal.GetAll(c => c.CarId == entity.CarId);

            if (cars.Count >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
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
