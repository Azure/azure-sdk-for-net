// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Models
{
    internal class GetFilesAndDirectoriesAsyncCollection : StorageCollectionEnumerator<StorageFileItem>
    {
        private readonly DirectoryClient _client;
        private readonly GetFilesAndDirectoriesOptions? _options;

        public GetFilesAndDirectoriesAsyncCollection(
            DirectoryClient client,
            GetFilesAndDirectoriesOptions? options)
        {
            _client = client;
            _options = options;
        }

        public override async ValueTask<Page<StorageFileItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<FilesAndDirectoriesSegment>> task = _client.GetFilesAndDirectoriesInternal(
                continuationToken,
                _options,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<FilesAndDirectoriesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            var items = new List<StorageFileItem>();
            items.AddRange(response.Value.DirectoryItems.Select(d => new StorageFileItem(true, d.Name)));
            items.AddRange(response.Value.FileItems.Select(f => new StorageFileItem(false, f.Name, f.Properties?.ContentLength)));
            return new Page<StorageFileItem>(
                items.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
