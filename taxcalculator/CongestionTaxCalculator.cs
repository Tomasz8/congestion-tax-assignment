using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using congestion.calculator.Extensions;
using congestion.calculator.Interfaces;
using congestion.calculator.Models;

namespace congestion.calculator
{
    public class CongestionTaxCalculator : ITaxCalculator
    {
        private const string taxFeesFileName = "taxfees.json";

        private List<CongestionTax> taxFees = new List<CongestionTax>();

        public CongestionTaxCalculator()
        {

            string jsonString = File.ReadAllText(taxFeesFileName);

            if (jsonString != null)
            {
                taxFees = JsonSerializer.Deserialize<IEnumerable<CongestionTax>>(jsonString).ToList();
            }

        }

        /**
             * Calculate the total toll fee for one day
             *
             * @param vehicle - the vehicle
             * @param dates   - date and time of all passes on one day
             * @return - the total congestion tax for that day
             */

        public int GetTax(IVehicle vehicle, DateTime[] dates)
        {
            var totalFee = 0;

            DateTime intervalStart = dates[0];
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                if ((date - intervalStart).TotalMinutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                    intervalStart = date;
                }
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;

        }


        private bool IsTollFreeVehicle(IVehicle vehicle) => vehicle == null || vehicle is ITollFreeVehicle;


        private int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (date.IsTollFreeDate() || IsTollFreeVehicle(vehicle)) return 0;

            if (taxFees == null) throw new NullReferenceException("Tax fees missing!");

            foreach (var taxFee in taxFees)
            {
                if (date.IsBetweenTimes(TimeSpan.Parse(taxFee.Start), TimeSpan.Parse(taxFee.End))) return taxFee.Tax;
            }

            return 0;
        }

    }
}