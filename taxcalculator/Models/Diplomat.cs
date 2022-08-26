using congestion.calculator.Interfaces;

namespace congestion.calculator.Models
{
    public class Diplomat : IVehicle, ITollFreeVehicle
    {
        public string GetVehicleType()
        {
            return "Diplomat";
        }
    }
}
