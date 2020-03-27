using PremiumCalculator.Common;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.Months
{
    public class January : IMonth
    {
        public PremiumResponseDto GetProcessPremium(string state, int age)
        {
            var response = new PremiumResponseDto { Premium = Constants.Message };
            if (age >= 46 && age <= 65)
                response.Premium = "200.50";
            return response;
        }
    }
}