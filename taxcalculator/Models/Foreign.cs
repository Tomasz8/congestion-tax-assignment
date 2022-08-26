using congestion.calculator.Interfaces;

namespace congestion.calculator.Models
{
    public class Foreign : IVehicle, ITollFreeVehicle
    {
        public string GetVehicleType()
        {
            return "Foreign";
        }
    }
}
