// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Monitor Logs service.
    /// </summary>
    public class LogsClientOptions: ClientOptions
    {
        private readonly ServiceVersion _version;

        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V1;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public LogsClientOptions(ServiceVersion version = LatestVersion)
        {
            _version = version;
        }

        /// <summary>
        /// The versions of Azure Monitor Logs service supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 version of the service
            /// </summary>
            V1
        }
    }
}