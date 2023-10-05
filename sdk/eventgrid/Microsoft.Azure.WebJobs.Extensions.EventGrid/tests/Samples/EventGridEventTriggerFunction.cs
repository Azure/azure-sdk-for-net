// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Azure.Messaging.EventGrid;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests.Samples
{
    #region Snippet:EventGridEventTriggerFunction
    public static class EventGridEventTriggerFunction
    {
        [FunctionName("EventGridEventTriggerFunction")]
        public static void Run(
            ILogger logger,
            [EventGridTrigger] EventGridEvent e)
        {
            logger.LogInformation("Event received {type} {subject}", e.EventType, e.Subject);
        }
    }
    #endregion
}
