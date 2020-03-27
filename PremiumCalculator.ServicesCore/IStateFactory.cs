namespace PremiumCalculator.ServicesCore
{
    public interface IStateFactory
    {
        IState ResolveByName(string state);
    }
}