using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace congestion.calculator.Extensions
{
    public static class DateTimeExtentions
    {
        public static bool IsBetweenTimes(this DateTime date, TimeSpan start, TimeSpan end)
        {
            var timePoint = date.TimeOfDay;
            return (start <= end && (timePoint >= start && timePoint <= end))
                || (start > end && ((timePoint >= end && timePoint <= start)));
        }


        public static bool IsTollFreeDate(this DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
