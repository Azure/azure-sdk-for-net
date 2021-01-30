// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests.Samples
{
    public static class TriggerSingle
    {
        #region Snippet:TriggerSingle
        [FunctionName("TriggerSingle")]
        public static void Run(
            [EventHubTrigger("<event_hub_name>", Connection = "<connection_name>")] string eventBodyAsString,
            ILogger logger)
        {
            logger.LogInformation($"C# function triggered to process a message: {eventBodyAsString}");
        }
        #endregion
    }
}