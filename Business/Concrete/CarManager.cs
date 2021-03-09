using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        IRentalService _rentalService;//eğer rental sayısı 15 i geçtiyse sisteme yeni araç eklenemez.(Bu kodun önemi CarManager içide Brand ile alakalı işlem yapmak)
        public CarManager(ICarDal carDal,IRentalService rentalService) //Bir manager içerisinde kendi Dal ı hariç başka bir exception yapamayız
        {
            _carDal = carDal;
            _rentalService = rentalService;
        }

        [ValidationAspect(typeof(CarValidator))]//Add methodunu doğrula CarValidator'deki kurallara göre.
        public IResult Add(Car car)
        {

            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId),CheckIfRentalLimitExceded());
            if (result!=null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.GetCarsByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),Messages.GetCarsByColorId);
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }




        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(p => p.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfRentalLimitExceded()
        {
            var result = _rentalService.GetAll().Data.Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.RentalLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
