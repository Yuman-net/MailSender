// <copyright file="IMailSenderService.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

using MailService.Models;

namespace Services.Abstract
{
    /// <summary>
    /// Сервис по отправке электронных сообщений.
    /// </summary>
    public interface IMailSenderService
    {
        Task<bool> SendEmailAsync(MailModel mailModel);
    }
}
