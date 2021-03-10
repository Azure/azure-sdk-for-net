// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class BindingToSender
    {
        #region Snippet:ServiceBusBindingToSender
        [FunctionName("BindingToSender")]
        public static async Task Run(
            [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
            [ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")] ServiceBusSender sender)
        {
            await sender.SendMessagesAsync(new[]
            {
                new ServiceBusMessage(new BinaryData($"Message 1 added at: {DateTime.Now}")),
                new ServiceBusMessage(new BinaryData($"Message 2 added at: {DateTime.Now}"))
            });
        }
        #endregion
    }
}