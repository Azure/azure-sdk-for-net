// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Files.Shares
{
    internal class ShareServiceVersionPolicy : ServiceVersionPolicy
    {
        /// <summary>
        /// OnSendingRequest override.
        /// </summary>
        public override void OnSendingRequest(HttpMessage message)
        {
            // Get ServiceVersion header
            if (!message.Request.Headers.TryGetValue(Constants.HeaderNames.ServiceVersion, out string serviceVersionString))
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentNullException("x-ms-version");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            // Convert to ServiceVersion
            ShareClientOptions.ServiceVersion serviceVersion = ToServiceVersion(serviceVersionString);

            // Latest ServiceVersion
            if (serviceVersion == ShareClientOptions.LatestVersion)
            {
                return;
            }

            // 2019-07-07 check
            if (serviceVersion < ShareClientOptions.ServiceVersion.V2019_07_07)
            {
                // File Lease
                ThrowIfContainsHeader(message, "x-ms-lease-id", "any file API", serviceVersionString);
                ThrowIfContainsHeader(message, "x-ms-lease-duration", "any file API", serviceVersionString);
                ThrowIfContainsHeader(message, "x-ms-proposed-lease-id", "any file API", serviceVersionString);

                if (message.Request.Uri.Query.Contains("comp=lease"))
                {
                    throw new ArgumentException($"File lease operations are not supported in service version {serviceVersionString}");
                }

                // File Copy SMB Headers.  The file copy operation does not recognize contain any of the following
                // headers in service versions < 2019-07-07.
                if (message.Request.Headers.Contains("x-ms-copy-source"))
                {
                    ThrowIfContainsHeader(message, "x-ms-file-permission", Constants.File.StartCopyOperationName, serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-permission-key", Constants.File.StartCopyOperationName, serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-permission-copy-mode", Constants.File.StartCopyOperationName, serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-copy-ignore-read-only", Constants.File.StartCopyOperationName, serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-copy-set-archive", Constants.File.StartCopyOperationName, serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-attributes", Constants.File.StartCopyOperationName, serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-creation-time", Constants.File.StartCopyOperationName, serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-last-write-time", Constants.File.StartCopyOperationName, serviceVersionString);
                }
            }
        }

        private static ShareClientOptions.ServiceVersion ToServiceVersion(string serviceVersionString)
            => serviceVersionString switch
            {
                Constants.ServiceVersion_2019_02_02 => ShareClientOptions.ServiceVersion.V2019_02_02,
                Constants.ServiceVersion_2019_07_07 => ShareClientOptions.ServiceVersion.V2019_07_07,
                _ => default,
            };
    }
}
