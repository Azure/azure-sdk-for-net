// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests.Samples
{
    public static class BindingToProducerClient
    {
        #region Snippet:BindingToProducerClient
        [FunctionName("BindingToProducerClient")]
        public static async Task Run(
            [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
            [EventHub("<event_hub_name>", Connection = "<connection_name>")] EventHubProducerClient eventHubProducerClient)
        {
            // IAsyncCollector allows sending multiple events in a single function invocation
            await eventHubProducerClient.SendAsync(new[]
            {
                new EventData($"Event 1 added at: {DateTime.Now}"),
                new EventData($"Event 2 added at: {DateTime.Now}")
            });
        }
        #endregion
    }
}