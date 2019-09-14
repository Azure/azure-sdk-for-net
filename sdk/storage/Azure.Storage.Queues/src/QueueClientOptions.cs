// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Core.Pipeline;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Queue
    /// Storage
    /// </summary>
    public class QueueClientOptions : ClientOptions
    {
        /// <summary>
        /// The Latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2018_11_09;

        /// <summary>
        /// The versions of Azure Queue Storage supported by this client
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
        /// Initializes a new instance of the <see cref="QueueClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public QueueClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
            this.Initialize();
        }

        /// <summary>
        /// Gets or sets the secondary storage <see cref="Uri"/> that can be read from for the storage account if the
        /// account is enabled for RA-GRS.
        /// 
        /// If this property is set, the secondary Uri will be used for GET or HEAD requests during retries.
        /// If the status of the response from the secondary Uri is a 404, then subsequent retries for 
        /// the request will not use the secondary Uri again, as this indicates that the resource
        /// may not have propagated there yet. Otherwise, subsequent retries will alternate back and forth
        /// between primary and secondary Uri.
        /// </summary>
        public Uri GeoRedundantSecondaryUri { get; set; }

        /// <summary>
        /// Create an HttpPipeline from QueueClientOptions.
        /// </summary>
        /// <param name="authentication">Optional authentication policy.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        internal HttpPipeline Build(HttpPipelinePolicy authentication = null)
        {
            return this.Build(authentication, this.GeoRedundantSecondaryUri);
        }

        /// <summary>
        /// Create an HttpPipeline from QueueClientOptions.
        /// </summary>
        /// <param name="credentials">Optional authentication credentials.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        internal HttpPipeline Build(object credentials)
        {
            return this.Build(credentials, this.GeoRedundantSecondaryUri);
        }
    }
}
