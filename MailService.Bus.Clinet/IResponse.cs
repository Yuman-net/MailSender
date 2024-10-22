// <copyright file="IResponse.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace MailService.Bus.Client
{
    /// <summary>
    /// Ответ.
    /// </summary>
    /// <typeparam name="T"> Тип возвращаемой переменной. </typeparam>
    public interface IResponse<T>
    {
        /// <summary>
        /// Ответ.
        /// </summary>
        public T Payload { get; set; }
    }
}
