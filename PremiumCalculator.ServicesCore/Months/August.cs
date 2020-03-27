using PremiumCalculator.Common;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.Months
{
    public class August : IMonth
    {
        public PremiumResponseDto GetProcessPremium(string state, int age)
        {
            var response = new PremiumResponseDto { Premium = Constants.Message };
            if (age >= 18 && age <= 45)
                response.Premium = "150.00";
            return response;
        }
    }
}
