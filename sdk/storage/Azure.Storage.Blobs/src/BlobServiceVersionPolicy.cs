// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

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
                return;
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
                ThrowIfContainsHeader(message, "x-ms-default-encryption-scope", "create container", serviceVersionString);
                ThrowIfContainsHeader(message, "x-ms-deny-encryption-scope-override", "create container", serviceVersionString);
                ThrowIfContainsHeader(message, "x-ms-encryption-scope", "any API", serviceVersionString);

                // Previous Snapshot URL
                ThrowIfContainsHeader(message, "x-ms-previous-snapshot-url", "get page range diff", serviceVersionString);
            }
        }

        private static BlobClientOptions.ServiceVersion ToServiceVersion(string serviceVersionString)
        {
            if (serviceVersionString == Constants.ServiceVersion_2019_02_02)
            {
                return BlobClientOptions.ServiceVersion.V2019_02_02;
            }
            else if (serviceVersionString == Constants.ServiceVersion_2019_07_07)
            {
                return BlobClientOptions.ServiceVersion.V2019_07_07;
            }
            else
            {
                return default;
            }
        }
    }
}
