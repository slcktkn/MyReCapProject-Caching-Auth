using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetColorsByColorName(string colorName);
        IDataResult<Color> GetByColorId(int colorId);
        IDataResult<List<ColorDetailsDto>> GetColorDetails();
        IResult Add(Color color);
    }
}
