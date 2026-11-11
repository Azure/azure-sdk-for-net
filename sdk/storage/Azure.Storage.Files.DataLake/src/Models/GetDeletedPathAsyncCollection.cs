// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.DataLake.Models
{
    internal class GetDeletedPathAsyncCollection : StorageCollectionEnumerator<PathDeletedItem>
    {
        private readonly DataLakeFileSystemClient _client;
        private readonly string _path;
        private readonly int? _requestPriority;
        private readonly string _operationName;

        public GetDeletedPathAsyncCollection(
            DataLakeFileSystemClient client,
            string path,
            int? requestPriority,
            string operationName)
        {
            _client = client;
            _path = path;
            _requestPriority = requestPriority;
            _operationName = operationName;
        }

        public override async ValueTask<Page<PathDeletedItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<PathDeletedSegment> response = await _client.GetDeletedPathsInternal(
                _path,
                continuationToken,
                pageSizeHint,
                _requestPriority,
                _operationName,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            return Page<PathDeletedItem>.FromValues(
                response.Value.DeletedPaths.Select(r => r.Path).ToArray(),
                response.Value.Continuation,
                response.GetRawResponse());
        }
    }
}
