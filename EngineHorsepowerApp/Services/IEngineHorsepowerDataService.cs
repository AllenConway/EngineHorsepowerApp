using EngineHorsepowerApp.Models;

namespace EngineHorsepowerApp.Services
{
    public interface IEngineHorsepowerDataService
    {
        Task<IEnumerable<Automobile>> GetAutomobiles();

        Task AddAutomobile(Automobile automobile);
    }
}
