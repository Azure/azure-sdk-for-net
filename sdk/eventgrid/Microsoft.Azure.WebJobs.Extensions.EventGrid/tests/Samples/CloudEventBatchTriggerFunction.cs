// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests.Samples
{
    #region Snippet:CloudEventBatchTriggerFunction
    public static class CloudEventBatchTriggerFunction
    {
        [FunctionName("CloudEventBatchTriggerFunction")]
        public static void Run(
            ILogger logger,
            [EventGridTrigger] CloudEvent[] events)
        {
            foreach (CloudEvent cloudEvent in events)
            {
                logger.LogInformation("Event received {type} {subject}", cloudEvent.Type, cloudEvent.Subject);
            }
        }
    }
    #endregion
}