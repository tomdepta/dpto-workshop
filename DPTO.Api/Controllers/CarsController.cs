using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPTO.Domain;
using DPTO.Infrastructure;
using DPTO.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DPTO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarRepository _repository;

        public CarsController(DptoContext context)
        {
            _repository = new CarRepository(context);
        }

        [HttpGet]
        public List<Car> Get()
        {
            return _repository.GetCars();
        }
        
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _repository.GetCarById(id);
        }
        
        [HttpPost]
        public void Post([FromBody] Car car)
        {
            _repository.Add(car);
        }
    }
}
