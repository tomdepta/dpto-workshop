using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPTO.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DPTO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly List<Car> _cars = new List<Car>
        {
            new Car {Id = 1, Name = "Opel", AddedOn = DateTime.Now},
            new Car {Id = 2, Name = "Renault", AddedOn = DateTime.Now}
        };

        [HttpGet]
        public List<Car> Get()
        {
            return _cars;
        }
        
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _cars.FirstOrDefault(car => car.Id == id);
        }
        
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
