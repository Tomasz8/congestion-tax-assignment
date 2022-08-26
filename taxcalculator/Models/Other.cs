using congestion.calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Models
{
    public class Other : IVehicle
    {
        public string GetVehicleType()
        {
            return "other";
        }
    }
}
