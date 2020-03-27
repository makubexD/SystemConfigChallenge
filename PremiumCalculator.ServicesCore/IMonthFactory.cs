namespace PremiumCalculator.ServicesCore
{
    public interface IMonthFactory
    {
        IMonth ResolveByName(string month);
    }
}