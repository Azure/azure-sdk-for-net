// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Azure.Messaging.EventGrid;
using Microsoft.Extensions.Logging;

namespace Azure.Extensions.WebJobs.Sample
{
    #region Snippet:EventGridEventBatchTriggerFunction
    public static class EventGridEventBatchTriggerFunction
    {
        [FunctionName("EventGridEventBatchTriggerFunction")]
        public static void Run(
            ILogger logger,
            [EventGridTrigger] EventGridEvent[] events)
        {
            foreach (EventGridEvent eventGridEvent in events)
            {
                logger.LogInformation("Event received {type} {subject}", eventGridEvent.EventType, eventGridEvent.Subject);
            }
        }
    }
    #endregion
}