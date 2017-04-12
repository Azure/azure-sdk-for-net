// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IReceiverClient : IClientEntity
    {
        string Path { get; }

        ReceiveMode ReceiveMode { get; }

        void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler);

        void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, RegisterMessageHandlerOptions registerHandlerOptions);

        Task CompleteAsync(string lockToken);

        Task AbandonAsync(string lockToken);

        Task DeadLetterAsync(string lockToken);
    }
}