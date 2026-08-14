// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class ShareFileClientInternals : ShareFileClient
    {
        public static Task<HttpAuthorization> GetCopyAuthorizationTokenAsync(
            ShareFileClient client,
            CancellationToken cancellationToken)
            => ShareFileClient.GetCopyAuthorizationHeaderAsync(client, cancellationToken);

        public static Uri GetSasUri(ShareFileClient client)
            => ShareFileClient.GetUriWithSas(client);
    }
}
