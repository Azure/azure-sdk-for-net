// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2019_02_02;

        /// <summary>
        /// The versions of Azure File Storage supported by this client
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
        /// Initializes a new instance of the <see cref="FileClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public FileClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version == ServiceVersion.V2019_02_02 ? version : throw Errors.VersionNotSupported(nameof(version));
            this.Initialize();
            List<string> LoggedHeaderNames = new List<string>
            {
                "Access-Control-Allow-Origin",
                "Transfer-Encoding",
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
                "x-ms-cache-control",
                "x-ms-content-disposition",
                "x-ms-content-encoding",
                "x-ms-content-language",
                "x-ms-content-length",
                "x-ms-content-md5",
                "x-ms-content-type",
                "x-ms-file-attributes",
                "x-ms-file-change-time",
                "x-ms-file-creation-time",
                "x-ms-file-id",
                "x-ms-file-last-write-time",
                "x-ms-file-parent-id",
                "x-ms-handle-id",
                "x-ms-number-of-handles-closed",
                "x-ms-recursive",
                "x-ms-share-quota",
                "x-ms-type",
                "x-ms-write"
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
                "copyid",
                "restype"
            };

            LoggedHeaderNames.ForEach(header => Diagnostics.LoggedHeaderNames.Add(header));
            LoggedQueryParameters.ForEach(header => Diagnostics.LoggedQueryParameters.Add(header));
        }
    }
}
