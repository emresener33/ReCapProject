using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1, BrandId=5, ColorId=1, ModelYear=2020, DailyPrice=550, Description="Otomatik Dizel"},
                new Car {Id=2, BrandId=4, ColorId=3, ModelYear=2020, DailyPrice=155, Description="Manuel Benzin"},
                new Car {Id=3, BrandId=3, ColorId=1, ModelYear=2018, DailyPrice=350, Description="Manuel Benzin"},
                new Car {Id=4, BrandId=2, ColorId=2, ModelYear=2015, DailyPrice=850, Description="Otomatik Hybrid"},
                new Car {Id=5, BrandId=1, ColorId=4, ModelYear=2012, DailyPrice=900, Description="Otomatik Benzin"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
