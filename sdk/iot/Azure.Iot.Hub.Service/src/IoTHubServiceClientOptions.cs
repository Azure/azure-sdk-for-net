// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Options that allow configuration of requests sent to the IoTHub service.
    /// </summary>
    public class IoTHubServiceClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2020_03_13;

        /// <summary>
        /// The versions of IoTHub Service supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// 2020-03-13
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2020_03_13 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClientOptions"/>
        /// class.
        /// </summary>
        public IoTHubServiceClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }


        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V2020_03_13 => "2020-03-13",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }
    }
}
