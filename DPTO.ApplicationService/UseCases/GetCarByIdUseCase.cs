using DPTO.Dto;

namespace DPTO.ApplicationService.UseCases
{
    public class GetCarByIdUseCase
    {
        private readonly ICarRepository _carRepository;

        public GetCarByIdUseCase(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public CarDto Handle(int id)
        {
            var car = _carRepository.GetCarById(id);
            return new CarDto
            {
                Name = car.Name,
                AddedOn = car.AddedOn
            };
        }
    }
}
