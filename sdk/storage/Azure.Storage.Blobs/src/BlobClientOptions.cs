// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Blob
    /// Storage.
    /// </summary>
    public class BlobClientOptions : ClientOptions
    {
        /// <summary>
        /// The Latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2019_02_02;

        /// <summary>
        /// The versions of Azure Blob Storage supported by this client
        /// library.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services" />.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The 2019-02-02 service version described at
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services#version-2019-02-02" />
            /// </summary>
            V2019_02_02 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services" />.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Gets the <see cref="CustomerProvidedKey"/> to be used when making requests.
        /// </summary>
        public CustomerProvidedKey? CustomerProvidedKey { get; set; }

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
        /// Initializes a new instance of the <see cref="BlobClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public BlobClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version == ServiceVersion.V2019_02_02 ? version : throw Errors.VersionNotSupported(nameof(version));
            this.Initialize();
            List<string> LoggedHeaderNames = new List<string>
            {
                "Access-Control-Allow-Origin",
                "x-ms-client-request-id",
                "x-ms-date",
                "x-ms-error-code",
                "x-ms-request-id",
                "x-ms-version",
                "Accept-Ranges",
                "Content-Disposition",
                "Content-Encoding",
                "Content-Language",
                "Content-MD5",
                "Content-Range",
                "Vary",
                "x-ms-content-crc64",
                "x-ms-copy-action",
                "x-ms-copy-completion-time",
                "x-ms-copy-id",
                "x-ms-copy-progress",
                "x-ms-copy-status",
                "x-ms-has-immutability-policy",
                "x-ms-has-legal-hold",
                "x-ms-lease-state",
                "x-ms-lease-status",
                "x-ms-range",
                "x-ms-request-server-encrypted",
                "x-ms-server-encrypted",
                "x-ms-snapshot",
                "x-ms-source-range",
                "x-ms-access-tier",
                "x-ms-access-tier-change-time",
                "x-ms-access-tier-inferred",
                "x-ms-account-kind",
                "x-ms-archive-status",
                "x-ms-blob-append-offset",
                "x-ms-blob-cache-control",
                "x-ms-blob-committed-block-count",
                "x-ms-blob-condition-appendpos",
                "x-ms-blob-condition-maxsize",
                "x-ms-blob-content-disposition",
                "x-ms-blob-content-encoding",
                "x-ms-blob-content-language",
                "x-ms-blob-content-length",
                "x-ms-blob-content-md5",
                "x-ms-blob-content-type",
                "x-ms-blob-public-access",
                "x-ms-blob-sequence-number",
                "x-ms-blob-type",
                "x-ms-copy-destination-snapshot",
                "x-ms-creation-time",
                "x-ms-default-encryption-scope",
                "x-ms-delete-snapshots",
                "x-ms-delete-type-permanent",
                "x-ms-deny-encryption-scope-override",
                "x-ms-encryption-algorithm",
                "x-ms-if-sequence-number-eq",
                "x-ms-if-sequence-number-le",
                "x-ms-if-sequence-number-lt",
                "x-ms-incremental-copy",
                "x-ms-lease-action",
                "x-ms-lease-break-period",
                "x-ms-lease-duration",
                "x-ms-lease-id",
                "x-ms-lease-time",
                "x-ms-page-write",
                "x-ms-proposed-lease-id",
                "x-ms-range-get-content-md5",
                "x-ms-rehydrate-priority",
                "x-ms-sequence-number-action",
                "x-ms-sku-name",
                "x-ms-source-content-md5",
                "x-ms-source-if-match",
                "x-ms-source-if-modified-since",
                "x-ms-source-if-none-match",
                "x-ms-source-if-unmodified-since",
                "x-ms-tag-count",
                "x-ms-encryption-key-sha256"
            };

            List<string> LoggedQueryParameters = new List<string>
            {
                "comp",
                "maxresults",
                "rscc",
                "rscd",
                "rsce",
                "rscl",
                "rsct",
                "se",
                "si",
                "sip",
                "sp",
                "spr",
                "sr",
                "srt",
                "ss",
                "st",
                "sv",
                "include",
                "marker",
                "prefix",
                "copyid",
                "restype",
                "blockid",
                "blocklisttype",
                "delimiter",
                "prevsnapshot",
                "ske",
                "skoid",
                "sks",
                "skt",
                "sktid",
                "skv",
                "snapshot"
            };

            LoggedHeaderNames.ForEach(header => Diagnostics.LoggedHeaderNames.Add(header));
            LoggedQueryParameters.ForEach(header => Diagnostics.LoggedQueryParameters.Add(header));
        }

        /// <summary>
        /// Create an HttpPipeline from BlobClientOptions.
        /// </summary>
        /// <param name="authentication">Optional authentication policy.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        internal HttpPipeline Build(HttpPipelinePolicy authentication = null)
        {
            return this.Build(authentication, GeoRedundantSecondaryUri);
        }

        /// <summary>
        /// Create an HttpPipeline from BlobClientOptions.
        /// </summary>
        /// <param name="credentials">Optional authentication credentials.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        internal HttpPipeline Build(object credentials)
        {
            return this.Build(credentials, GeoRedundantSecondaryUri);
        }
    }
}
