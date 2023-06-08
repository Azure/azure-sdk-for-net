// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Processor
{
    internal interface IProcessedMessages
    {
        ICollection<ServiceBusReceivedMessage> ProcessedMessages { get; }
    }
}
