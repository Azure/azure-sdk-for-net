// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Storage.Files
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure File
    /// Storage.
    /// </summary>
    public class FileClientOptions : ClientOptions
    {
        /// <summary>
        /// The Latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2018_11_09;

        /// <summary>
        /// The versions of Azure File Storage supported by this client
        /// library.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services" />.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The 2018-11-09 service version described at
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/version-2018-11-09" />
            /// </summary>
            V2018_11_09 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services" />.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public FileClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
            this.Initialize();
        }
    }
}
