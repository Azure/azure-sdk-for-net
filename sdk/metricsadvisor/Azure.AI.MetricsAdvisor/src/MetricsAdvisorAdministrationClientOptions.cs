// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="MetricsAdvisorAdministrationClient" />
    /// to configure its behavior.
    /// </summary>
    public class MetricsAdvisorAdministrationClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary>
        /// Creates a new instance of the <see cref="MetricsAdvisorAdministrationClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version of the service to send requests to.</param>
        /// <exception cref="ArgumentException"><paramref name="version"/> is <c>default</c>.</exception>
        public MetricsAdvisorAdministrationClientOptions(ServiceVersion version = LatestVersion)
        {
            if (version == default)
            {
                throw new ArgumentException($"The service version {version} is not supported by this library.");
            }

            Version = version;
        }

        /// <summary>
        /// The service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1.0 of the service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V1_0 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// The service version.
        /// </summary>
        public ServiceVersion Version { get; }
    }
}
