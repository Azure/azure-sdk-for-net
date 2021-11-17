// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListPoolsEnumerator : AsyncListEnumerator<CloudPool, Models.CloudPool, Models.PoolListHeaders>
    {
        private readonly PoolOperations _parentPoolOperations;

        internal AsyncListPoolsEnumerator(PoolOperations parentPoolOperations, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentPoolOperations = parentPoolOperations;
        }

        internal override CloudPool Wrap(Models.CloudPool protocolObj)
        {
            return new CloudPool(_parentPoolOperations.ParentBatchClient, protocolObj, behaviorMgr.BaseBehaviors);
        }

        internal override Task<AzureOperationResponse<IPage<Models.CloudPool>, Models.PoolListHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentPoolOperations.ParentBatchClient.ProtocolLayer.ListPools(
                skipHandler.SkipToken,
                behaviorMgr,
                detailLevel,
                cancellationToken);
        }
    }
}
