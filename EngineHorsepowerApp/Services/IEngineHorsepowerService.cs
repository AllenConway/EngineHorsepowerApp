using EngineHorsepowerApp.Models;

namespace EngineHorsepowerApp.Services
{
    public interface IEngineHorsepowerService
    {
        Horsepower CalculateEngineHorsepower(Calculations calculations);
    }
}
