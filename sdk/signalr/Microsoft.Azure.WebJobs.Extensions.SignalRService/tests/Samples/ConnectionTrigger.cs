// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples
{
    public static class ConnectionTrigger
    {
        #region Snippet:ConnectedTrigger
        [FunctionName("SignalRTest")]
        public static void Run([SignalRTrigger("<hubName>", "connections", "connected")] InvocationContext invocationContext, ILogger logger)
        {
            logger.LogInformation($"{invocationContext.ConnectionId} was connected.");
        }
        #endregion
    }
}
