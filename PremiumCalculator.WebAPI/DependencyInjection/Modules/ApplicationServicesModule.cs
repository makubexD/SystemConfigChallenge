using System.Reflection;
using Autofac;
using PremiumCalculator.Common;
using PremiumCalculator.ServicesCore;
using PremiumCalculator.ServicesCore.Months;
using PremiumCalculator.ServicesCore.States;

namespace PremiumCalculator.WebAPI.DependencyInjection.Modules
{
    public class ApplicationServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(Assembly.Load("PremiumCalculator.ReadServices"))
            //    .Where(x => x.Name.EndsWith("Services"))
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<CalculatorServices>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<NYService>().As<IState>().Keyed<IState>(Constants.States.NY);
            builder.RegisterType<ALService>().As<IState>().Keyed<IState>(Constants.States.AL);
            builder.RegisterType<AKService>().As<IState>().Keyed<IState>(Constants.States.AK);
            builder.RegisterType<OtherService>().As<IState>().Keyed<IState>(Constants.States.Other);


            builder.RegisterType<August>().As<IMonth>().Keyed<IMonth>(Constants.Months.August);
            builder.RegisterType<January>().As<IMonth>().Keyed<IMonth>(Constants.Months.January);
            builder.RegisterType<November>().As<IMonth>().Keyed<IMonth>(Constants.Months.November);
            builder.RegisterType<December>().As<IMonth>().Keyed<IMonth>(Constants.Months.December);
            builder.RegisterType<OtherMonth>().As<IMonth>().Keyed<IMonth>(Constants.Months.Other);

            builder.RegisterType<HandleNY>().As<IHandleOther>().Keyed<IHandleOther>(Constants.States.NY);
            builder.RegisterType<HandleAL>().As<IHandleOther>().Keyed<IHandleOther>(Constants.States.AL);
            builder.RegisterType<HandleAK>().As<IHandleOther>().Keyed<IHandleOther>(Constants.States.AK);
            builder.RegisterType<HandleOther>().As<IHandleOther>().Keyed<IHandleOther>(Constants.States.Other);

            builder.RegisterType<MonthFactory>().As<IMonthFactory>();
            builder.RegisterType<StateFactory>().As<IStateFactory>();
        }
    }
}
