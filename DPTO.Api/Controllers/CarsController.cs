using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPTO.Domain;
using DPTO.Dto;
using DPTO.Infrastructure;
using DPTO.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DPTO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public CarsController(ICarRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<CarDto> Get()
        {
            return _repository.GetCars()
                .Select(car => new CarDto
                {
                    Name = car.Name,
                    AddedOn = car.AddedOn
                })
                .ToList();
        }
        
        [HttpGet("{id}")]
        public CarDto Get(int id)
        {
            var car = _repository.GetCarById(id);
            return new CarDto
            {
                Name = car.Name,
                AddedOn = car.AddedOn
            };
        }
        
        [HttpPost]
        public void Post([FromBody] CarParams car)
        {
            var newCar = new Car
            {
                Name = car.Name,
                AddedOn = DateTime.Now
            };

            _repository.Add(newCar);
        }
    }
}
