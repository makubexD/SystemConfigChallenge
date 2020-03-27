using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore
{
    public interface IHandleOther
    {
        PremiumResponseDto GetPremiumByOther();
    }
}
