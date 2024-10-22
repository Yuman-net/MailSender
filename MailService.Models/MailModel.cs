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

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MailModel"/>.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        /// <param name="recipientAddresses"> Адреса. </param>
        /// <param name="copyAddresses"> Адреса в копии. </param>
        /// <param name="subject"> Заголовок письма. </param>
        public MailModel(
            string message,
            IEnumerable<string> recipientAddresses,
            IEnumerable<string> copyAddresses,
            string? subject = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentOutOfRangeException(nameof(message));
            }

            if (recipientAddresses is null)
            {
                throw new ArgumentOutOfRangeException(nameof(recipientAddresses));
            }

            if (!recipientAddresses.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(recipientAddresses));
            }

            this.RecipientAddresses = new List<string>(recipientAddresses);

            if (copyAddresses is null)
            {
                throw new ArgumentOutOfRangeException(nameof(copyAddresses));
            }

            if (!copyAddresses.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(copyAddresses));
            }

            this.CopyResitientAddresses = new List<string>(copyAddresses);

            this.Subject = subject;
        }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string? Subject { get; set; }

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