// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Shares.Models
{
    internal class GetFilesAndDirectoriesAsyncCollection : StorageCollectionEnumerator<ShareFileItem>
    {
        private readonly ShareDirectoryClient _client;
        private readonly string _prefix;

        public GetFilesAndDirectoriesAsyncCollection(
            ShareDirectoryClient client,
            string prefix)
        {
            _client = client;
            _prefix = prefix;
        }

        public override async ValueTask<Page<ShareFileItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<FilesAndDirectoriesSegment>> task = _client.GetFilesAndDirectoriesInternal(
                continuationToken,
                _prefix,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<FilesAndDirectoriesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            var items = new List<ShareFileItem>();
            items.AddRange(response.Value.DirectoryItems.Select(d => new ShareFileItem(true, d.Name)));
            items.AddRange(response.Value.FileItems.Select(f => new ShareFileItem(false, f.Name, f.Properties?.ContentLength)));
            return Page<ShareFileItem>.FromValues(
                items.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
