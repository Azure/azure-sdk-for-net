// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Attribute used to refresh the authentication of a live SignalR client connection without reconnecting.
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class SignalRRefreshAttribute : NegotiationBaseAttribute
    {
        /// <summary>
        /// Gets or sets the connection token of the live client connection to refresh.
        /// </summary>
        [AutoResolve]
        public string ConnectionToken { get; set; }

        /// <summary>
        /// Gets or sets the new authentication lifetime, in seconds, applied to the connection.
        /// </summary>
        public int TokenLifetimeSeconds { get; set; }
    }
}
