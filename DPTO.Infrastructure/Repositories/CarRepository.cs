﻿using System.Collections.Generic;
using System.Linq;
using DPTO.Domain;

namespace DPTO.Infrastructure.Repositories
{
    public class CarRepository
    {
        private readonly DptoContext _context;

        public CarRepository(DptoContext context)
        {
            _context = context;
        }

        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(car => car.Id == id);
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }
    }
}