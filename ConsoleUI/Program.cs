using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carManager = new CarManager(new InMemoryCarDal());

            WriteTitle("GetAll");

            WriteConsole(carManager);

            WriteTitle("Add");

            carManager.Add(new Car
            {
                Id = 6,
                BrandId = 2,
                ColorId = 3,
                ModelYear = 2007,
                DailyPrice = 800,
                Description = "Kırmızı renk 2007 model BMW."
            });

            WriteConsole(carManager);

            WriteTitle("Delete");

            carManager.Delete(new Car
            {
                Id = 2,
                BrandId = 3,
                ColorId = 1,
                ModelYear = 2008,
                DailyPrice = 500,
                Description = "Beyaz renk 2008 model Peugeot."
            });

            WriteConsole(carManager);

            WriteTitle("GetById");

            Console.WriteLine(carManager.GetById(3).Description);

            WriteTitle("Update");

            carManager.Update(new Car
            {
                Id = 3,
                BrandId = 1,
                ColorId = 4,
                ModelYear = 2012,
                DailyPrice = 900,
                Description = "Lacivert renk 2012 model Mazda."
            });

            WriteConsole(carManager);
            
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
            Console.WriteLine($"{methodName} fonksiyonu:");
            Console.WriteLine("-----------------------------");
        }
    }
}
