// <copyright file="IRequestService.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace MailService.Bus.Client.Services
{
    using MailService.Models;

    /// <summary>
    /// Интерфейс для работы с запросами в шину.
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Отправляет запрос в шину на отправку сообщения.
        /// </summary>
        /// <param name="request"> Запрос, содержащий модель сообщения. </param>
        /// <returns> Статус отправки сообщения: <see langword="true"/> – успешно, <see langword="false"/> в противном случае. </returns>
        Task<bool> SendMessage(MailModel request);
    }
}
