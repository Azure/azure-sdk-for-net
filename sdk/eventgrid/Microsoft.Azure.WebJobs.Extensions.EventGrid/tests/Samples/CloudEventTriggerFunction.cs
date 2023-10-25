// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests.Samples
{
    #region Snippet:CloudEventTriggerFunction
    public static class CloudEventTriggerFunction
    {
        [FunctionName("CloudEventTriggerFunction")]
        public static void Run(
            ILogger logger,
            [EventGridTrigger] CloudEvent e)
        {
            logger.LogInformation("Event received {type} {subject}", e.Type, e.Subject);
        }
    }
    #endregion
}