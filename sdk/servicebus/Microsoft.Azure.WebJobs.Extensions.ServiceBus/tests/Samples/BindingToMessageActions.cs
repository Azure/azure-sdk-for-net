// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class BindingToMessageActions
    {
        #region Snippet:ServiceBusBindingToMessageActions
        [FunctionName("BindingToMessageActions")]
        public static async Task Run(
            [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>")]
            ServiceBusReceivedMessage[] messages,
            ServiceBusMessageActions messageActions)
        {
            foreach (ServiceBusReceivedMessage message in messages)
            {
                if (message.MessageId == "1")
                {
                    await messageActions.DeadLetterMessageAsync(message);
                }
                else
                {
                    await messageActions.CompleteMessageAsync(message);
                }
            }
        }
        #endregion
    }
}
