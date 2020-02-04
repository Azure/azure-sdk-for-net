// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Azure.Core;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    internal class BlobServiceVersionPolicy : ServiceVersionPolicy
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
            BlobClientOptions.ServiceVersion serviceVersion = ToServiceVersion(serviceVersionString);

            // Latest ServiceVersion
            if (serviceVersion == BlobClientOptions.LatestVersion)
            {
                return;
            }

            // 2019-07-07 check
            if (serviceVersion < BlobClientOptions.ServiceVersion.V2019_07_07)
            {
                // Encryption Scope
                ThrowIfContainsHeader(message, "x-ms-default-encryption-scope", $"{nameof(BlobContainerClient)}.{nameof(BlobContainerClient.Create)}", serviceVersionString);
                ThrowIfContainsHeader(message, "x-ms-deny-encryption-scope-override", $"{nameof(BlobContainerClient)}.{nameof(BlobContainerClient.Create)}", serviceVersionString);
                ThrowIfContainsHeader(message, "x-ms-encryption-scope", "any API", serviceVersionString);

                // Previous Snapshot URL
                ThrowIfContainsHeader(message, "x-ms-previous-snapshot-url", $"{nameof(PageBlobClient)}.{nameof(PageBlobClient.GetManagedDiskPageRangesDiff)}", serviceVersionString);
            }
        }

        private static BlobClientOptions.ServiceVersion ToServiceVersion(string serviceVersionString)
            => serviceVersionString switch
            {
                Constants.ServiceVersion_2019_02_02 => BlobClientOptions.ServiceVersion.V2019_02_02,
                Constants.ServiceVersion_2019_07_07 => BlobClientOptions.ServiceVersion.V2019_07_07,
                _ => default,
            };
    }
}
