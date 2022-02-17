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
            //CarTest();
            //BrandTest();
            //ColorTest();
            CarManager cm = new CarManager(new EfCarDal());
            var result = cm.GetCarsByBrandId(15);
            Console.WriteLine(result.Message);
        
        }

        private static void ColorTest()
        {
            Console.WriteLine("\n");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            Console.WriteLine("\n");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            Console.WriteLine("\n");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.Description+" "+
                                  car.ColorName + " " + car.ModelYear + " " + car.DailyPrice);

                
            }
        }
    }
}
