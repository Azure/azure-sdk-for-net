// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Storage.Files.Shares.Models;

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
            V2024_02_04 = 21
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
        /// Transfer validation options to be applied to file transfers from this client.
        /// </summary>
        public TransferValidationOptions TransferValidation { get; } = new();

        /// <summary>
        /// If set to true, trailing dot (.) will be allowed to suffex directory and file names.
        /// If false, the trailing dot will be trimmed.
        /// Supported by x-ms-version 2022-11-02 and above.
        /// </summary>
        public bool? AllowTrailingDot { get; set; }

        /// <summary>
        /// If set to true, trailing dot (.) will be allowed to source file names.
        /// If false, the trailing dot will be trimmed.
        /// Supported by x-ms-version 2022-11-02 and above.
        /// Applicable to <see cref="ShareFileClient.Rename(string, Models.ShareFileRenameOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="ShareFileClient.RenameAsync(string, Models.ShareFileRenameOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="ShareFileClient.UploadRangeFromUri(System.Uri, HttpRange, HttpRange, Models.ShareFileUploadRangeFromUriOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="ShareFileClient.UploadRangeFromUriAsync(System.Uri, HttpRange, HttpRange, Models.ShareFileUploadRangeFromUriOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="ShareFileClient.StartCopy(System.Uri, Models.ShareFileCopyOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="ShareFileClient.StartCopyAsync(System.Uri, Models.ShareFileCopyOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="ShareDirectoryClient.Rename(string, Models.ShareFileRenameOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="ShareDirectoryClient.RenameAsync(string, Models.ShareFileRenameOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public bool? AllowSourceTrailingDot { get; set; }

        /// <summary>
        /// Share Token Intent.  For use with token authentication.  Used to indicate the intent of the request.
        /// This is currently required when using token authentication.
        /// </summary>
        public ShareTokenIntent? ShareTokenIntent { get; set; }

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

        /// <summary>
        /// Gets or sets the Audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="ShareAudience.DefaultAudience" /> will be assumed.</value>
        public ShareAudience? Audience { get; set; }
    }
}
