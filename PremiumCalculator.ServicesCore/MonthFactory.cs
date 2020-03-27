using Autofac.Features.Indexed;

namespace PremiumCalculator.ServicesCore
{
    public class MonthFactory : IMonthFactory
    {
        private readonly IIndex<string, IMonth> _monthList;


        public MonthFactory(IIndex<string, IMonth> monthList)
        {
            _monthList = monthList;
        }

        public IMonth ResolveByName(string month)
        {
            return _monthList[month];
        }
    }
}