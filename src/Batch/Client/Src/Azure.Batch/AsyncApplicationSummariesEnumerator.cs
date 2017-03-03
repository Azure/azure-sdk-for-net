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

    internal class AsyncApplicationSummariesEnumerator : PagedEnumeratorBase<ApplicationSummary>
    {
        private readonly ApplicationOperations _parentApplicationOperations;

        private readonly BehaviorManager _behaviorMgr;
        private readonly DetailLevel _detailLevel;

#region // constructors

        private AsyncApplicationSummariesEnumerator()
        {
        }

        internal AsyncApplicationSummariesEnumerator(
                ApplicationOperations parentApplicationOperations,
                BehaviorManager behaviorMgr,
                DetailLevel detailLevel)
        {
            _parentApplicationOperations = parentApplicationOperations;
            _behaviorMgr = behaviorMgr;
            _detailLevel = detailLevel;
        }

#endregion // constructors

        protected override async System.Threading.Tasks.Task GetNextBatchFromServerAsync(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            do
            {
                // start the protocol layer call

                var asyncTask = this._parentApplicationOperations.ParentBatchClient.ProtocolLayer.ListApplicationSummaries(
                    skipHandler.SkipToken,
                    _behaviorMgr,
                    _detailLevel,
                    cancellationToken);

                var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                skipHandler.SkipToken = response.Body.NextPageLink;
                
                // remember the protocol tasks returned
                base._currentBatch = null;

                if (null != response.Body)
                {
                    base._currentBatch = response.Body.ToArray();
                }
            }
            // it is possible for there to be no results so we keep trying
            while (skipHandler.ThereIsMoreData && ((null == _currentBatch) || _currentBatch.Length <= 0));
        }

        public override ApplicationSummary Current  // for IPagedEnumerator<T> and IEnumerator<T>
        {
            get
            {
                // start with the current object off of base
                object curObj = base._currentBatch[base._currentIndex];

                // it must be a protocol object from previous call
                Models.ApplicationSummary protocolObj = curObj as Models.ApplicationSummary;

                Debug.Assert(null != protocolObj);

                // wrap protocol object
                ApplicationSummary wrapped = new ApplicationSummary(protocolObj);

                return wrapped;
            }
        }
    }
}
