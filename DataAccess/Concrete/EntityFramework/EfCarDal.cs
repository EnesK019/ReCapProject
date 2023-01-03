using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from c in context.car
                             join b in context.brand
                             on c.BrandId equals b.Id
                             join cl in context.color
                             on c.ColorId equals cl.Id
                             select new CarDetailDto 
                             { 
                                CarName = c.CarName, BrandName = b.Name, 
                                ColorName = cl.Name, DailyPrice = c.DailyPrice 
                             };

                return result.ToList();
            }
            
        }
    }
}
