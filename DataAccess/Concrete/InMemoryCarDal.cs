using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>{
                new Car{Id=1 , BrandId=1, ModelYear=2013, DailyPrice= 500, ColorId= 1, Description= "Hyundai"},
                new Car{Id=2 , BrandId=2, ModelYear=2015, DailyPrice= 700, ColorId= 1, Description= "Wolksvagen"},
                new Car{Id=3 , BrandId=3, ModelYear=2016, DailyPrice= 750, ColorId= 2, Description= "Mercedes"},
                new Car{Id=4 , BrandId=3, ModelYear=2017, DailyPrice= 850, ColorId= 2, Description= "Mercedes"}
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

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
