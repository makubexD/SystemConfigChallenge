using System;
using PremiumCalculator.Common;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.States
{
    public class OtherService : IState
    {
        private readonly IMonthFactory _monthFactory;

        public OtherService(IMonthFactory monthFactory)
        {
            _monthFactory = monthFactory;
        }

        public PremiumResponseDto GetPremium(DateTime dateOfBirth, int age)
        {
            var month = Constants.MonthOfBirth.Other;
            return _monthFactory.ResolveByName(month.ToString()).GetProcessPremium(Constants.States.Other, age);
        }
    }
}