// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListComputeNodesEnumerator : AsyncListEnumerator<ComputeNode, Models.ComputeNode, Models.ComputeNodeListHeaders>
    {
        private readonly PoolOperations _parentPoolOps;
        private readonly string _poolId;

        internal AsyncListComputeNodesEnumerator(PoolOperations parentPoolOps, string poolId, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentPoolOps = parentPoolOps;
            _poolId = poolId;
        }

        internal override ComputeNode Wrap(Models.ComputeNode protocolObj)
        {
            return new ComputeNode(_parentPoolOps.ParentBatchClient, _poolId, protocolObj, behaviorMgr.BaseBehaviors);
        }

        internal override Task<AzureOperationResponse<IPage<Models.ComputeNode>, Models.ComputeNodeListHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentPoolOps.ParentBatchClient.ProtocolLayer.ListComputeNodes(
                    _poolId,
                    skipHandler.SkipToken,
                    behaviorMgr,
                    detailLevel,
                    cancellationToken);
        }
    }
}
