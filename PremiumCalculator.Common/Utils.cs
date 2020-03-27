using System;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculator.Common
{
    public static class Utils
    {
        public static int MonthOfBirths(DateTime dateTime)
        {
            var months = new List<int> {
                Constants.MonthOfBirth.January,
                Constants.MonthOfBirth.August,
                Constants.MonthOfBirth.November,
                Constants.MonthOfBirth.December
            };

            return months.Any(item => item == dateTime.Month) ? dateTime.Month : Constants.MonthOfBirth.Other;
        }

        public static int GetAge(DateTime birthDate)
        {
            return (int)Math.Floor((DateTime.Now - birthDate).TotalDays / 365.25D);
        }
    }
}
