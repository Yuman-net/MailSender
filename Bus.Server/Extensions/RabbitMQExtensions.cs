// <copyright file="RabbitMQExtensions.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace Bus.Server.Extensions
{
    using System.Reflection;
    using MailService.Models;
    using MassTransit;
    using MassTransit.ExtensionsDependencyInjectionIntegration;
    using Microsoft.Extensions.DependencyInjection;

    public static class RabbitMQExtensions
    {
        public static IServiceCollection AddHermes(this IServiceCollection services, SenderModel model)
        {
            return services.AddSingleton(model);
        }

        public static IServiceCollection AddBusServer(this IServiceCollection services, BusSettings settings, Assembly assembly)
        {
            Assembly assembly2 = assembly;
            BusSettings settings2 = settings;

            services.AddMassTransit(configurator =>
            {
                configurator.AddConsumers(assembly2);
                configurator.UsingRabbitMq(delegate(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator factory)
                {
                    factory.ConfigureEndpoints(context);
                    factory.ConfigureHost(settings);
                });
            });
            return services;
        }

        public static void ConfigureHost(this IRabbitMqBusFactoryConfigurator configurator, BusSettings settings)
        {
            BusSettings busSettings = settings;

            configurator.Host(busSettings.Host, busSettings.VirtualHost, delegate(IRabbitMqHostConfigurator hostConfigurator)
            {
                hostConfigurator.Username(busSettings.Username);
                hostConfigurator.Password(busSettings.Password);
            });
        }
    }
}
