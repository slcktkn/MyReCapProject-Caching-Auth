using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.LoadedList);
        }

        public IDataResult<List<Color>> GetColorsByColorName(string colorName)
        {
            if (DateTime.Now.Hour==15)
            {
                 return new ErrorDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorName == colorName),Messages.MaintenanceTime);
            }
           
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c=>c.ColorName==colorName));
        }

        public IDataResult<Color> GetByColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        public IDataResult<List<ColorDetailsDto>> GetColorDetails()
        {
           return new ErrorDataResult<List<ColorDetailsDto>>(_colorDal.GetColorDetails(),Messages.LoadedList);
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length==2)
            {
                return new ErrorResult(Messages.InvalidName);
            }

                _colorDal.Add(color);

                return new SuccessResult(Messages.ValidName);
        }
    }
}
