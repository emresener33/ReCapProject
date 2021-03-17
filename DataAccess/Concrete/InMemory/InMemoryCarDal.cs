using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car {CarId=1, BrandId=5, ColorId=1, ModelYear="2020", DailyPrice=550, Description="Otomatik Dizel"},
                new Car {CarId=2, BrandId=4, ColorId=3, ModelYear="2020", DailyPrice=155, Description="Manuel Benzin"},
                new Car {CarId=3, BrandId=3, ColorId=1, ModelYear="2018", DailyPrice=350, Description="Manuel Benzin"},
                new Car {CarId=4, BrandId=2, ColorId=2, ModelYear="2015", DailyPrice=850, Description="Otomatik Hybrid"},
                new Car {CarId=5, BrandId=1, ColorId=4, ModelYear="2012", DailyPrice=900, Description="Otomatik Benzin"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
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
            return _cars.Where(c => c.CarId == carId).ToList();
        }

    }
}
