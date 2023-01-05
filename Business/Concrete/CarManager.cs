using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car entity)
        {
            foreach (var item in _carDal.GetAll())
            {
                if (item.Id == entity.Id)
                    return new ErrorResult(Messages.IdInvalid);
            }
            if (entity.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(entity);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            if(_carDal.Get(p => p.Id == id) != null)
            {
                return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.CarListed);
            }
            return new ErrorDataResult<Car>(Messages.CarNameInvalid);
        }

        public IDataResult<List<Car>> GetAllByModelYear(int year)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=> p.ModelYear == year), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=> p.BrandId== brandId), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=> p.ColorId== colorId), Messages.CarListed);
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdated);
            
        }
    }
}
