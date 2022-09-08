
using System.ComponentModel.DataAnnotations;

namespace EngineHorsepowerApp.Models
{
    public class Automobile
    {
        public int Year { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public Horsepower? Horsepower { get; set; }
        [ValidateComplexType]   
        public Calculations? Calculations { get; set; }
    }
}
