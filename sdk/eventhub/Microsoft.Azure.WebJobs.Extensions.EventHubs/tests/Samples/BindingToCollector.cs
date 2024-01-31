// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests.Samples
{
    public static class BindingToCollector
    {
        #region Snippet:BindingToCollector
        [FunctionName("BindingToCollector")]
        public static async Task Run(
            [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
            [EventHub("<event_hub_name>", Connection = "<connection_name>")] IAsyncCollector<EventData> collector)
        {
            // When no partition key is used, partitions will be assigned per-batch via round-robin.
            await collector.AddAsync(new EventData($"Event 1 added at: {DateTime.Now}"));
            await collector.AddAsync(new EventData($"Event 2 added at: {DateTime.Now}"));

            // Using a partition key will help group events together; events with the same key
            // will always be assigned to the same partition.
            await collector.AddAsync(new EventData($"Event 3 added at: {DateTime.Now}"), "sample-key");
            await collector.AddAsync(new EventData($"Event 4 added at: {DateTime.Now}"), "sample-key");
        }
        #endregion
    }
}