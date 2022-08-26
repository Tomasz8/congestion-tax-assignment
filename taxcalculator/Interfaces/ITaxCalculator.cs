using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Interfaces
{
    public interface ITaxCalculator
    {
        int GetTax(IVehicle vehicle, DateTime[] dates);
    }
}
