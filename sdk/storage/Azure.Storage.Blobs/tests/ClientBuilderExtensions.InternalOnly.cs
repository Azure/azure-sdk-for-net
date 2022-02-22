// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;
using BlobsClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Blobs.BlobServiceClient,
    Azure.Storage.Blobs.BlobClientOptions>;

/**
 * Azure.Storage.Blobs.Batch (and any other sub-package of blobs) finds itself in the situation
 * where it cannot have access to Azure.Storage.Blobs internals. It requires access to
 * Azure.Storage.Blobs.Batch internals, which shares compile-includes with Azure.Storage.Blobs.
 * Some client builder extensions require access to the internals of blobs, but batch needs
 * general access to client builder extensions. This file contains extensions that require access
 * to blobs internals, and would cause compile conflicts were other packages to have access to those
 * internals.
 */
namespace Azure.Storage.Blobs.Tests
{
    public static partial class ClientBuilderExtensions
    {
        public static BlockBlobClient ToBlockBlobClient(
            this BlobsClientBuilder clientBuilder,
            BlobBaseClient client)
            => clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(new BlockBlobClient(client.Uri, client.ClientConfiguration));
    }
}
