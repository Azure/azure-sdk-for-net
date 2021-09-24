// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Security.Claims;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Contains details to SignalR connection information that is used in generating SignalR access token.
    /// </summary>
    public class SignalRConnectionDetail
    {
        /// <summary>
        /// User identity for a SignalR connection
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Custom claims that added to SignalR access token.
        /// </summary>
        public IList<Claim> Claims { get; set; }
    }
}