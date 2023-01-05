﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            if (entity.RentDate > entity.ReturnDate)
            {
                return new ErrorResult(Messages.DateInvalid);
            }

            bool result1 = false;
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                if (car.Id == entity.CarId)
                {
                    result1 = true;
                }
            }

            bool result2 = false;
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                if(customer.Id == entity.CustomerId)
                {
                    result2 = true;
                }
            }           

            if (result1 && result2)
                foreach (var rental in _rentalDal.GetAll())
                {
                    if (entity.ReturnDate < rental.RentDate || entity.RentDate > rental.ReturnDate)
                        return new SuccessResult(Messages.RentalAdded);
                }

            return new ErrorResult(Messages.RentalNotAdded);


            
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.RentalListed);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
