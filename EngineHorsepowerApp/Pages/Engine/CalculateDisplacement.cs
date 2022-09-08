using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EngineHorsepowerApp.Pages.Engine
{
    public partial class CalculateDisplacement : IAsyncDisposable
    {
        [Inject]
        private IJSRuntime JS { get; set; } = default!;

        private string title = "Engine Displacement Calculation";

        private IJSObjectReference? module;
        private string? result;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                module = await JS.InvokeAsync<IJSObjectReference>("import",
                    "./Pages/Engine/CalculateDisplacement.razor.js");
            }
        }

        private async Task TriggerPrompt()
        {
            result = await Prompt("What is the Engine Displacment?");
        }

        public async ValueTask<string?> Prompt(string message) =>
            module is not null ?
                await module.InvokeAsync<string>("showPrompt", message) : null;

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (module is not null)
            {
                await module.DisposeAsync();
            }
        }
    }
}
