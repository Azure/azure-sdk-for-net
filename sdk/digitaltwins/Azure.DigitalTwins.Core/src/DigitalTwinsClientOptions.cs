// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// Options that allow configuration of requests sent to the digital twins service.
    /// </summary>
    public class DigitalTwinsClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2020_05_31_preview;

        /// <summary>
        /// The versions of Azure Digital Twins supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores

            /// <summary>
            /// 2020-05-31-preview
            /// </summary>
            V2020_05_31_preview = 1

#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

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
                ServiceVersion.V2020_05_31_preview => "2020-05-31-preview",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }
    }
}
