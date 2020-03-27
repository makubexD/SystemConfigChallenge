using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore
{
    public interface IMonth
    {
        PremiumResponseDto GetProcessPremium(string state, int age);
    }
}