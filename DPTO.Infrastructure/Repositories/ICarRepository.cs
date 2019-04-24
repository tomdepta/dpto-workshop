using System;
using System.Collections.Generic;
using System.Text;
using DPTO.Domain;

namespace DPTO.Infrastructure.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetCars();

        Car GetCarById(int id);

        void Add(Car car);
    }
}
