using System;
using System.Collections.Generic;
using System.Linq;
using PremiumCalculator.Common;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.States
{
    public class NYService : IState
    {
        private readonly IMonthFactory _monthFactory;

        public NYService(IMonthFactory monthFactory)
        {
            _monthFactory = monthFactory;
        }

        public PremiumResponseDto GetPremium(DateTime dateOfBirth, int age)
        {
            var month = Utils.MonthOfBirths(dateOfBirth);
            var months = new List<string> { Constants.Months.January, Constants.Months.August };
            month = months.Any(a => a == month.ToString()) ? month : Constants.MonthOfBirth.Other;
            
            return _monthFactory.ResolveByName(month.ToString()).GetProcessPremium(Constants.States.NY, age);
        }
    }
}
