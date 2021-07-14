// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Monitor Metrics service.
    /// </summary>
    public class MetricsQueryClientOptions: ClientOptions
    {
        private readonly ServiceVersion _version;

        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2018_01_01;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsQueryClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public MetricsQueryClientOptions(ServiceVersion version = LatestVersion)
        {
            _version = version;
        }

        /// <summary>
        /// The versions of Azure Monitor Query service supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Version 2018-01-01 of the service.
            /// </summary>
            V2018_01_01
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
