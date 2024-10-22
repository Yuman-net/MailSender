// <copyright file="BusSettings.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace Bus.Server
{
    /// <summary>
    /// Настройки шины.
    /// </summary>
    public sealed class BusSettings
    {
        /// <summary>
        /// Адрес хоста шины.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Виртуальный хост внутри шины.
        /// </summary>
        public string VirtualHost { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Пароль для доступа к шине.
        /// </summary>
        public string Password { get; set; }
    }
}
