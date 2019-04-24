using System;
using DPTO.Domain;
using DPTO.Dto;

namespace DPTO.ApplicationService.UseCases
{
    public class CreateCarUseCase
    {
        private readonly ICarRepository _carRepository;

        public CreateCarUseCase(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Handle(CarParams car)
        {
            var carEntity = new Car
            {
                Name = car.Name,
                AddedOn = DateTime.Now
            };

            _carRepository.Add(carEntity);
        }
    }
}
