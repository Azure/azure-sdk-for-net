// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// The base class of input binding attributes used for SignalR client negotiation.
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public abstract class NegotiationBaseAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the app setting name that contains the SignalR connection.
        /// </summary>
        public string ConnectionStringSetting { get; set; } = Constants.AzureSignalRConnectionStringName;

        /// <summary>
        /// Gets or sets the name of the hub to which the SignalR client is going to connect.
        /// </summary>
        [AutoResolve]
        public string HubName { get; set; }

        /// <summary>
        /// Gets or sets the user id assigned to the SignalR client.
        /// </summary>
        [AutoResolve]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the JWT token whose claims will be added to the user claims.
        /// </summary>
        [AutoResolve]
        public string IdToken { get; set; }

        /// <summary>
        /// Gets or sets the claim type list used to filter the claims in the <see cref="IdToken"/>.
        /// </summary>
        public string[] ClaimTypeList { get; set; }

        /// <summary>
        /// Gets or sets the application authentication deadline as a timestamp parsed using the invariant culture.
        /// A timestamp without a time zone offset is interpreted as UTC.
        /// During refresh, omitting this value preserves the existing deadline.
        /// </summary>
        [AutoResolve]
        public string AuthenticationExpiresOn { get; set; }

        internal DateTimeOffset? ResolveAuthenticationExpiresOn()
        {
            if (AuthenticationExpiresOn is null)
            {
                return null;
            }

            if (!DateTimeOffset.TryParse(AuthenticationExpiresOn, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var expiresOn))
            {
                throw new FormatException($"{nameof(AuthenticationExpiresOn)} must be a valid timestamp in the invariant culture.");
            }
            return expiresOn;
        }
    }
}