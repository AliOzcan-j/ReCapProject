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
            /*CarManager cm = new CarManager(new EfCarDal());
            var result = cm.GetCarsByBrandId(15);
            Console.WriteLine(result.Message);*/
            //UserTest();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { Id=3,CarId=2,CustomerId=3,RentDate=new DateTime(2020,02,22)});
            Console.WriteLine(result.Message);
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { Id = 1, FirstName = "Ali", LastName = "Özcan", Email = "placeholder@gmail.com", Password = "Tqs15.OIeqk26KS" });
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName + " " + user.Email + " " + user.Password);
            }
        }

        private static void ColorTest()
        {
            Console.WriteLine("\n");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + " " + color.Name);
            }
        }

        private static void BrandTest()
        {
            Console.WriteLine("\n");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + " " + brand.Name);
            }
        }

        private static void CarTest()
        {
            Console.WriteLine("\n");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Id + " " + car.BrandName + " " + car.Description+" "+
                                  car.ColorName + " " + car.ModelYear + " " + car.DailyPrice);

                
            }
        }
    }
}
