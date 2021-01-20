// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// The options for communication <see cref="CommunicationIdentityClientOptions"/>.
    /// </summary>
    public class CommunicationIdentityClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the token service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V1;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClientOptions"/>.
        /// </summary>
        public CommunicationIdentityClientOptions(ServiceVersion version = LatestVersion, RetryOptions? retryOptions = default, HttpPipelineTransport? transport = default)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V1 => "2021-03-07",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };

            if (transport != default)
                Transport = transport;

            if (retryOptions != null)
            {
                Retry.Mode = retryOptions.Mode;
                Retry.MaxRetries = retryOptions.MaxRetries;
                Retry.Delay = retryOptions.Delay;
                Retry.MaxDelay = retryOptions.MaxDelay;
            }
        }

        /// <summary>
        /// The token service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the token service.
            /// </summary>
            V1 = 1
        }
    }
}
