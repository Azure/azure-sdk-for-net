// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Security.Claims;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Contains details to SignalR connection information that is used in generating SignalR access token.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is a DTO.")]
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

        /// <summary>
        /// Gets or sets the application authentication expiration used by authentication refresh.
        /// </summary>
        public DateTimeOffset? AuthenticationExpiresOn { get; set; }
    }
}