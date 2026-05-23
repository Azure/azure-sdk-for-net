// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests.Samples
{
    public static class TriggerBatch
    {
        #region Snippet:TriggerBatch
        [FunctionName("TriggerBatch")]
        public static void Run(
            [EventHubTrigger("<event_hub_name>", Connection = "<connection_name>")] EventData[] events,
            ILogger logger)
        {
            foreach (var e in events)
            {
                logger.LogInformation($"C# function triggered to process a message: {e.EventBody}");
                logger.LogInformation($"EnqueuedTime={e.EnqueuedTime}");
            }
        }
        #endregion
    }
}