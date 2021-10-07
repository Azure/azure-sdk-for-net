// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class TriggerSingle
    {
        #region Snippet:ServiceBusTriggerSingle
        [FunctionName("TriggerSingle")]
        public static void Run(
            [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>")] string messageBodyAsString,
            ILogger logger)
        {
            logger.LogInformation($"C# function triggered to process a message: {messageBodyAsString}");
        }
        #endregion
    }
}