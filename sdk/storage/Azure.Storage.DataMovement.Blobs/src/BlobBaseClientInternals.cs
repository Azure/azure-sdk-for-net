// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobBaseClientInternals : BlobBaseClient
    {
        public static new HttpAuthorization GetCopyAuthorizationHeader(
            BlobBaseClient client,
            CancellationToken cancellationToken)
            => BlobBaseClient.GetCopyAuthorizationHeader(client, cancellationToken);

        // TODO: add back in when AzureSasCredential supports generating SAS's
        //public static new AzureSasCredential GetSasCredential(BlobBaseClient client)
        //=> BlobBaseClient.GetSasCredential(client);
    }
}
