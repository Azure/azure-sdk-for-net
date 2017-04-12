// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Core;

    public interface IMessageSession : IMessageReceiver
    {
        string SessionId { get; }

        DateTime LockedUntilUtc { get; }

        Task<Stream> GetStateAsync();

        Task SetStateAsync(Stream sessionState);

        Task RenewSessionLockAsync();
    }
}