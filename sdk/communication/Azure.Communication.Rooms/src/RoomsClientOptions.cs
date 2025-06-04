// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Rooms
{
    /// <summary>
    /// The options for communication <see cref="RoomsClient"/>.
    /// </summary>
    public class RoomsClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2025_03_13;
        internal const ServiceVersion PstnVersion = ServiceVersion.V2024_04_15;
        internal const ServiceVersion GeneralAvailability = ServiceVersion.V2023_06_14;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClientOptions"/> class.
        /// </summary>
        /// <param name="version"></param>
        public RoomsClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2025_03_13 => "2025-03-13",
                ServiceVersion.V2023_06_14 => "2023-06-14",
                ServiceVersion.V2024_04_15 => "2024-04-15",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }
        /// <summary>
        /// The Room Service Version.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Rooms service General Availability version 2023-06-14
            /// </summary>
            V2023_06_14 = 1,

            /// <summary>
            /// Rooms service preview version V2024-04-15
            /// </summary>
            V2024_04_15 = 2,

            /// <summary>
            /// Rooms service preview version V2025-03-13
            /// </summary>
            V2025_03_13 = 3,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
