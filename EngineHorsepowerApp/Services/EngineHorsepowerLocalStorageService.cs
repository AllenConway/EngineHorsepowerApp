using Blazored.LocalStorage;
using EngineHorsepowerApp.Models;
using System.Collections.Generic;

namespace EngineHorsepowerApp.Services
{
    public class EngineHorsepowerLocalStorageService : IEngineHorsepowerDataService
    {

        private readonly ILocalStorageService localStorage;
        private readonly string localStorageAutoKey = "automobiles";
        public EngineHorsepowerLocalStorageService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public async Task AddAutomobile(Automobile automobile)
        {
            if (automobile != null)
            {
                // Get current collection and add new autommobile value to it
                var autos = await this.GetAutomobiles();
                autos = autos.Append(automobile);
        
                await this.localStorage.SetItemAsync(this.localStorageAutoKey, autos);
            }
            
        }

        public async Task<IEnumerable<Automobile>> GetAutomobiles()
        {
            IEnumerable<Automobile> automobiles = new List<Automobile>();
            var autos  = await this.localStorage.GetItemAsync<IEnumerable<Automobile>>(this.localStorageAutoKey);
            if(autos is null)
            {
                return automobiles;
            }
            else
            {
                return autos;
            }
        }
    }
}
