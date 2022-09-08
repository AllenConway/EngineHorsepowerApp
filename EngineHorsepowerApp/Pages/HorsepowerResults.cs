using EngineHorsepowerApp.Models;
using EngineHorsepowerApp.Services;
using Microsoft.AspNetCore.Components;

namespace EngineHorsepowerApp.Pages
{
    public partial class HorsepowerResults
    {
        [Inject]
        private IEngineHorsepowerDataService EngineHorsepowerDataService { get; set; } = default!;

        private string title = "Horsepower Results";

        private IEnumerable<Automobile> automobileData = new List<Automobile>();

        protected override async Task OnInitializedAsync()
        {
            automobileData = await EngineHorsepowerDataService.GetAutomobiles();
        }
    }
}
