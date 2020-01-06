// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Files.Shares
{
    internal class FileServiceVersionPolicy : ServiceVersionPolicy
    {
        /// <summary>
        /// OnSendingRequest override.
        /// </summary>
        public override void OnSendingRequest(HttpMessage message)
        {
            // Get ServiceVersion header
            if (!message.Request.Headers.TryGetValue(Constants.HeaderNames.ServiceVersion, out string serviceVersionString))
            {
                return;
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
                if (message.Request.Headers.Contains("x-ms-lease-id"))
                {
                    ThrowIfContainsHeader(message, "x-ms-lease-id", "any file API", serviceVersionString);
                }

                if (message.Request.Headers.Contains("x-ms-lease-duration"))
                {
                    ThrowIfContainsHeader(message, "x-ms-lease-duration", "any file API", serviceVersionString);
                }

                if (message.Request.Headers.Contains("x-ms-proposed-lease-id"))
                {
                    ThrowIfContainsHeader(message, "x-ms-proposed-lease-id", "any file API", serviceVersionString);
                }

                if (message.Request.Uri.Query.Contains("comp=lease"))
                {
                    throw new ArgumentException($"File lease operations are not supported in service version {serviceVersionString}");
                }

                // File Copy SMB Headers
                if (message.Request.Headers.Contains("x-ms-copy-source"))
                {
                    ThrowIfContainsHeader(message, "x-ms-file-permission", "copy file", serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-permission-key", "copy file", serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-permission-copy-mode", "copy file", serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-copy-ignore-read-only", "copy file", serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-copy-set-archive", "copy file", serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-attributes", "copy file", serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-creation-time", "copy file", serviceVersionString);
                    ThrowIfContainsHeader(message, "x-ms-file-last-write-time", "copy file", serviceVersionString);
                }
            }
        }

        private static ShareClientOptions.ServiceVersion ToServiceVersion(string serviceVersionString)
        {
            if (serviceVersionString == Constants.ServiceVersion_2019_02_02)
            {
                return ShareClientOptions.ServiceVersion.V2019_02_02;
            }
            else if (serviceVersionString == Constants.ServiceVersion_2019_07_07)
            {
                return ShareClientOptions.ServiceVersion.V2019_07_07;
            }
            else
            {
                return default;
            }
        }
    }
}
