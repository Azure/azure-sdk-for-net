// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Azure.Messaging.EventGrid;
using Microsoft.Extensions.Logging;

namespace Azure.Extensions.WebJobs.Sample
{
    #region Snippet:EventGridTriggerFunction
    public static class EventGridTriggerFunction
    {
        [FunctionName("EventGridTriggerFunction")]
        public static void Run(
            ILogger logger,
            [EventGridTrigger] EventGridEvent e)
        {
            logger.LogInformation("Event received {type} {subject}", e.EventType, e.Subject);
        }
    }
    #endregion
}
