// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples
{
    public static class MessageTrigger
    {
        #region Snippet:MessageTrigger
        [FunctionName("SignalRTest")]
        public static void Run([SignalRTrigger("SignalRTest", "messages", "SendMessage")] InvocationContext invocationContext, [SignalRParameter] string message, ILogger logger)
        {
            logger.LogInformation($"Receive {message} from {invocationContext.ConnectionId}.");
        }
        #endregion
    }
}
