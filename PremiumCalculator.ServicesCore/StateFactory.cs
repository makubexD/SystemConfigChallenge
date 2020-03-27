using Autofac.Features.Indexed;

namespace PremiumCalculator.ServicesCore
{
    public class StateFactory : IStateFactory
    {
        private readonly IIndex<string, IState> _stateList;

        public StateFactory(IIndex<string, IState> stateList)
        {
            _stateList = stateList;
        }

        public IState ResolveByName(string state)
        {
            return _stateList[state];
        }
    }
}
