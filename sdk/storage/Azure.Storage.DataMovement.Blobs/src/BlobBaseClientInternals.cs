// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobBaseClientInternals : BlobBaseClient
    {
        public static Task<HttpAuthorization> GetCopyAuthorizationTokenAsync(
            BlobBaseClient client,
            CancellationToken cancellationToken)
            => BlobBaseClient.GetCopyAuthorizationHeaderAsync(client, cancellationToken);
    }
}
