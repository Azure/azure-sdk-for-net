// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Files.DataLake.Models
{
    internal class GetFileSystemsAsyncCollection : StorageCollectionEnumerator<FileSystemItem>
    {
        private readonly BlobServiceClient _client;
        private readonly FileSystemTraits _traits;
        private readonly string _prefix;

        public GetFileSystemsAsyncCollection(
            BlobServiceClient client,
            FileSystemTraits traits,
            string prefix = default)
        {
            _client = client;
            _traits = traits;
            _prefix = prefix;
        }

        public override async ValueTask<Page<FileSystemItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<BlobContainersSegment>> task = _client.GetBlobContainersInternal(
                continuationToken,
                (BlobContainerTraits)_traits,
                _prefix,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<BlobContainersSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return Page<FileSystemItem>.FromValues(
                response.Value.BlobContainerItems.Select(item => item.ToFileSystemItem()).ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
