// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Quantum
{
    /// <summary>
    /// The options for quantum jobs client <see cref="QuantumJobClientOptions"/>.
    /// </summary>
    public class QuantumJobClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the service.
        /// </summary>
        public const ServiceVersion LatestVersion = ServiceVersion.V1Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumJobClientOptions"/>.
        /// </summary>
        public QuantumJobClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V1Preview => "v1.0",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Quantum Jobs service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1_Preview of the Quantum Jobs service.
            /// </summary>
            V1Preview = 1
        }
    }
}
