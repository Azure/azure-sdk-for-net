// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    internal static class ClientExtensions
    {
        public static BlobClientConfiguration GetConfiguration(this BlobBaseClient client)
            => BlobBaseClientProtectedAccessor.GetConfiguration(client);

        public static BlobClientConfiguration GetConfiguration(this BlobContainerClient client)
            => BlobContainerClientProtectedAccessor.GetConfiguration(client);

        private class BlobBaseClientProtectedAccessor : BlobBaseClient
        {
            public static BlobClientConfiguration GetConfiguration(BlobBaseClient client) => GetClientConfiguration(client);
        }
        private class BlobContainerClientProtectedAccessor : BlobContainerClient
        {
            public static BlobClientConfiguration GetConfiguration(BlobContainerClient client) => GetClientConfiguration(client);
        }
    }
}
