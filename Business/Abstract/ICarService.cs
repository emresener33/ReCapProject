﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        Car GetById(int carId);

        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);

        List<CarDetailDto> GetCarsDetail();


        //List<CarDetailDto> GetCarsDetailByBrandId(int brandId);
        //List<CarDetailDto> GetCarsDetailByColorId(int colorId);
        //List<CarDetailDto> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId);
        
    }
}
