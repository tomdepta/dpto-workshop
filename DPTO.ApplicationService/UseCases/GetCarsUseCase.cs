using System.Collections.Generic;
using System.Linq;
using DPTO.Dto;

namespace DPTO.ApplicationService.UseCases
{
    public class GetCarsUseCase
    {
        private readonly ICarRepository _carRepository;

        public GetCarsUseCase(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<CarDto> Handle()
        {
            return _carRepository.GetCars()
                .Select(car => new CarDto
                {
                    Name = car.Name,
                    AddedOn = car.AddedOn
                })
                .ToList();
        }
    }
}
