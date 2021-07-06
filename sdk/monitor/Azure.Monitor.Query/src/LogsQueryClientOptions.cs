// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Monitor Logs service.
    /// </summary>
    public class LogsQueryClientOptions: ClientOptions
    {
        private readonly ServiceVersion _version;

        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        private const ServiceVersion LatestVersion = ServiceVersion.V1;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsQueryClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public LogsQueryClientOptions(ServiceVersion version = LatestVersion)
        {
            _version = version;

            Diagnostics.LoggedHeaderNames.Add("prefer");
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

        /// <summary>
        /// Gets or sets the authentication scope to use for authentication with Azure Active Directory. The default scope will be used if the property is null.
        /// </summary>
        public string AuthenticationScope { get; set; }

        internal string GetVersionString()
        {
            return _version switch
            {
                ServiceVersion.V1 => "v1",
                _ => throw new ArgumentException(@"Unknown version {_version}")
            };
        }
    }
}
