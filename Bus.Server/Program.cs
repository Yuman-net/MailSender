// <copyright file="Program.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace Bus.Server
{
    using Bus.Server.Extensions;
    using MailService.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Services;
    using Services.Abstract;

    /// <summary>
    /// Класс старта программы.
    /// </summary>
    public class Program
    {
        private static readonly string RabbitSectionName = "RabbitSettings";

        private static readonly string SenderSectionName = "SenderSettings";

        /// <summary>
        /// Точка входа для приложения.
        /// </summary>
        /// <param name="args"> Аргументы. </param>
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    ConfigureRabbit(context, services);
                    ConfigureSender(context, services);
                    _ = services.AddScoped<IMailSenderService, MailSenderService>();
                })
                .UseDefaultServiceProvider(options => options.ValidateOnBuild = true);
        }

        private static void ConfigureRabbit(HostBuilderContext context, IServiceCollection services)
        {
            var settings = context.Configuration.GetSection(RabbitSectionName).Get<BusSettings>();
            services.AddBusServer(settings, typeof(Program).Assembly);
        }

        private static void ConfigureSender(HostBuilderContext context, IServiceCollection services)
        {
            var settings = context.Configuration.GetSection(SenderSectionName).Get<SenderModel>();
            _ = services.AddHermes(settings);
        }
    }
}
