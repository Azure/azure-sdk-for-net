// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListPoolUsageMetricsEnumerator : AsyncListEnumerator<PoolUsageMetrics, Models.PoolUsageMetrics, Models.PoolListUsageMetricsHeaders>
    {
        private readonly PoolOperations _parentPoolOperations;
        private readonly DateTime? _startTime;
        private readonly DateTime? _endTime;

        internal AsyncListPoolUsageMetricsEnumerator(PoolOperations parentPoolOperations, DateTime? startTime, DateTime? endTime, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentPoolOperations = parentPoolOperations;
            _startTime = startTime;
            _endTime = endTime;
        }

        internal override PoolUsageMetrics Wrap(Models.PoolUsageMetrics protocolObj)
        {
            return new PoolUsageMetrics(protocolObj);
        }

        internal override Task<AzureOperationResponse<IPage<Models.PoolUsageMetrics>, Models.PoolListUsageMetricsHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentPoolOperations.ParentBatchClient.ProtocolLayer.ListPoolUsageMetrics(
                        _startTime,
                        _endTime,
                        skipHandler.SkipToken,
                        behaviorMgr,
                        detailLevel,
                        cancellationToken);
        }
    }
}
