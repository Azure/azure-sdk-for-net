// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Blob
    /// Storage.
    /// </summary>
    public class BlobClientOptions : ClientOptions, ISupportsTenantIdChallenges
    {
        /// <summary>
        /// The Latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = StorageVersionExtensions.LatestVersion;

        /// <summary>
        /// The versions of Azure Blob Storage supported by this client
        /// library.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services">
        /// Versioning for Azure Storage Services</see>.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The 2019-02-02 service version described at
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/version-2019-02-02">
            /// Version 2019-02-02</see>
            /// </summary>
            V2019_02_02 = 1,

            /// <summary>
            /// The 2019-07-07 service version described at
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/version-2019-07-07">
            /// Version 2019-07-07</see>
            /// </summary>
            V2019_07_07 = 2,

            /// <summary>
            /// The 2019-12-12 service version.
            /// </summary>
            V2019_12_12 = 3,

            /// <summary>
            /// The 2020-02-10 service version.
            /// </summary>
            V2020_02_10 = 4,

            /// <summary>
            /// The 2020-04-08 service version.
            /// </summary>
            V2020_04_08 = 5,

            /// <summary>
            /// The 2020-06-12 service version.
            /// </summary>
            V2020_06_12 = 6,

            /// <summary>
            /// The 2020-08-14 service version.
            /// </summary>
            V2020_08_04 = 7,

            /// <summary>
            /// The 2020-10-02 service version.
            /// </summary>
            V2020_10_02 = 8,

            /// <summary>
            /// The 2020-12-06 service version.
            /// </summary>
            V2020_12_06 = 9,

            /// <summary>
            /// The 2021-02-12 service version.
            /// </summary>
            V2021_02_12 = 10,

            /// <summary>
            /// The 2021-04-10 serivce version.
            /// </summary>
            V2021_04_10 = 11,

            /// <summary>
            /// The 2021-06-08 service version.
            /// </summary>
            V2021_06_08 = 12,

            /// <summary>
            /// The 2021-08-06 service version.
            /// </summary>
            V2021_08_06 = 13,

            /// <summary>
            /// The 2021-10-04 service version.
            /// </summary>
            V2021_10_04 = 14,

            /// <summary>
            /// The 2021-12-02 service version.
            /// </summary>
            V2021_12_02 = 15,

            /// <summary>
            /// The 2022-11-02 service version.
            /// </summary>
            V2022_11_02 = 16,

            /// <summary>
            /// The 2023-01-03 service version.
            /// </summary>
            V2023_01_03 = 17,

            /// <summary>
            /// The 2023-05-03 service version.
            /// </summary>
            V2023_05_03 = 18,

            /// <summary>
            /// The 2023-08-03 service version.
            /// </summary>
            V2023_08_03 = 19,

            /// <summary>
            /// The 2023-11-03 service version.
            /// </summary>
            V2023_11_03 = 20,

            /// <summary>
            /// The 2024-02-04 service version.
            /// </summary>
            V2024_02_04 = 21,

            /// <summary>
            /// The 2024-05-04 service version.
            /// </summary>
            V2024_05_04 = 22,

            /// <summary>
            /// The 2024-08-04 service version.
            /// </summary>
            V2024_08_04 = 23,

            /// <summary>
            /// The 2024-11-04 service version.
            /// </summary>
            V2024_11_04 = 24,

            /// <summary>
            /// The 2025-01-05 service version.
            /// </summary>
            V2025_01_05 = 25,

            /// <summary>
            /// The 2025-05-05 service version.
            /// </summary>
            V2025_05_05 = 26,

            /// <summary>
            /// The 2025-07-05 service version.
            /// </summary>
            V2025_07_05 = 27,

            /// <summary>
            /// The 2025-11-05 service version.
            /// </summary>
            V2025_11_05 = 28,

            /// <summary>
            /// The 2026-02-06 service version.
            /// </summary>
            V2026_02_06 = 29
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services">
        /// Versioning for Azure Storage Services</see>.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Gets the <see cref="CustomerProvidedKey"/> to be used when making requests.
        /// </summary>
        public CustomerProvidedKey? CustomerProvidedKey { get; set; }

        /// <summary>
        /// Gets the <see cref="EncryptionScope"/> to be used when making requests.
        /// </summary>
        public string EncryptionScope { get; set; }

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
        /// Configures whether to send or receive checksum headers for blob uploads and downloads. Downloads
        /// can optionally validate that the content matches the checksum.
        /// </summary>
        public TransferValidationOptions TransferValidation { get; } = new();

        /// <summary>
        /// Whether to trim leading and trailing slashes on a blob name when using
        /// <see cref="BlobContainerClient.GetBlobClient(string)"/> and similar methods.
        /// Defaults to true for backwards compatibility.
        /// </summary>
        public bool TrimBlobNameSlashes { get; set; } = Constants.DefaultTrimBlobNameSlashes;

        /// <summary>
        /// Behavior options for setting HTTP header <c>Expect: 100-continue</c> on requests.
        /// </summary>
        public Request100ContinueOptions Request100ContinueOptions { get; set; }

        /// <summary>
        /// Whether to trim leading and trailing slashes on a blob name when using
        /// <see cref="BlobContainerClient.GetBlobClient(string)"/> and similar methods.
        /// Defaults to true for backwards compatibility.
        /// </summary>
        public bool DontIncludeStorageRequestValidationPipelinePolicy { get; set; } = Constants.DontIncludeStorageRequestValidationPipelinePolicy;

        #region Advanced Options
        internal ClientSideEncryptionOptions _clientSideEncryptionOptions;
        #endregion

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
            if (ServiceVersion.V2019_02_02 <= version
                && version <= StorageVersionExtensions.MaxVersion)
            {
                Version = version;
            }
            else
            {
                throw Errors.VersionNotSupported(nameof(version));
            }

            this.Initialize();
            AddHeadersAndQueryParameters();
        }

        /// <summary>
        /// Add headers and query parameters in <see cref="DiagnosticsOptions.LoggedHeaderNames"/> and <see cref="DiagnosticsOptions.LoggedQueryParameters"/>
        /// </summary>
        private void AddHeadersAndQueryParameters()
        {
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Allow-Origin");
            Diagnostics.LoggedHeaderNames.Add("x-ms-date");
            Diagnostics.LoggedHeaderNames.Add("x-ms-error-code");
            Diagnostics.LoggedHeaderNames.Add("x-ms-request-id");
            Diagnostics.LoggedHeaderNames.Add("x-ms-version");
            Diagnostics.LoggedHeaderNames.Add("Accept-Ranges");
            Diagnostics.LoggedHeaderNames.Add("Content-Disposition");
            Diagnostics.LoggedHeaderNames.Add("Content-Encoding");
            Diagnostics.LoggedHeaderNames.Add("Content-Language");
            Diagnostics.LoggedHeaderNames.Add("Content-MD5");
            Diagnostics.LoggedHeaderNames.Add("Content-Range");
            Diagnostics.LoggedHeaderNames.Add("Vary");
            Diagnostics.LoggedHeaderNames.Add("x-ms-content-crc64");
            Diagnostics.LoggedHeaderNames.Add("x-ms-copy-action");
            Diagnostics.LoggedHeaderNames.Add("x-ms-copy-completion-time");
            Diagnostics.LoggedHeaderNames.Add("x-ms-copy-id");
            Diagnostics.LoggedHeaderNames.Add("x-ms-copy-progress");
            Diagnostics.LoggedHeaderNames.Add("x-ms-copy-status");
            Diagnostics.LoggedHeaderNames.Add("x-ms-has-immutability-policy");
            Diagnostics.LoggedHeaderNames.Add("x-ms-has-legal-hold");
            Diagnostics.LoggedHeaderNames.Add("x-ms-lease-state");
            Diagnostics.LoggedHeaderNames.Add("x-ms-lease-status");
            Diagnostics.LoggedHeaderNames.Add("x-ms-range");
            Diagnostics.LoggedHeaderNames.Add("x-ms-request-server-encrypted");
            Diagnostics.LoggedHeaderNames.Add("x-ms-server-encrypted");
            Diagnostics.LoggedHeaderNames.Add("x-ms-snapshot");
            Diagnostics.LoggedHeaderNames.Add("x-ms-source-range");
            Diagnostics.LoggedHeaderNames.Add("x-ms-access-tier");
            Diagnostics.LoggedHeaderNames.Add("x-ms-access-tier-change-time");
            Diagnostics.LoggedHeaderNames.Add("x-ms-access-tier-inferred");
            Diagnostics.LoggedHeaderNames.Add("x-ms-account-kind");
            Diagnostics.LoggedHeaderNames.Add("x-ms-archive-status");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-append-offset");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-cache-control");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-committed-block-count");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-condition-appendpos");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-condition-maxsize");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-content-disposition");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-content-encoding");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-content-language");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-content-length");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-content-md5");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-content-type");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-public-access");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-sequence-number");
            Diagnostics.LoggedHeaderNames.Add("x-ms-blob-type");
            Diagnostics.LoggedHeaderNames.Add("x-ms-copy-destination-snapshot");
            Diagnostics.LoggedHeaderNames.Add("x-ms-creation-time");
            Diagnostics.LoggedHeaderNames.Add("x-ms-default-encryption-scope");
            Diagnostics.LoggedHeaderNames.Add("x-ms-delete-snapshots");
            Diagnostics.LoggedHeaderNames.Add("x-ms-delete-type-permanent");
            Diagnostics.LoggedHeaderNames.Add("x-ms-deny-encryption-scope-override");
            Diagnostics.LoggedHeaderNames.Add("x-ms-encryption-algorithm");
            Diagnostics.LoggedHeaderNames.Add("x-ms-if-sequence-number-eq");
            Diagnostics.LoggedHeaderNames.Add("x-ms-if-sequence-number-le");
            Diagnostics.LoggedHeaderNames.Add("x-ms-if-sequence-number-lt");
            Diagnostics.LoggedHeaderNames.Add("x-ms-incremental-copy");
            Diagnostics.LoggedHeaderNames.Add("x-ms-lease-action");
            Diagnostics.LoggedHeaderNames.Add("x-ms-lease-break-period");
            Diagnostics.LoggedHeaderNames.Add("x-ms-lease-duration");
            Diagnostics.LoggedHeaderNames.Add("x-ms-lease-id");
            Diagnostics.LoggedHeaderNames.Add("x-ms-lease-time");
            Diagnostics.LoggedHeaderNames.Add("x-ms-page-write");
            Diagnostics.LoggedHeaderNames.Add("x-ms-proposed-lease-id");
            Diagnostics.LoggedHeaderNames.Add("x-ms-range-get-content-md5");
            Diagnostics.LoggedHeaderNames.Add("x-ms-rehydrate-priority");
            Diagnostics.LoggedHeaderNames.Add("x-ms-sequence-number-action");
            Diagnostics.LoggedHeaderNames.Add("x-ms-sku-name");
            Diagnostics.LoggedHeaderNames.Add("x-ms-source-content-md5");
            Diagnostics.LoggedHeaderNames.Add("x-ms-source-if-match");
            Diagnostics.LoggedHeaderNames.Add("x-ms-source-if-modified-since");
            Diagnostics.LoggedHeaderNames.Add("x-ms-source-if-none-match");
            Diagnostics.LoggedHeaderNames.Add("x-ms-source-if-unmodified-since");
            Diagnostics.LoggedHeaderNames.Add("x-ms-tag-count");
            Diagnostics.LoggedHeaderNames.Add("x-ms-encryption-key-sha256");
            Diagnostics.LoggedHeaderNames.Add("x-ms-copy-source-error-code");
            Diagnostics.LoggedHeaderNames.Add("x-ms-copy-source-status-code");

            Diagnostics.LoggedQueryParameters.Add("comp");
            Diagnostics.LoggedQueryParameters.Add("maxresults");
            Diagnostics.LoggedQueryParameters.Add("rscc");
            Diagnostics.LoggedQueryParameters.Add("rscd");
            Diagnostics.LoggedQueryParameters.Add("rsce");
            Diagnostics.LoggedQueryParameters.Add("rscl");
            Diagnostics.LoggedQueryParameters.Add("rsct");
            Diagnostics.LoggedQueryParameters.Add("se");
            Diagnostics.LoggedQueryParameters.Add("si");
            Diagnostics.LoggedQueryParameters.Add("sip");
            Diagnostics.LoggedQueryParameters.Add("sp");
            Diagnostics.LoggedQueryParameters.Add("spr");
            Diagnostics.LoggedQueryParameters.Add("sr");
            Diagnostics.LoggedQueryParameters.Add("srt");
            Diagnostics.LoggedQueryParameters.Add("ss");
            Diagnostics.LoggedQueryParameters.Add("st");
            Diagnostics.LoggedQueryParameters.Add("sv");
            Diagnostics.LoggedQueryParameters.Add("include");
            Diagnostics.LoggedQueryParameters.Add("marker");
            Diagnostics.LoggedQueryParameters.Add("prefix");
            Diagnostics.LoggedQueryParameters.Add("copyid");
            Diagnostics.LoggedQueryParameters.Add("restype");
            Diagnostics.LoggedQueryParameters.Add("blockid");
            Diagnostics.LoggedQueryParameters.Add("blocklisttype");
            Diagnostics.LoggedQueryParameters.Add("delimiter");
            Diagnostics.LoggedQueryParameters.Add("prevsnapshot");
            Diagnostics.LoggedQueryParameters.Add("ske");
            Diagnostics.LoggedQueryParameters.Add("skoid");
            Diagnostics.LoggedQueryParameters.Add("sks");
            Diagnostics.LoggedQueryParameters.Add("skt");
            Diagnostics.LoggedQueryParameters.Add("sktid");
            Diagnostics.LoggedQueryParameters.Add("skv");
            Diagnostics.LoggedQueryParameters.Add("snapshot");
        }

        /// <summary>
        /// Create an HttpPipeline from BlobClientOptions.
        /// </summary>
        /// <param name="authentication">Optional authentication policy.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        internal HttpPipeline Build(HttpPipelinePolicy authentication = null)
        {
            return this.Build(authentication, GeoRedundantSecondaryUri, Request100ContinueOptions, DontIncludeStorageRequestValidationPipelinePolicy);
        }

        /// <summary>
        /// Create an HttpPipeline from BlobClientOptions.
        /// </summary>
        /// <param name="credentials">Optional authentication credentials.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        internal HttpPipeline Build(object credentials)
        {
            return this.Build(credentials, GeoRedundantSecondaryUri, Request100ContinueOptions, DontIncludeStorageRequestValidationPipelinePolicy);
        }

        /// <inheritdoc />
        public bool EnableTenantDiscovery { get; set; }

        /// <summary>
        /// Gets or sets the Audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="BlobAudience.DefaultAudience" /> will be assumed.</value>
        public BlobAudience? Audience { get; set; }
    }
}
