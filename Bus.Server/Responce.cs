// <copyright file="Responce.cs" company="Andrey Nikolaev">
// Copyright (c) Andrey Nikolaev. All rights reserved.
// </copyright>

namespace Bus.Server
{
    public sealed class Responce<T> : IResponse<T>
    {
        public T Payload { get; set; }

        public Responce(T Payload)
        {
            this.Payload = Payload;
        }
    }

    public interface IResponse<T>
    {
        public T Payload { get; set; }
    }
}
