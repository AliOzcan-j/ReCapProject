using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("\n");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " +
                    car.ColorId + " " + car.ModelYear + " " + car.DailyPrice +
                    " " + car.Description);
            }

            Console.WriteLine("\n");

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id+" "+brand.Name);
            }

            Console.WriteLine("\n");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id+" "+color.Name);
            }
        }
    }
}
