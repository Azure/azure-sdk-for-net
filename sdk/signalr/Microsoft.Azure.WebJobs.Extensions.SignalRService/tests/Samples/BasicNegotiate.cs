// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples
{
    public static class BasicNegotiate
    {
        #region Snippet:BasicNegotiate
        [FunctionName("Negotiate")]
        public static SignalRConnectionInfo Negotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "<hub_name>", UserId = "<user_id>")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }
        #endregion
    }
}
