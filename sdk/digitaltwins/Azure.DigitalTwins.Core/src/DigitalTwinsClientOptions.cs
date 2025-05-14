// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// Options that allow configuration of requests sent to the digital twins service.
    /// </summary>
    public class DigitalTwinsClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2023_10_31;

        /// <summary>
        /// The versions of Azure Digital Twins supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// 2020-10-31
            /// </summary>
            V2020_10_31 = 1,
            /// <summary>
            /// 2022-05-31
            /// </summary>
            V2022_05_31 = 2,
            /// <summary>
            /// 2023_06_30
            /// </summary>
            V2023_06_30= 3,
            /// <summary>
            /// 2023_10_31
            /// </summary>
            V2023_10_31 = 4

#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Used to serialize and deserialize the payloads of user-provided types to/from UTF-8 encoded JSON.
        /// </summary>
        public ObjectSerializer Serializer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalTwinsClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public DigitalTwinsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V2020_10_31 => "2020-10-31",
                ServiceVersion.V2022_05_31 => "2022-05-31",
                ServiceVersion.V2023_06_30 => "2023-06-30",
                ServiceVersion.V2023_10_31 => "2023-10-31",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }
    }
}
