using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore.Months
{   
    public class HandleNY : IHandleOther
    {
        public PremiumResponseDto GetPremiumByOther()
        {
            return new PremiumResponseDto { Premium = "120.99" };
        }
    }

    public class HandleAL : IHandleOther
    {
        public PremiumResponseDto GetPremiumByOther()
        {
            return new PremiumResponseDto { Premium = "100.00" };
        }
    }

    public class HandleAK : IHandleOther
    {
        public PremiumResponseDto GetPremiumByOther()
        {
            return new PremiumResponseDto { Premium = "100.80" };
        }
    }

    public class HandleOther : IHandleOther
    {
        public PremiumResponseDto GetPremiumByOther()
        {
            return new PremiumResponseDto { Premium = "90.00" };
        }
    }
}
