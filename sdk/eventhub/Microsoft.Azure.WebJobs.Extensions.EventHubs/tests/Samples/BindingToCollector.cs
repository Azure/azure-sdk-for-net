// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;

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
            // IAsyncCollector allows sending multiple events in a single function invocation
            await collector.AddAsync(new EventData(new BinaryData($"Event 1 added at: {DateTime.Now}")));
            await collector.AddAsync(new EventData(new BinaryData($"Event 2 added at: {DateTime.Now}")));
        }
        #endregion
    }
}