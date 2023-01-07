using Business.Abstract;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Colour entity)
        {
            foreach (var item in _colorDal.GetAll())
            {
                if (item.Id == entity.Id)
                    return new ErrorResult(Messages.IdInvalid);
            }
            _colorDal.Add(entity);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Colour entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Colour>> GetAll()
        {
            return new SuccessDataResult<List<Colour>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Colour> GetById(int id)
        {
            return new SuccessDataResult<Colour>(_colorDal.Get(b => b.Id == id), Messages.ColorListed);
        }

        public IResult Update(Colour entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
