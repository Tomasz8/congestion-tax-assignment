using congestion.calculator.Interfaces;

namespace congestion.calculator.Models
{
    public class Military : IVehicle, ITollFreeVehicle
    {
        public string GetVehicleType()
        {
            return "Military";
        }
    }
}
