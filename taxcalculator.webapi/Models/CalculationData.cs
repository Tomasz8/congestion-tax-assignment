using congestion.calculator.Interfaces;

namespace taxcalculator.webapi.Models
{
    public class CalculationData
    {
        public string VehicleTypeName { get; set; } = "";

        public DateTime[]? Dates { get; set; }
    }
}
