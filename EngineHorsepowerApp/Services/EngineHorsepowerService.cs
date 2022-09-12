using EngineHorsepowerApp.Models;

namespace EngineHorsepowerApp.Services
{
    public class EngineHorsepowerService : IEngineHorsepowerService
    {
        public Horsepower CalculateEngineHorsepower(Calculations calculations)
        {
            var rwHorsepower = 0.0;

            var hpCalc = calculations.EstimatedTime / 5.825;
            if(hpCalc.HasValue && calculations.Weight.HasValue)
            {
                double hp = hpCalc.Value; 
                double weight = calculations.Weight.Value;
                rwHorsepower = Math.Round(weight / Math.Pow(hp, 3));
            }

            //15 percent drivetrain loss on wheel and increase at flywheel (engine horsepower)
            var flywheelHP = (rwHorsepower * 1.146);
            var fwHorsepower = Math.Round(flywheelHP);

            Horsepower hpCalcs = new Horsepower 
            {
                RearWheelHorsepower = rwHorsepower,
                FlywheelHorsepower = fwHorsepower
            };

            return hpCalcs;
        }
    }
}
