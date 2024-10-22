// <copyright file="MailSenderConsumer.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace Bus.Server.Consumers
{
    using MailService.Models;
    using MassTransit;
    using Services.Abstract;

    /// <summary>
    /// Обработчик запросов о посылке сообщений (<see cref="MailModel"/>).
    /// </summary>
    public sealed class MailSenderConsumer : IConsumer<MailModel>
    {
        private readonly IMailSenderService service;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MailSenderConsumer"/>.
        /// </summary>
        /// <param name="service"> Сервис, отвечающий за рассылку.  </param>
        public MailSenderConsumer(IMailSenderService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <inheritdoc/>
        public async Task Consume(ConsumeContext<MailModel> context)
        {
            var result = await this.service.SendEmailAsync(context.Message);

            await context.RespondAsync(new Responce<bool>(result));
        }
    }
}
