// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class BindingToCollector
    {
        #region Snippet:ServiceBusBindingToCollector
        [FunctionName("BindingToCollector")]
        public static async Task Run(
            [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
            [ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")] IAsyncCollector<ServiceBusMessage> collector)
        {
            // IAsyncCollector allows sending multiple messages in a single function invocation
            await collector.AddAsync(new ServiceBusMessage(new BinaryData($"Message 1 added at: {DateTime.Now}")));
            await collector.AddAsync(new ServiceBusMessage(new BinaryData($"Message 2 added at: {DateTime.Now}")));
        }
        #endregion
    }
}