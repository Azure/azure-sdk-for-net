// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class TriggerBatch
    {
        #region Snippet:ServiceBusTriggerBatch
        [FunctionName("TriggerBatch")]
        public static void Run(
            [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>")] ServiceBusReceivedMessage[] messages,
            ILogger logger)
        {
            foreach (ServiceBusReceivedMessage message in messages)
            {
                logger.LogInformation($"C# function triggered to process a message: {message.Body}");
                logger.LogInformation($"EnqueuedTime={message.EnqueuedTime}");
            }
        }
        #endregion
    }
}