// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    internal class AsyncListJobSchedulesEnumerator : PagedEnumeratorBase<CloudJobSchedule>
    {
        private readonly JobScheduleOperations _parentJobScheduleOperations;
        private readonly BehaviorManager _behaviorMgr;
        private readonly DetailLevel _detailLevel;

#region // constructors

        internal AsyncListJobSchedulesEnumerator(
                JobScheduleOperations parentJobScheduleOperations,
                BehaviorManager behaviorMgr,
                DetailLevel detailLevel)
        {
            this._parentJobScheduleOperations = parentJobScheduleOperations;
            this._behaviorMgr = behaviorMgr;
            this._detailLevel = detailLevel;
        }

#endregion // constructors

        public override CloudJobSchedule Current  // for IPagedEnumerator<T> and IEnumerator<T>
        {
            get
            {
                // start with the current object off of base
                object curObj = base._currentBatch[base._currentIndex];

                // it must be a protocol object from previous call
                Models.CloudJobSchedule protocolObj = curObj as Models.CloudJobSchedule;

                Debug.Assert(null != protocolObj);

                // wrap protocol object
                CloudJobSchedule wrapped = new CloudJobSchedule(this._parentJobScheduleOperations.ParentBatchClient, protocolObj, _behaviorMgr.BaseBehaviors);

                return wrapped;
            }
        }

        /// <summary>
        /// fetch another batch of objects from the server
        /// </summary>
        protected async override System.Threading.Tasks.Task GetNextBatchFromServerAsync(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            do
            {
                // start the protocol layer call
                var asyncTask = this._parentJobScheduleOperations.ParentBatchClient.ProtocolLayer.ListJobSchedules(
                    skipHandler.SkipToken,
                    _behaviorMgr,
                    _detailLevel,
                    cancellationToken);

                var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                // remember any skiptoken returned.  This also sets the bool
                skipHandler.SkipToken = response.Body.NextPageLink;

                // remember the protocol tasks returned
                base._currentBatch = null;

                if (null != response.Body.GetEnumerator())
                {
                    base._currentBatch = response.Body.ToArray();
                }
            }
            // it is possible for there to be no results so we keep trying
            while (skipHandler.ThereIsMoreData && ((null == _currentBatch) || _currentBatch.Length <= 0));
        }
    }
}
