using congestion.calculator;
using congestion.calculator.Interfaces;
using congestion.calculator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taxcalculator.webapi.Models;

namespace taxcalculator.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly ITaxCalculator _taxCalculator;

        public TaxCalculatorController(ITaxCalculator taxCalculator, ILogger<TaxCalculatorController> logger)
        {
            _logger = logger;
            _taxCalculator = taxCalculator;
        }

        [HttpPost(Name = "Calculate")]
        public CalculationResult Calculate(CalculationData postModel)
        {
            if (postModel == null) throw new ArgumentNullException(nameof(postModel));
            if (string.IsNullOrWhiteSpace(postModel.VehicleTypeName)) throw new ArgumentNullException(nameof(postModel.VehicleTypeName));
            if (postModel.Dates == null) throw new ArgumentNullException(nameof(postModel.Dates));

            var vehicle = GetVehicleType(postModel.VehicleTypeName);
            return new CalculationResult()
            {
                VehicleType = vehicle.GetVehicleType(),
                Tax = CalculateTax(vehicle, postModel.Dates.OrderBy(x => x).ToArray())
            };
        }


        private int CalculateTax(IVehicle vehicle, DateTime[] allDates)
        {
            var dayTax = new Dictionary<DateTime, int>();

            foreach (var day in allDates.Select(x => x.Date).Distinct())
            {
                dayTax.Add(day, _taxCalculator.GetTax(vehicle, allDates.Where(x => x.Date.CompareTo(day) == 0).ToArray()));
            }

            return dayTax.Sum(x => x.Value);
        }

        //TO DO: this can be make better, f.x. with reflections
        private static IVehicle GetVehicleType(string vehicleParam) => vehicleParam.ToLower() switch
        {
            "car" => new Car(),
            "diplomat" => new Diplomat(),
            "emergency" => new Emergency(),
            "foreign" => new Foreign(),
            "military" => new Military(),
            "motorbike" => new Motorbike(),
            "bus" => new Bus(),
            _ => new Other()
        };
    }
}
