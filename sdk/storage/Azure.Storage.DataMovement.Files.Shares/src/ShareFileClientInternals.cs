// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class ShareFileClientInternals : ShareFileClient
    {
        public static Task<HttpAuthorization> GetCopyAuthorizationTokenAsync(
            ShareFileClient client,
            CancellationToken cancellationToken)
            => ShareFileClient.GetCopyAuthorizationHeaderAsync(client, cancellationToken);
    }
}
