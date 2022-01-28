// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListNodeFilesByTaskEnumerator : AsyncListEnumerator<NodeFile, Models.NodeFile, Models.FileListFromTaskHeaders>
    {
        private readonly JobOperations _jobOperations;
        private readonly string _jobId;
        private readonly string _taskId;
        private readonly bool? _recursive;

        internal AsyncListNodeFilesByTaskEnumerator(JobOperations jobOperations, string jobId, string taskId, bool? recursive, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _jobOperations = jobOperations;
            _jobId = jobId;
            _taskId = taskId;
            _recursive = recursive;
        }

        internal override NodeFile Wrap(Models.NodeFile protocolObj)
        {
            return new TaskFile(_jobOperations, _jobId, _taskId, protocolObj, behaviorMgr.BaseBehaviors);
        }

        internal override Task<AzureOperationResponse<IPage<Models.NodeFile>, Models.FileListFromTaskHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _jobOperations.ParentBatchClient.ProtocolLayer.ListNodeFilesByTask(
                    _jobId,
                    _taskId,
                    _recursive,
                    skipHandler.SkipToken,
                    behaviorMgr,
                    detailLevel,
                    cancellationToken);
        }
    }
}
