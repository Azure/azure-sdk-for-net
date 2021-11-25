// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public class BindingToClient
    {
        #region Snippet:ServiceBusBindingToClient
        [FunctionName("BindingToClient")]
        public static async Task Run(
            [ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")]
            ServiceBusReceivedMessage message,
            ServiceBusClient client)
        {
            ServiceBusSender sender = client.CreateSender(message.To);
            await sender.SendMessageAsync(new ServiceBusMessage(message));
        }
        #endregion
    }
}