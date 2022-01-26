// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    /// <summary>
    /// The options for calling configuration client options <see cref="SipRoutingClientOptions"/>.
    /// </summary>
    public class SipRoutingClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the calling configuration service.
        /// </summary>
        private const ServiceVersion LatestVersion = ServiceVersion.V1;
        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SipRoutingClientOptions"/>.
        /// </summary>
        public SipRoutingClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V1 => "2021-05-01-preview1",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The phone number configuration service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the calling configuration service.
            /// </summary>
            V1 = 1
        }
    }
}
