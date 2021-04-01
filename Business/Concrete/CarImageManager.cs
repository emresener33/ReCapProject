using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager: ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;


        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckIfLimitExceded(image.CarId));
            if (result != null)
            {
                return new ErrorResult(Messages.CannotAdd);
            }

            image.ImagePath = FileHelper.Add(file);
            image.ImageUploadDate = DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);

        }

        public IResult Delete(CarImage image)
        {
            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult(Messages.ImageDeleted);
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        public IDataResult<CarImage> GetById(int imageId)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(imageId));
            if (result != null)
            {
                return new ErrorDataResult<CarImage>(result.Message);
            }
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCountNull(id), CheckIfCarExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.ImageNotExist);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        public IResult Update(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckIfLimitExceded(image.CarId));
            if (result != null)
            {
                return result;
            }

            image.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.Id == image.Id).ImagePath, file);
            image.ImageUploadDate = DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult();
        }

        private IResult CheckIfLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CannotAdd);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageCountNull(int id)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\images\logo.png";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();

            if (!result)
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = id, ImagePath = path, ImageUploadDate = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
            return new SuccessDataResult<List<CarImage>>();
        }

        private IResult CheckIfCarExists(int carId)
        {
            var result = _carService.GetById(carId).Data;
            if (result == null)
            {
                return new ErrorResult(Messages.CarNotExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExists(int imageId)
        {
            var result = _carImageDal.Get(c => c.Id == imageId);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.ImageNotExist);
            }
            return new SuccessDataResult<CarImage>();
        }
    }
}
