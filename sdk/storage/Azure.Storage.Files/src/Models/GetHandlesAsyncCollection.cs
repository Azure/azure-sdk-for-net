// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Models
{
    internal class GetFileHandlesAsyncCollection : StorageAsyncCollection<StorageHandle>
    {
        private readonly FileClient _client;

        public GetFileHandlesAsyncCollection(
            FileClient client,
            int? pageSizeHint,
            CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            this._client = client;
            this.PageSizeHint = pageSizeHint;
        }

        protected override async Task<Page<StorageHandle>> GetNextPageAsync(
            string continuationToken,
            bool isAsync,
            CancellationToken cancellationToken = default)
        {
            var task = this._client.GetHandlesAsync(
                continuationToken,
                this.PageSizeHint,
                isAsync,
                cancellationToken);
            var response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return new Page<StorageHandle>(
                response.Value.Handles.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }

    internal class GetDirectoryHandlesAsyncCollection : StorageAsyncCollection<StorageHandle>
    {
        private readonly DirectoryClient _client;
        private readonly bool? _recursive;

        public GetDirectoryHandlesAsyncCollection(
            DirectoryClient client,
            int? pageSizeHint,
            bool? recursive,
            CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            this._client = client;
            this._recursive = recursive;
            this.PageSizeHint = pageSizeHint;
        }

        protected override async Task<Page<StorageHandle>> GetNextPageAsync(
            string continuationToken,
            bool isAsync,
            CancellationToken cancellationToken = default)
        {
            var task = this._client.GetHandlesAsync(
                continuationToken,
                this.PageSizeHint,
                this._recursive,
                isAsync,
                cancellationToken);
            var response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return new Page<StorageHandle>(
                response.Value.Handles.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
