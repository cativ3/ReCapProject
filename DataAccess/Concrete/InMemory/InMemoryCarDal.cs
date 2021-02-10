using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>{
                new Car
                {
                    Id = 1,
                    BrandId = 1,
                    ColorId = 3,
                    ModelYear = 2006,
                    DailyPrice = 400,
                    Description = "Kırmızı renk 2006 model Mazda."
                },
                new Car
                {
                    Id = 2,
                    BrandId = 3,
                    ColorId = 1,
                    ModelYear = 2008,
                    DailyPrice = 500,
                    Description = "Beyaz renk 2008 model Peugeot."
                },
                new Car
                {
                    Id = 3,
                    BrandId = 2,
                    ColorId = 2,
                    ModelYear = 2016,
                    DailyPrice = 1000,
                    Description = "Siyah renk 2016 model BMW."
                },
                new Car
                {
                    Id = 4,
                    BrandId = 2,
                    ColorId = 5,
                    ModelYear = 2020,
                    DailyPrice = 1300,
                    Description = "Gri renk 2020 model BMW."
                },
                new Car
                {
                    Id = 5,
                    BrandId = 1,
                    ColorId = 4,
                    ModelYear = 2010,
                    DailyPrice = 650,
                    Description = "Lacivert renk 2010 model Mazda."
                }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car choosenCar = _cars.SingleOrDefault(c => c.Id == id);
            return choosenCar;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
