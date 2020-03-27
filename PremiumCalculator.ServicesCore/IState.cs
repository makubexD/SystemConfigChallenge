using System;
using PremiumCalculator.DTOs;

namespace PremiumCalculator.ServicesCore
{
    public interface IState
    {
        PremiumResponseDto GetPremium(DateTime dateOfBirth, int age);
    }
}