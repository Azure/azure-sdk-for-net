// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// </summary>
    public class MetricsAdvisorClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary>
        /// </summary>
        public MetricsAdvisorClientOptions(ServiceVersion version = LatestVersion)
        {
            if (version == default)
            {
                throw new ArgumentException($"The service version {version} is not supported by this library.");
            }

            Version = version;
        }

        /// <summary>
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V1_0 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// </summary>
        public ServiceVersion Version { get; }
    }
}
