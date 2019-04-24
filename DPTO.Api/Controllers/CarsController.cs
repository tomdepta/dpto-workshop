using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPTO.Domain;
using DPTO.Infrastructure;
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

        private readonly DptoContext _context;

        public CarsController(DptoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Car> Get()
        {
            return _context.Cars.ToList();
        }
        
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _context.Cars.FirstOrDefault(car => car.Id == id);
        }
        
        [HttpPost]
        public void Post([FromBody] Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }
    }
}
