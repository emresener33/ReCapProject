using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage image);
        IResult Delete(CarImage image);
        IResult Update(IFormFile file, CarImage image);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IDataResult<CarImage> GetById(int id);
    }
}
