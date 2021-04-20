// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The options for communication <see cref="CallClient"/>.
    /// </summary>
    public class CallClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Calling Server service.
        /// </summary>
        public const ServiceVersion LatestVersion = ServiceVersion.V2021_04_15_Preview1;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallClientOptions"/>.
        /// </summary>
        public CallClientOptions(ServiceVersion version = LatestVersion, RetryOptions? retryOptions = default, HttpPipelineTransport? transport = default)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_04_15_Preview1 => "2021-04-15-preview1",

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
        /// The Sms service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The Beta of the Sms service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2021_04_15_Preview1 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
