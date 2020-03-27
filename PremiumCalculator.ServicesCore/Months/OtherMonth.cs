using System.Collections.Generic;
using PremiumCalculator.Common;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.Months
{
    public class OtherMonth : IMonth
    {
        public PremiumResponseDto GetProcessPremium(string state, int age)
        {
            var response = new PremiumResponseDto { Premium = Constants.Message };
            if (age < 18 || age > 65)
                return response;

            var others = new Dictionary<string, IHandleOther>
            {
                {Constants.States.NY, new HandleNY()},
                {Constants.States.AL, new HandleAL()},
                {Constants.States.AK, new HandleAK()},
                {Constants.States.Other, new HandleOther()}
            };

            return others[state].GetPremiumByOther();
        }
    }
}
