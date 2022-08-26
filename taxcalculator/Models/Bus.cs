using congestion.calculator.Interfaces;

namespace congestion.calculator.Models
{
    public class Bus : IVehicle, ITollFreeVehicle
    {
        public string GetVehicleType()
        {
            return "Bus";
        }
    }
}
