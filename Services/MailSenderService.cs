// <copyright file="MailSenderService.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace Services
{
    using MailKit.Net.Smtp;
    using MailService.Models;
    using MimeKit;
    using Services.Abstract;

    /// <summary>
    /// Сервис по отправке электронных сообщений.
    /// </summary>
    public sealed class MailSenderService : IMailSenderService
    {
        private readonly SenderModel senderModel;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MailSenderService"/>.
        /// </summary>
        /// <param name="senderModel"> Модель отправителя. </param>
        public MailSenderService(SenderModel senderModel)
        {
            this.senderModel = senderModel ?? throw new ArgumentNullException(nameof(senderModel));
        }

        /// <inheritdoc/>
        public async Task<bool> SendEmailAsync(MailModel mailModel)
        {
            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = mailModel.Message,
            };

            var emailMessage = new MimeMessage
            {
                Body = bodyBuilder.ToMessageBody(),
                Subject = mailModel.Subject,
                Importance = MessageImportance.High,
            };

            emailMessage.From.Add(new MailboxAddress(this.senderModel.Name, this.senderModel.Login));
            emailMessage.To.AddRange(mailModel.RecipientAddresses.Select(GetAddress));
            emailMessage.Cc.AddRange(mailModel.CopyResitientAddresses.Select(GetAddress));

            using var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (sender, certificate, chain, errors) =>
                {
                    // Accept all certificates, regardless of errors
                    return true;
                },
            };

            await client.ConnectAsync(this.senderModel.Token, this.senderModel.Port);
            await client.AuthenticateAsync(this.senderModel.Login, this.senderModel.Password);

            try
            {
                _ = await client.SendAsync(emailMessage);
                client.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {
                client.Disconnect(true);
                return false;
            }
        }

        private static MailboxAddress GetAddress(string email)
        {
            var name = email[..email.IndexOf("@")].Replace(".", " ");
            return new MailboxAddress(name, email);
        }
    }
}