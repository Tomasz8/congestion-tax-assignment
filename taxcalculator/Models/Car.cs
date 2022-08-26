using congestion.calculator.Interfaces;

namespace congestion.calculator.Models
{
    public class Car : IVehicle
    {
        public string GetVehicleType()
        {
            return "Car";
        }
    }
}