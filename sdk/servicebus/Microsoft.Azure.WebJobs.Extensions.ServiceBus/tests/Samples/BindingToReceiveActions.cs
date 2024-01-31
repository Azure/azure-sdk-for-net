// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class BindingToReceiveActions
    {
        #region Snippet:ServiceBusBindingToReceiveActions
        [FunctionName("BindingToReceiveActions")]
        public static async Task Run(
            [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>", IsSessionsEnabled = true)]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions,
            ServiceBusReceiveActions receiveActions)
        {
            if (message.MessageId == "1")
            {
                await messageActions.DeadLetterMessageAsync(message);
            }
            else
            {
                await messageActions.CompleteMessageAsync(message);

                // attempt to receive additional messages in this session
                var receivedMessages = await receiveActions.ReceiveMessagesAsync(maxMessages: 10);

                // you can also use the receive actions to peek messages
                var peekedMessages = await receiveActions.PeekMessagesAsync(maxMessages: 10);
            }
        }
        #endregion
    }
}