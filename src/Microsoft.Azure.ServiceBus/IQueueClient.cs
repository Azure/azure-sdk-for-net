// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using Core;

    public interface IQueueClient : IReceiverClient, ISenderClient
    {
        string QueueName { get; }
    }
}