using System;
using System.Collections.Generic;
using System.Linq;
using PremiumCalculator.Common;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.States
{
    public class AKService : IState
    {
        private readonly IMonthFactory _monthFactory;

        public AKService(IMonthFactory monthFactory)
        {
            _monthFactory = monthFactory;
        }

        public PremiumResponseDto GetPremium(DateTime dateOfBirth, int age)
        {
            var month = Utils.MonthOfBirths(dateOfBirth);
            var months = new List<int> { Constants.MonthOfBirth.December };
            month = months.Any(a => a == month) ? month : Constants.MonthOfBirth.Other;
            
            return _monthFactory.ResolveByName(month.ToString()).GetProcessPremium(Constants.States.AK, age);
        }
    }
}
