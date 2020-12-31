// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure File
    /// Storage.
    /// </summary>
    public class ShareClientOptions : ClientOptions
    {
        /// <summary>
        /// The Latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = StorageVersionExtensions.LatestVersion;

        /// <summary>
        /// The versions of Azure File Storage supported by this client
        /// library.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services">
        /// Versioning for the Azure Storage services</see>.
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
            V2020_04_08 = 5
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.  For more, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services">
        /// Versioning for the Azure Storage services</see>.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public ShareClientOptions(ServiceVersion version = LatestVersion)
        {
            if (ServiceVersion.V2019_02_02 <= version
                && version <= LatestVersion)
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
            Diagnostics.LoggedHeaderNames.Add("Transfer-Encoding");
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
            Diagnostics.LoggedHeaderNames.Add("x-ms-cache-control");
            Diagnostics.LoggedHeaderNames.Add("x-ms-content-disposition");
            Diagnostics.LoggedHeaderNames.Add("x-ms-content-encoding");
            Diagnostics.LoggedHeaderNames.Add("x-ms-content-language");
            Diagnostics.LoggedHeaderNames.Add("x-ms-content-length");
            Diagnostics.LoggedHeaderNames.Add("x-ms-content-md5");
            Diagnostics.LoggedHeaderNames.Add("x-ms-content-type");
            Diagnostics.LoggedHeaderNames.Add("x-ms-file-attributes");
            Diagnostics.LoggedHeaderNames.Add("x-ms-file-change-time");
            Diagnostics.LoggedHeaderNames.Add("x-ms-file-creation-time");
            Diagnostics.LoggedHeaderNames.Add("x-ms-file-id");
            Diagnostics.LoggedHeaderNames.Add("x-ms-file-last-write-time");
            Diagnostics.LoggedHeaderNames.Add("x-ms-file-parent-id");
            Diagnostics.LoggedHeaderNames.Add("x-ms-handle-id");
            Diagnostics.LoggedHeaderNames.Add("x-ms-number-of-handles-closed");
            Diagnostics.LoggedHeaderNames.Add("x-ms-recursive");
            Diagnostics.LoggedHeaderNames.Add("x-ms-share-quota");
            Diagnostics.LoggedHeaderNames.Add("x-ms-type");
            Diagnostics.LoggedHeaderNames.Add("x-ms-write");

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
            Diagnostics.LoggedQueryParameters.Add("copyid");
            Diagnostics.LoggedQueryParameters.Add("restype");
        }
    }
}
