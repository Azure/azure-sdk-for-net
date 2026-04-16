// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Files.Shares.Models
{
    internal class GetShareFileRangeListAsyncCollection : StorageCollectionEnumerator<ShareFileRange>
    {
        private readonly bool _diff;
        private readonly ShareFileClient _client;
        private readonly HttpRange? _range;
        private readonly string _snapshot;
        private readonly string _previousSnapshot;
        private readonly bool? _supportRename;
        private readonly ShareFileRequestConditions _conditions;
        private readonly string _operationName;

        public GetShareFileRangeListAsyncCollection(
            bool diff,
            ShareFileClient client,
            HttpRange? range,
            string snapshot,
            string previousSnapshot,
            bool? supportRename,
            ShareFileRequestConditions conditions,
            string operationName)
        {
            _diff = diff;
            _client = client;
            _range = range;
            _snapshot = snapshot;
            _previousSnapshot = previousSnapshot;
            _supportRename = supportRename;
            _conditions = conditions;
            _operationName = operationName;
        }

        public override async ValueTask<Page<ShareFileRange>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            ResponseWithHeaders<ShareFileRangeList, FileGetRangeListHeaders> response = await _client.GetAllRangeListInternal(
                marker: continuationToken,
                pageSizeHint: pageSizeHint ?? Constants.File.DefaultGetRangeListPageSize,
                range: _range,
                snapshot: _snapshot,
                previousSnapshot: _diff ? _previousSnapshot : null,
                supportRename: _diff ? _supportRename : null,
                conditions: _conditions,
                operationName: _operationName,
                async: async,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return Page<ShareFileRange>.FromValues(
                values: response.ToShareFileRanges(),
                continuationToken: response.Value.NextMarker,
                response: response.GetRawResponse());
        }
    }
}
