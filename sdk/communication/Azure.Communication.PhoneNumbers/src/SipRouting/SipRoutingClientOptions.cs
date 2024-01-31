// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2023_03_01;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SipRoutingClientOptions"/>.
        /// </summary>
        public SipRoutingClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2023_03_01 => "2023-03-01",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The phone number configuration service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The GA of the calling configuration service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2023_03_01 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores

        }
    }
}
