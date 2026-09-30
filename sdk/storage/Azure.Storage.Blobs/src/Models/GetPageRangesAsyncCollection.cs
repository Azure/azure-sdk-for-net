// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    internal class GetPageRangesAsyncCollection : StorageCollectionEnumerator<PageRangeItem>
    {
        // indicates if we are calling GetPageRange or GetPageRangeDiff.
        private readonly bool _diff;
        private readonly PageBlobClient _client;
        private readonly HttpRange? _range;
        private readonly string _snapshot;
        private readonly string _previousSnapshot;
        private readonly Uri _previousSnapshotUri;
        private readonly PageBlobRequestConditions _requestConditions;
        private readonly string _operationName;

        public GetPageRangesAsyncCollection(
            bool diff,
            PageBlobClient client,
            HttpRange? range,
            string snapshot,
            string previousSnapshot,
            Uri previousSnapshotUri,
            PageBlobRequestConditions requestConditions,
            string operationName)
        {
            _diff = diff;
            _client = client;
            _range = range;
            _snapshot = snapshot;
            _previousSnapshot = previousSnapshot;
            _previousSnapshotUri = previousSnapshotUri;
            _requestConditions = requestConditions;
            _operationName = operationName;
        }

        public override async ValueTask<Page<PageRangeItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            // We are calling GetPageRangeDiff
            if (_diff)
            {
                ResponseWithHeaders<PageList, PageBlobGetPageRangesDiffHeaders> response;
                if (async)
                {
                    response = await _client.GetAllPageRangesDiffInternal(
                        marker: continuationToken,
                        pageSizeHint: pageSizeHint,
                        range: _range,
                        snapshot: _snapshot,
                        previousSnapshot: _previousSnapshot,
                        previousSnapshotUri: _previousSnapshotUri,
                        conditions: _requestConditions,
                        async: true,
                        operationName: _operationName,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    response = _client.GetAllPageRangesDiffInternal(
                        marker: continuationToken,
                        pageSizeHint: pageSizeHint,
                        range: _range,
                        snapshot: _snapshot,
                        previousSnapshot: _previousSnapshot,
                        previousSnapshotUri: _previousSnapshotUri,
                        conditions: _requestConditions,
                        async: false,
                        operationName: _operationName,
                        cancellationToken: cancellationToken)
                        .EnsureCompleted();
                }

                return Page<PageRangeItem>.FromValues(
                    values: response.ToPageBlobRanges(),
                    continuationToken: response.Value.NextMarker,
                    response: response.GetRawResponse());
            }

            // We are calling GetPageRange
            else
            {
                ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders> response;
                if (async)
                {
                    response = await _client.GetAllPageRangesInteral(
                        marker: continuationToken,
                        pageSizeHint: pageSizeHint,
                        range: _range,
                        snapshot: _snapshot,
                        conditions: _requestConditions,
                        async: true,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    response = _client.GetAllPageRangesInteral(
                        marker: continuationToken,
                        pageSizeHint: pageSizeHint,
                        range: _range,
                        snapshot: _snapshot,
                        conditions: _requestConditions,
                        async: false,
                        cancellationToken: cancellationToken)
                        .EnsureCompleted();
                }

                return Page<PageRangeItem>.FromValues(
                    values: response.ToPageBlobRanges(),
                    continuationToken: response.Value.NextMarker,
                    response: response.GetRawResponse());
            }
        }
    }
}
