using ConsoDb;
using ConsoDb_BLL.Interfaces;
using ConsoDb_DAL.Interfaces;
using ConsoDb_DAL.Repositories;

namespace ConsoDb_BLL.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public int Add(Car car)
    {
        return _carRepository.Add(car);
    }
}