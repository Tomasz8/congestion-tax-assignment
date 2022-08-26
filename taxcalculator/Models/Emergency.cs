using congestion.calculator.Interfaces;

namespace congestion.calculator.Models
{
    public class Emergency : IVehicle, ITollFreeVehicle
    {
        public string GetVehicleType()
        {
            return "Emergency";
        }
    }
}
