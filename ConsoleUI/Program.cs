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

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"Id: {car.Id}, Marka: {car.BrandName}, Color: {car.ColorName}, Yıl: {car.ModelYear}, Günlük Fiyat: {car.DailyPrice}");
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
