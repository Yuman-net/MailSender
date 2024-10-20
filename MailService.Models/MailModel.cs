// <copyright file="MailModel.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace MailService.Models
{
    /// <summary>
    /// Модель электронного письма.
    /// </summary>
    public sealed class MailModel
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MailModel"/>.
        /// </summary>
        public MailModel()
        {
        }

        public MailModel(string message, string address, string? subject = null)
            : this(message, )
        {
            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MailModel"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="address"></param>
        /// <param name="recipientAddresses"></param>
        /// <param name="copyAddresses"></param>
        /// <param name="subject"></param>
        public MailModel(string message,
                         string address,
                         IEnumerable<string> recipientAddresses,
                         IEnumerable<string> copyAddresses,
                         string? subject = null)
        {
            
        }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Адреса получателей.
        /// </summary>
        public List<string> RecipientAddresses { get; set; }

        /// <summary>
        /// Адреса получателей, которые указаны в копии.
        /// </summary>
        public List<string> CopyResitientAddresses { get; set; }

        /// <summary>
        /// Тело письма.
        /// </summary>
        public string Message { get; set; }
    }
}