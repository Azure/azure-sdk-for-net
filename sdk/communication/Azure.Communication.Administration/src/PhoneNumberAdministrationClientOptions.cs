// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// The options for phone number management client options. <see cref="PhoneNumberAdministrationClientOptions"/>
    /// </summary>
    public class PhoneNumberAdministrationClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Phone number management service.
        /// </summary>
        public const ServiceVersion LatestVersion = ServiceVersion.V1;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberAdministrationClientOptions"/>.
        /// </summary>
        public PhoneNumberAdministrationClientOptions(ServiceVersion version = LatestVersion, RetryOptions? retryOptions = default, HttpPipelineTransport? transport = default)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V1 => "2020-07-20-preview1",
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
        /// The phone number configuration service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the phone number configuration service.
            /// </summary>
            V1 = 1
        }
    }
}
