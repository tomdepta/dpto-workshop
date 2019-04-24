using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPTO.ApplicationService.UseCases;
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
        private readonly CreateCarUseCase _createCar;
        private readonly GetCarsUseCase _getCars;
        private readonly GetCarByIdUseCase _getCarById;

        public CarsController(CreateCarUseCase createCar, GetCarsUseCase getCars, GetCarByIdUseCase getCarById)
        {
            _createCar = createCar;
            _getCars = getCars;
            _getCarById = getCarById;
        }

        [HttpGet]
        public List<CarDto> Get()
        {
            return _getCars.Handle();
        }
        
        [HttpGet("{id}")]
        public CarDto Get(int id)
        {
            return _getCarById.Handle(id);
        }
        
        [HttpPost]
        public void Post([FromBody] CarParams car)
        {
            _createCar.Handle(car);
        }
    }
}
