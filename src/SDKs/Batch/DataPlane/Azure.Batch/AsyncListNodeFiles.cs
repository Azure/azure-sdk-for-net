// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    internal class AsyncListNodeFilesByNodeEnumerator : PagedEnumeratorBase<NodeFile>
    {
        private readonly PoolOperations _parentPoolOperations;
        private readonly string _poolId;
        private readonly string _computeNodeId;
        private readonly bool? _recursive;
        private readonly BehaviorManager _behaviorMgr;
        private readonly DetailLevel _detailLevel;

#region // constructors

        internal AsyncListNodeFilesByNodeEnumerator(
                PoolOperations parentPoolOperations,
                string poolId,
                string computeNodeId,
                bool? recursive,
                BehaviorManager behaviorMgr,
                DetailLevel detailLevel)
        {
            _parentPoolOperations = parentPoolOperations;
            _poolId = poolId;
            _computeNodeId = computeNodeId;
            _recursive = recursive;
            _behaviorMgr = behaviorMgr;
            _detailLevel = detailLevel;
        }

#endregion // constructors

        public override NodeFile Current  // for IPagedEnumerator<T> and IEnumerator<T>
        {
            get
            {
                // start with the current object off of base
                object curObj = base._currentBatch[base._currentIndex];

                // it must be a protocol object from previous call
                Models.NodeFile protoFile = curObj as Models.NodeFile;

                Debug.Assert(null != protoFile);

                // wrap protocol object
                NodeFile wrapped = new ComputeNodeFile(_parentPoolOperations, _poolId, _computeNodeId, protoFile, _behaviorMgr.BaseBehaviors);

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
                var asyncTask = _parentPoolOperations.ParentBatchClient.ProtocolLayer.ListNodeFilesByNode(
                    _poolId,
                    _computeNodeId,
                    _recursive,
                    skipHandler.SkipToken,
                    _behaviorMgr,
                    _detailLevel,
                    cancellationToken);

                // extract the response
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
            while (skipHandler.ThereIsMoreData && ((null == base._currentBatch) || base._currentBatch.Length <= 0));
        }
    }
}
