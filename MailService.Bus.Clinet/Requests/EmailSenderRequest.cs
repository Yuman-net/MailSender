// <copyright file="EmailSenderRequest.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace MailService.Bus.Client.Requests
{
    public sealed class EmailSenderRequest
    {
        /// <summary>
        /// Адрес получателя.
        /// </summary>
        public List<string> RecipientAddresses { get; set; }

        /// <summary>
        /// Тема письма.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Тело письма.
        /// </summary>
        public string Message { get; set; }
    }
}