// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    internal class AsyncListJobsEnumerator : PagedEnumeratorBase<CloudJob>
    {
        private readonly BatchClient _parentBatchClient;
        private readonly BehaviorManager _behaviorMgr;
        private readonly string _jobScheduleIdForcesListByJobSchedule; // if non-null this triggers list-jobs-by-schedule
        private readonly DetailLevel _detailLevel;

        #region // constructors

        /// <summary>
        /// An iterator that lists-jobs (not by schedule)
        /// </summary>
        internal AsyncListJobsEnumerator(
                BatchClient parentBatchClient,
                BehaviorManager behaviorMgr,
                DetailLevel detailLevel)
        {
            this._parentBatchClient = parentBatchClient;
            this._behaviorMgr = behaviorMgr;
            this._detailLevel = detailLevel;
        }

        /// <summary>
        /// An iterator that calls list-jobs-by-schedule
        /// </summary>
        internal AsyncListJobsEnumerator(
                BatchClient parentBatchClient,
                string jobScheduleId,
                BehaviorManager behaviorMgr,
                DetailLevel detailLevel)
        {
            this._parentBatchClient = parentBatchClient;
            this._jobScheduleIdForcesListByJobSchedule = jobScheduleId;
            this._behaviorMgr = behaviorMgr;
            this._detailLevel = detailLevel;
        }

        #endregion // constructors

        public override CloudJob Current  // for IPagedEnumerator<T> and IEnumerator<T>
        {
            get
            {
                // start with the current object off of base
                object curObj = base._currentBatch[base._currentIndex];

                // it must be a protocol object from previous call
                Models.CloudJob protocolObj = curObj as Models.CloudJob;

                Debug.Assert(null != protocolObj);

                // wrap protocol object
                CloudJob wrapped = new CloudJob(this._parentBatchClient, protocolObj, _behaviorMgr.BaseBehaviors);

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
                if (string.IsNullOrEmpty(_jobScheduleIdForcesListByJobSchedule))
                {
                    Task<AzureOperationResponse<IPage<Models.CloudJob>, Models.JobListHeaders>> asyncTask =
                        this._parentBatchClient.ProtocolLayer.ListJobsAll(
                            skipHandler.SkipToken,
                            _behaviorMgr,
                            _detailLevel,
                            cancellationToken);

                    var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                    this.ProcessPage(response.Body, skipHandler);
                }
                else
                {
                    Task<AzureOperationResponse<IPage<Models.CloudJob>, Models.JobListFromJobScheduleHeaders>> asyncTask =
                        this._parentBatchClient.ProtocolLayer.ListJobsBySchedule(
                            _jobScheduleIdForcesListByJobSchedule,
                            skipHandler.SkipToken,
                            _behaviorMgr,
                            _detailLevel,
                            cancellationToken);

                    var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                    this.ProcessPage(response.Body, skipHandler);
                }

            }
            // it is possible for there to be no results so we keep trying
            while (skipHandler.ThereIsMoreData && ((null == _currentBatch) || _currentBatch.Length <= 0));
        }

        private void ProcessPage(IPage<Models.CloudJob> currentPage, SkipTokenHandler skipHandler)
        {
            // remember any skiptoken returned.  This also sets the bool
            skipHandler.SkipToken = currentPage.NextPageLink;

            // remember the protocol tasks returned
            base._currentBatch = null;

            if (null != currentPage.GetEnumerator())
            {
                base._currentBatch = currentPage.ToArray();
            }
        } 
    }
}
