using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionTest(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetail();


        //List<CarDetailDto> GetCarsDetailByBrandId(int brandId);
        //List<CarDetailDto> GetCarsDetailByColorId(int colorId);
        //List<CarDetailDto> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId);

    }
}
