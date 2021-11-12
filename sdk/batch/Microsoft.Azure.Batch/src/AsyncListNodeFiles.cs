// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListNodeFilesByNodeEnumerator : AsyncListEnumerator<NodeFile, Models.NodeFile, Models.FileListFromComputeNodeHeaders>
    {
        private readonly PoolOperations _parentPoolOperations;
        private readonly string _poolId;
        private readonly string _computeNodeId;
        private readonly bool? _recursive;

        internal AsyncListNodeFilesByNodeEnumerator(PoolOperations parentPoolOperations, string poolId, string computeNodeId, bool? recursive, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentPoolOperations = parentPoolOperations;
            _poolId = poolId;
            _computeNodeId = computeNodeId;
            _recursive = recursive;
        }

        internal override NodeFile Wrap(Models.NodeFile protocolObj)
        {
            return new ComputeNodeFile(_parentPoolOperations, _poolId, _computeNodeId, protocolObj, behaviorMgr.BaseBehaviors);
        }

        internal override Task<AzureOperationResponse<IPage<Models.NodeFile>, Models.FileListFromComputeNodeHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentPoolOperations.ParentBatchClient.ProtocolLayer.ListNodeFilesByNode(
                    _poolId,
                    _computeNodeId,
                    _recursive,
                    skipHandler.SkipToken,
                    behaviorMgr,
                    detailLevel,
                    cancellationToken);
        }
    }
}
