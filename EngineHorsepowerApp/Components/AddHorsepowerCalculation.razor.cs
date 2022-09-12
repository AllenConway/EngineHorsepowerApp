using EngineHorsepowerApp.Models;
using EngineHorsepowerApp.Services;
using Microsoft.AspNetCore.Components;

namespace EngineHorsepowerApp.Components
{
    public partial class AddHorsepowerCalculation
    {
        [Inject]
        private IEngineHorsepowerDataService EngineHorsepowerDataService { get; set; } = default!;
        [Inject]
        private IEngineHorsepowerService EngineHorsepowerService { get; set; } = default!;


        private Automobile automobile = new()
        {
            Make = "Shelby",
            Model = "GT500KR",
            Year = 2009,
            Calculations = new Calculations(),
            Horsepower = new Horsepower() { FlywheelHorsepower = 0, RearWheelHorsepower = 0 }
        };

        
        private string statusMessage = string.Empty;
        private string alertClass = string.Empty;

        private async void HandleValidSubmit()
        {
            if (automobile.Calculations is not null && automobile.Calculations.Weight is not null && automobile.Calculations.EstimatedTime is not null)
            {
                automobile.Horsepower = this.EngineHorsepowerService.CalculateEngineHorsepower(automobile.Calculations);
                await this.EngineHorsepowerDataService.AddAutomobile(automobile);
                statusMessage = "Successfully saved calculations";
                alertClass = "alert-success";
                StateHasChanged();  // required as the async nature post-await not updating the UI until next action
            }
            else
            {
                statusMessage = "Required fields are missing";
                alertClass = "alert-danger";
            }
        }

        private void HandleInValidSubmit()
        {
            statusMessage = "Required fields are missing";
            alertClass = "alert-danger";
        }

        private void ClearForm()
        {
            statusMessage = string.Empty;
            alertClass = string.Empty;
        }
    }
}
