﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="MetricsAdvisorClient" /> or
    /// a <see cref="MetricsAdvisorAdministrationClient"/> to configure its behavior.
    /// </summary>
    public class MetricsAdvisorClientsOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClientsOptions"/> class.
        /// </summary>
        /// <param name="version">The version of the service to send requests to.</param>
        /// <exception cref="ArgumentException"><paramref name="version"/> is <c>default</c>.</exception>
        public MetricsAdvisorClientsOptions(ServiceVersion version = LatestVersion)
        {
            if (version == default)
            {
                throw new ArgumentException($"The service version {version} is not supported by this library.");
            }

            Version = version;

            AddLoggedHeadersAndQueryParameters();
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

        /// <summary>
        /// Add headers and query parameters that are considered safe for logging or including in
        /// error messages by default.
        /// </summary>
        private void AddLoggedHeadersAndQueryParameters()
        {
            Diagnostics.LoggedHeaderNames.Add("apim-request-id");
            Diagnostics.LoggedHeaderNames.Add("Location");
            Diagnostics.LoggedHeaderNames.Add("Strict-Transport-Security");
            Diagnostics.LoggedHeaderNames.Add("X-Content-Type-Options");
            Diagnostics.LoggedHeaderNames.Add("x-envoy-upstream-service-time");
            Diagnostics.LoggedHeaderNames.Add("X-Request-ID");
        }
    }
}
