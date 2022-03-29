// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListJobPrepReleaseTaskStatusEnumerator : AsyncListEnumerator<JobPreparationAndReleaseTaskExecutionInformation, Models.JobPreparationAndReleaseTaskExecutionInformation, Models.JobListPreparationAndReleaseTaskStatusHeaders>
    {
        private readonly JobOperations _parentJobOperations;
        private readonly string _jobId;

        internal AsyncListJobPrepReleaseTaskStatusEnumerator(JobOperations parentJobOperations, string jobId, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentJobOperations = parentJobOperations;
            _jobId = jobId;
        }

        internal override JobPreparationAndReleaseTaskExecutionInformation Wrap(Models.JobPreparationAndReleaseTaskExecutionInformation protocolObj)
        {
            return new JobPreparationAndReleaseTaskExecutionInformation(protocolObj);
        }

        internal override Task<AzureOperationResponse<IPage<Models.JobPreparationAndReleaseTaskExecutionInformation>, Models.JobListPreparationAndReleaseTaskStatusHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentJobOperations.ParentBatchClient.ProtocolLayer.ListJobPreparationAndReleaseTaskStatus(
            _jobId,
            skipHandler.SkipToken,
            behaviorMgr,
            detailLevel,
            cancellationToken);
        }
    }
}
