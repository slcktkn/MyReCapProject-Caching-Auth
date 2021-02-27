using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),"Getting brands are successfull");
        }

        public IDataResult<List<Brand>> GetBrandsById(int brandId)
        {
            return new ErrorDataResult<List<Brand>>(_brandDal.GetAll(br=>br.BrandId==brandId),Messages.GetBrandsById);
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.InvalidName);
            }
            _brandDal.Add(brand);

            return new SuccessResult(Messages.ValidName);
        }
    }
}
