// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class BindingToSessionMessageActions
    {
        #region Snippet:ServiceBusBindingToSessionMessageActions
        [FunctionName("BindingToSessionMessageActions")]
        public static async Task Run(
            [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>", IsSessionsEnabled = true)]
            ServiceBusReceivedMessage[] messages,
            ServiceBusSessionMessageActions sessionActions)
        {
            foreach (ServiceBusReceivedMessage message in messages)
            {
                if (message.MessageId == "1")
                {
                    await sessionActions.DeadLetterMessageAsync(message);
                }
                else
                {
                    await sessionActions.CompleteMessageAsync(message);
                }
            }

            // We can also perform session-specific operations using the actions, such as setting state that is specific to this session.
            await sessionActions.SetSessionStateAsync(new BinaryData("<session state>"));
        }
        #endregion
    }
}