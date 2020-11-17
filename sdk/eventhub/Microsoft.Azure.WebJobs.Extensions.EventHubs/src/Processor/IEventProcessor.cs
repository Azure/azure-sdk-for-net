// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal interface IEventProcessor
    {
        Task CloseAsync(ProcessorPartitionContext context, ProcessingStoppedReason reason);
        Task OpenAsync(ProcessorPartitionContext context);
        Task ProcessErrorAsync(ProcessorPartitionContext context, Exception error);
        Task ProcessEventsAsync(ProcessorPartitionContext context, IEnumerable<EventData> messages);
    }
}
