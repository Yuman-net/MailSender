// <copyright file="IBusClient.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace MailService.Bus.Client.Abstract
{
    /// <summary>
    /// Клиент для общения с шиной.
    /// </summary>
    public interface IBusClient
    {
        /// <summary>
        /// Отправляет email.
        /// </summary>
        /// <param name="message"> Тело сообщения. </param>
        /// <param name="addresses"> Адреса. </param>
        /// <param name="copyAddresses"> Адреса в копии. </param>
        /// <param name="subject"> Заголовок письма. </param>
        /// <returns>
        /// Статус отправки сообщения: <see langword="true"/> - успешно, <see langword="false"/> в противном случае.
        /// </returns>
        Task<bool> SendEmailMessage(string message, IEnumerable<string> addresses, IEnumerable<string> copyAddresses, string subject);
    }
}
