
using System.ComponentModel.DataAnnotations;

namespace EngineHorsepowerApp.Models
{
    public class Calculations
    {
        [Required]
        [Range (1, 10000)]
        public double? Weight { get; set; }
        [Required]
        [Range (3, 25)]
        public double? EstimatedTime { get; set; }
    }
}
