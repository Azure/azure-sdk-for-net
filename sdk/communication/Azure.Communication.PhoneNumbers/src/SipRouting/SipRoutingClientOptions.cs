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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_05_01_preview1;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SipRoutingClientOptions"/>.
        /// </summary>
        public SipRoutingClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_05_01_preview1 => "2021-05-01-preview1",
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
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable AZC0016 // All parts of ServiceVersion members' names must begin with a number or uppercase letter and cannot have consecutive underscores
            V2021_05_01_preview1 = 1
#pragma warning restore AZC0016 // All parts of ServiceVersion members' names must begin with a number or uppercase letter and cannot have consecutive underscores
#pragma warning restore CA1707 // Identifiers should not contain underscores

        }
    }
}
