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

            //DeleteMethod(carManager);
            //AddMethod(carManager);

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            /*foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName + " - " + car.CarName + "-" + car.ColorName + " - " + car.DailyPrice);
            }*/
            //Console.WriteLine(carManager.GetById(2).DailyPrice);

        }



        private static void AddMethod(CarManager carManager)
        {
           // Car car1 = new Car { BrandId = 8, ColorId = 9, ModelYear = 2021, DailyPrice = 10000, Description = "Bugatti" };
           // carManager.Add(car1);
            Car car2 = new Car { BrandId = 10, ColorId = 3, ModelYear = 2020, DailyPrice = 80000, Description = "Enzo" };
            carManager.Add(car2);
        }

        private static void DeleteMethod(CarManager carManager)
        {
            carManager.Delete(new Car { CarId = 8 });
        }
    }
}
