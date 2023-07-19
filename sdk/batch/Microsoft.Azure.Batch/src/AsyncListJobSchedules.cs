// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListJobSchedulesEnumerator : AsyncListEnumerator<CloudJobSchedule, Models.CloudJobSchedule, Models.JobScheduleListHeaders>
    {
        private readonly JobScheduleOperations _parentJobScheduleOperations;

        internal AsyncListJobSchedulesEnumerator(JobScheduleOperations parentJobScheduleOperations, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentJobScheduleOperations = parentJobScheduleOperations;
        }

        internal override CloudJobSchedule Wrap(Models.CloudJobSchedule protocolObj)
        {
            return new CloudJobSchedule(_parentJobScheduleOperations.ParentBatchClient, protocolObj, behaviorMgr.BaseBehaviors);
        }

        internal override Task<AzureOperationResponse<IPage<Models.CloudJobSchedule>, Models.JobScheduleListHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentJobScheduleOperations.ParentBatchClient.ProtocolLayer.ListJobSchedules(
                    skipHandler.SkipToken,
                    behaviorMgr,
                    detailLevel,
                    cancellationToken);
        }
    }
}
