using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PremiumCalculator.WebAPI.DependencyInjection.Modules;

namespace PremiumCalculator.WebAPI.DependencyInjection
{
    public class DependencyConfig
    {
        public static IServiceProvider Configure(IServiceCollection services, IConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<ApplicationServicesModule>();
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

    }
}
