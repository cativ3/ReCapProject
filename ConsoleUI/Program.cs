using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carManager = new CarManager(new EfCarDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());

            WriteTitle("brandManager.Add()");

            brandManager.Add(new Brand { Name = "Toyota" });

            WriteTitle("carManager.Add()");

            carManager.Add(new Car
            {
                BrandId = 1,
                ColorId = 4,
                ModelYear = 2014,
                DailyPrice = 1000,
                Description = "2014 model siyah renk BMW."
            });

            WriteTitle("Delete()");

            carManager.Delete(new Car
            {
                Id = 2
            });

            WriteTitle("Update()");

            carManager.Update(new Car
            {
                Id = 1,
                BrandId = 3,
                ColorId = 4,
                ModelYear = 2014,
                DailyPrice = 700,
                Description = "2009 model siyah renk Renault."
            });

            WriteTitle("GetAll()");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            WriteTitle("GetCarsByBrandId()");

            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.Description);
            }

            WriteTitle("GetCarsByColorId()");

            foreach (var car in carManager.GetCarsByColorId(4))
            {
                Console.WriteLine(car.Description);
            }


        }

        // Konsol için yardımcı metotlar

        static void WriteConsole(ICarService carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

        static void WriteTitle(string methodName)
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine($"{methodName}:");
            Console.WriteLine("-----------------------------");
        }
    }
}
