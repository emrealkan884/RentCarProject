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
            //carManager.Delete(4);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            // car1 = new Car { BrandId = 4, ColorId = 4, ModelYear = 2019, DailyPrice = 1000, Description = "Mercedes" };
            //carManager.Add(car1);
            
        }
    }
}
