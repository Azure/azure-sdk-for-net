// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    internal class AsyncListPoolNodeCountsEnumerator : AsyncListEnumerator<PoolNodeCounts, Models.PoolNodeCounts, Models.AccountListPoolNodeCountsHeaders>
    {
        private readonly PoolOperations _parentPoolOperations;

        internal AsyncListPoolNodeCountsEnumerator(PoolOperations parentPoolOperations, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentPoolOperations = parentPoolOperations;
        }

        internal override PoolNodeCounts Wrap(Models.PoolNodeCounts protocolObj)
        {
            return new PoolNodeCounts(protocolObj);
        }

        internal override System.Threading.Tasks.Task<Rest.Azure.AzureOperationResponse<Rest.Azure.IPage<Models.PoolNodeCounts>, Models.AccountListPoolNodeCountsHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentPoolOperations.ParentBatchClient.ProtocolLayer.ListPoolNodeCounts(
                    skipHandler.SkipToken,
                    behaviorMgr,
                    detailLevel,
                    cancellationToken);
        }
    }
}
