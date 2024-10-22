// <copyright file="BusClient.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace MailService.Bus.Client
{
    using MailService.Bus.Client.Abstract;
    using MailService.Bus.Client.Services;
    using MailService.Models;

    /// <summary>
    /// Клиент для общения с шиной.
    /// </summary>
    public sealed class BusClient : IBusClient
    {
        private readonly IRequestService requestService;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BusClient"/>.
        /// </summary>
        /// <param name="requestService"> Запрос в шину. </param>
        public BusClient(IRequestService requestService)
        {
            this.requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
        }

        /// <inheritdoc/>
        public async Task<bool> SendEmailMessage(string message, IEnumerable<string> addresses, IEnumerable<string> copyAddresses, string subject)
        {
            var request = new MailModel(message, addresses, copyAddresses, subject);

            return await this.requestService.SendMessage(request);
        }
    }
}
