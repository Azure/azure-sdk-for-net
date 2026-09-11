// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Attribute used to bind necessary information for a SignalR client to connect to SignalR Service.
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class SignalRConnectionInfoAttribute : NegotiationBaseAttribute
    {
        /// <summary>
        /// Gets or sets whether the connection supports authentication refresh.
        /// </summary>
        public bool EnableAuthenticationRefresh { get; set; }

        /// <summary>
        /// Gets or sets the maximum service access-token lifetime in seconds. Values less than one use the one-hour default.
        /// </summary>
        public int TokenLifetimeSeconds { get; set; }

        /// <summary>
        /// Gets or sets whether the connection closes when application authentication expires.
        /// </summary>
        public bool CloseOnAuthenticationExpiration { get; set; }
    }
}