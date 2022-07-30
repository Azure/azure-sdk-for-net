// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class BlockBlobClientInternals : BlockBlobClient
    {
        public BlockBlobClientInternals(BlockBlobClient client) : base(client)
        { }

        public static Response<BlobContentInfo> PutBlobCall(
            BlockBlobClient client,
            Stream content,
            BlobUploadOptions options,
            // TODO #27253
            //UploadTransactionalHashingOptions hashingOptions,
            string operationName,
            CancellationToken cancellationToken)
        {
            Response<BlobContentInfo> response = PutBlob(
                client,
                content,
                options,
                operationName,
                cancellationToken);
            return Response.FromValue(
                        response.Value,
                        response.GetRawResponse());
        }

        public static async Task<Response<BlobContentInfo>> PutBlobCallAsync(
            BlockBlobClient client,
            Stream content,
            BlobUploadOptions options,
            // TODO #27253
            //UploadTransactionalHashingOptions hashingOptions,
            string operationName,
            CancellationToken cancellationToken)
        {
            Response<BlobContentInfo> response = await PutBlobAsync(
                client,
                content,
                options,
                operationName,
                cancellationToken).ConfigureAwait(false);
            return Response.FromValue(
                        response.Value,
                        response.GetRawResponse());
        }
    }
}
