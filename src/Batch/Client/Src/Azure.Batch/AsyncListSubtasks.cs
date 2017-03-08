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

    internal class AsyncListSubtasksEnumerator : PagedEnumeratorBase<SubtaskInformation>
    {
        private readonly JobOperations _parentJobOperations;
        private readonly string _jobId;
        private readonly string _taskId;
        private readonly BehaviorManager _behaviorMgr;
        private readonly DetailLevel _detailLevel;

#region // constructors

        internal AsyncListSubtasksEnumerator(
                JobOperations parentJobOperations,
                string jobId,
                string taskId,
                BehaviorManager behaviorMgr,
                DetailLevel detailLevel)
        {
            _parentJobOperations = parentJobOperations;
            _jobId = jobId;
            _taskId = taskId;
            _behaviorMgr = behaviorMgr;
            _detailLevel = detailLevel;
        }

#endregion // constructors

        public override SubtaskInformation Current  // for IPagedEnumerator<T> and IEnumerator<T>
        {
            get
            {
                // start with the current object off of base
                object curObj = base._currentBatch[base._currentIndex];

                // it must be a protocol object from previous call
                Models.SubtaskInformation protoSubtask = curObj as Models.SubtaskInformation;

                Debug.Assert(null != protoSubtask);

                // wrap protocol object
                SubtaskInformation wrapped = new SubtaskInformation(protoSubtask);

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
                var asyncTask = _parentJobOperations.ParentBatchClient.ProtocolLayer.ListSubtasks(
                    _jobId,
                    _taskId,
                    skipHandler.SkipToken,
                    _behaviorMgr,
                    _detailLevel,
                    cancellationToken);

                var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                //TODO: For now this is always null because the service doesn't ever return a skiptoken for this operation
                //TODO: Do not follow this code pattern elsewhere as it will not correctly traverse the skiptoken.
                //TODO: Note that setting this to null sets the "_hasBeenCalled" boolean which is important for the functioning of the 
                //TODO: list functionality (see the code).
                skipHandler.SkipToken = null; 
                // remember the protocol tasks returned
                base._currentBatch = null;

                if (null != response.Body.Value.GetEnumerator())
                {
                    base._currentBatch = response.Body.Value.ToArray();
                }
            }
            // it is possible for there to be no results so we keep trying
            while (skipHandler.ThereIsMoreData && ((null == base._currentBatch) || base._currentBatch.Length <= 0));
        }
    }
}
