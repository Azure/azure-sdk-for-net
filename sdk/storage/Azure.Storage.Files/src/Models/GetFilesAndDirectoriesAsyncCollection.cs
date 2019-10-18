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
        private readonly string _prefix;
        private readonly string _shareSnapshot;

        public GetFilesAndDirectoriesAsyncCollection(
            DirectoryClient client,
            string prefix,
            string shareSnapshot)
        {
            _client = client;
            _prefix = prefix;
            _shareSnapshot = shareSnapshot;
        }

        public override async ValueTask<Page<StorageFileItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<FilesAndDirectoriesSegment>> task = _client.GetFilesAndDirectoriesInternal(
                continuationToken,
                _prefix,
                _shareSnapshot,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<FilesAndDirectoriesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            var items = new List<StorageFileItem>();
            items.AddRange(response.Value.DirectoryItems.Select(d => new StorageFileItem(true, d.Name)));
            items.AddRange(response.Value.FileItems.Select(f => new StorageFileItem(false, f.Name, f.Properties?.ContentLength)));
            return Page<StorageFileItem>.FromValues(
                items.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
