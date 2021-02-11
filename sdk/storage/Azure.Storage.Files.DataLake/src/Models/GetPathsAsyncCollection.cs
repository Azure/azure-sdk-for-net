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
        private readonly bool? _recursive;
        private readonly bool? _upn;
        private readonly string _operationName;

        public GetPathsAsyncCollection(
            DataLakeFileSystemClient client,
            string path,
            bool? recursive,
            bool? upn,
            string operationName)
        {
            _client = client;
            _path = path;
            _recursive = recursive;
            _upn = upn;
            _operationName = operationName;
        }

        public override async ValueTask<Page<PathItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<PathSegment> response = await _client.GetPathsInternal(
                _path,
                _recursive.GetValueOrDefault(),
                _upn.GetValueOrDefault(),
                continuationToken,
                pageSizeHint,
                _operationName,
                async,
                cancellationToken).ConfigureAwait(false);

            return Page<PathItem>.FromValues(
                response.Value.Paths.ToArray(),
                response.Value.Continuation,
                response.GetRawResponse());
        }
    }
}
