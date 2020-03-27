using PremiumCalculator.Common;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.Months
{
    public class November : IMonth
    {
        public PremiumResponseDto GetProcessPremium(string state, int age)
        {
            var response = new PremiumResponseDto { Premium = Constants.Message };
            if (age >= 18 && age <= 65)
                response.Premium = "85.50";
            return response;
        }
    }
}