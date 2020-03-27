using PremiumCalculator.Common;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.Months
{
    public class December : IMonth
    {
        public PremiumResponseDto GetProcessPremium(string state, int age)
        {
            var response = new PremiumResponseDto { Premium = Constants.Message };
            if (age >= 18 && age <= 64)
                response.Premium = "125.16";
            else
                if (age > 65)
                response.Premium = "175.20";
            return response;
        }
    }
}
