// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.DataLake.Models
{
    internal class GetPathsAsyncCollection : StorageCollectionEnumerator<PathItem>
    {
        private readonly DataLakeFileSystemClient _client;
        private readonly string _path;
        private readonly bool _recursive;
        private readonly bool _upn;

        public GetPathsAsyncCollection(
            DataLakeFileSystemClient client,
            string path,
            bool recursive,
            bool upn)
        {
            _client = client;
            _path = path;
            _recursive = recursive;
            _upn = upn;
        }

        public override async ValueTask<Page<PathItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<PathSegment> response = await _client.GetPathsInternal(
                _path,
                _recursive,
                _upn,
                continuationToken,
                pageSizeHint,
                async,
                cancellationToken).ConfigureAwait(false);

            return Page<PathItem>.FromValues(
                response.Value.Paths.ToArray(),
                response.Value.Continuation,
                response.GetRawResponse());
        }
    }
}
