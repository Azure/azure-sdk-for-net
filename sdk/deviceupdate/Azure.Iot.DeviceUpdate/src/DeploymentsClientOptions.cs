// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Iot.DeviceUpdate
{
    /// <summary>
    /// The options for <see cref="DeploymentsClient"/>.
    /// </summary>
    public class DeploymentsClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentsClientOptions"/>.
        /// </summary>
        public DeploymentsClientOptions(ServiceVersion version = ServiceVersion.V2020_09_01)
        {
            Version = version switch
            {
                ServiceVersion.V2020_09_01 => "1.0",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>
        /// Deployment management service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The public preview version of the service.
            /// </summary>
#pragma warning disable CA1707 // Remove the underscores from member name
            V2020_09_01 = 1
#pragma warning restore
        }
    }
}
