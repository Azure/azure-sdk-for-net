// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListTasksEnumerator : AsyncListEnumerator<CloudTask, Models.CloudTask, Models.TaskListHeaders>
    {
        private readonly JobOperations _jobOperations;
        private readonly string _jobId;

        internal AsyncListTasksEnumerator(
                JobOperations jobOperations,
                string jobId,
                BehaviorManager behaviorMgr,
                DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _jobOperations = jobOperations;
            _jobId = jobId;
        }

        internal override CloudTask Wrap(Models.CloudTask protocolObj)
        {
            return new CloudTask(_jobOperations.ParentBatchClient, _jobId, protocolObj, behaviorMgr.BaseBehaviors);
        }

        internal override Task<AzureOperationResponse<IPage<Models.CloudTask>, Models.TaskListHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _jobOperations.ParentBatchClient.ProtocolLayer.ListTasks(
                    _jobId,
                    skipHandler.SkipToken,
                    behaviorMgr,
                    detailLevel,
                    cancellationToken);
        }
    }
}
