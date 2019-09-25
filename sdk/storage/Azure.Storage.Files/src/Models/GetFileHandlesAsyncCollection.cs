﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            _client = client;
        }

        protected override async Task<Page<StorageHandle>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<StorageHandlesSegment>> task = _client.GetHandlesInternal(
                continuationToken,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<StorageHandlesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return new Page<StorageHandle>(
                response.Value.Handles.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
