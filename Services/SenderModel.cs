// <copyright file="SenderModel.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace Services
{
    public sealed class SenderModel
    {
        /// <summary>
        /// Имя отправителя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин отправителя.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль отправителя.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Порт.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Токен.
        /// </summary>
        public string Token { get; set; }
    }
}
