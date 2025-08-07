// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal interface IEventProcessor
    {
        Task CloseAsync(EventProcessorHostPartition context, ProcessingStoppedReason reason);
        Task OpenAsync(EventProcessorHostPartition context);
        Task ProcessErrorAsync(EventProcessorHostPartition context, Exception error);
        Task ProcessEventsAsync(EventProcessorHostPartition context, IEnumerable<EventData> messages);
    }
}
