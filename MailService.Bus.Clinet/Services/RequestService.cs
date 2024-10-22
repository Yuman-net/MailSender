// <copyright file="RequestService.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace MailService.Bus.Client.Services
{
    using MailService.Models;
    using MassTransit;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Интерфейс для работы с запросами в шину.
    /// </summary>
    public sealed class RequestService : IRequestService
    {
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RequestService"/>.
        /// </summary>
        /// <param name="serviceProvider"> Провайдер сервисов. </param>
        public RequestService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public async Task<bool> SendMessage(MailModel request)
        {
            var scope = this.serviceProvider.CreateScope();

            var client = scope.ServiceProvider.GetRequiredService<IRequestClient<MailModel>>();

            var response = await client.GetResponse<IResponse<bool>>(request);

            return response.Message.Payload;
        }
    }
}
