// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// An input binding attribute to bind <see cref="NegotiationContext"/> to the function parameter.
    /// </summary>
    /// <remarks>Designed for function languages except C# to customize negotiation routing.</remarks>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class SignalRNegotiationAttribute : NegotiationBaseAttribute
    {
        /// <summary>
        /// Gets or sets whether negotiated connections support authentication refresh.
        /// </summary>
        public bool EnableAuthenticationRefresh { get; set; }

        /// <summary>
        /// Gets or sets the maximum service access-token lifetime in seconds. Values less than one use the one-hour default.
        /// </summary>
        public int TokenLifetimeSeconds { get; set; }

        /// <summary>
        /// Gets or sets whether negotiated connections close when application authentication expires.
        /// </summary>
        public bool CloseOnAuthenticationExpiration { get; set; }
    }
}