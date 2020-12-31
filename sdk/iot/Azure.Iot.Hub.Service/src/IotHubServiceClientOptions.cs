// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Options that allow configuration of requests sent to the IoTHub service.
    /// </summary>
    public class IotHubServiceClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2020_03_13;

        /// <summary>
        /// The versions of IoTHub Service supported by this client
        /// library.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Service version is not controlled by the SDK")]
        public enum ServiceVersion
        {
            /// <summary>
            /// 2020-03-13
            /// </summary>
            V2020_03_13 = 1
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IotHubServiceClientOptions"/>
        /// class.
        /// </summary>
        public IotHubServiceClientOptions(ServiceVersion version = LatestVersion)
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
