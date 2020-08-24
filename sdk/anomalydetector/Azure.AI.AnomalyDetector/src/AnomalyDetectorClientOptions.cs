// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.AnomalyDetector
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="AnomalyDetectorClient" />
    /// </summary>
    public class AnomalyDetectorClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyDetectorClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version of the service to send requests to.</param>
        public AnomalyDetectorClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }

        /// <summary>
        /// The service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V2.0 of the service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V1_0 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// The service version.
        /// </summary>
        public ServiceVersion Version { get; }

        internal static string GetVersionString(ServiceVersion version)
        {
            return version switch
            {
                ServiceVersion.V1_0 => "v1.0",
                _ => throw new NotSupportedException($"The service version {version} is not supported."),
            };
        }
    }
}
