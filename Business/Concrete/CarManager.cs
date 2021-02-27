using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            if (entity.Description.Length>2 && entity.DailyPrice>0)
            {
                _carDal.Add(entity);
            }
        }

        public void Delete(Car entity, int id)
        {
            if (id == entity.Id)
            {
                _carDal.Delete(entity);
            }
            
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();//Hazır fonksiyon
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }
    }
}
