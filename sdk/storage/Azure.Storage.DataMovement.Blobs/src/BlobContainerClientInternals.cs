// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobContainerClientInternals : BlobContainerClient
    {
        public static BlobContainerClient WithAppendedUserAgentClient(
            BlobContainerClient client,
            string appendedUserAgent)
            => BlobContainerClient.WithAppendedUserAgent(client, appendedUserAgent);
    }
}
