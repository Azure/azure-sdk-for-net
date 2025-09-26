// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The options for communication <see cref="TelcoMessagingClient"/>.
    /// </summary>
    public class TelcoMessagingClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Telco Messaging service.
        /// </summary>
        private const ServiceVersion LatestVersion = ServiceVersion.V2025_08_01_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelcoMessagingClientOptions"/>.
        /// </summary>
        public TelcoMessagingClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_03_07 => "2021-03-07",
                ServiceVersion.V2025_08_01_Preview => "2025-08-01-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Telco Messaging service version.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The "2021-03-07" version of the Telco Messaging service.
            /// </summary>
            V2021_03_07 = 1,
            /// <summary>
            /// The "2025-08-01-preview" of the Telco Messaging service.
            /// </summary>
            V2025_08_01_Preview = 2
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
