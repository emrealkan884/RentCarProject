using Business.Concrete;
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
           
            //carManager.Delete(new Car { Id = 3005 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            //Car car1 = new Car {BrandId = 8, ColorId = 9, ModelYear = 2021, DailyPrice = 10000, Description = "Bugatti" };
            //carManager.Add(car1);
            //Car car2 = new Car { BrandId = 10, ColorId = 3, ModelYear = 2020, DailyPrice = 80000, Description = "Ferrari" };
            //carManager.Add(car2);

        }
    }
}
