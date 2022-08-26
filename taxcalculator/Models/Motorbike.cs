using congestion.calculator.Interfaces;

namespace congestion.calculator.Models
{
    public class Motorbike : IVehicle, ITollFreeVehicle
    {
        public string GetVehicleType()
        {
            return "Motorbike";
        }
    }
}