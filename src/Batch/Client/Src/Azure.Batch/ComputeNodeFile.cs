// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System.Collections.Generic;
using System.IO;
using Task = System.Threading.Tasks.Task;
using Models = Microsoft.Azure.Batch.Protocol.Models;
using System.Threading;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Batch
{
    internal class ComputeNodeFile : NodeFile
    {
        private readonly PoolOperations _poolOperations;
        private readonly string _poolId;
        private readonly string _computeNodeId;
        
#region  // constructors
        
        internal ComputeNodeFile(
            PoolOperations poolOperations, 
            string poolId, 
            string computeNodeId, 
            Models.NodeFile boundToThis, 
            IEnumerable<BatchClientBehavior> inheritTheseBehaviors) : base(boundToThis, inheritTheseBehaviors)
        {
            _poolOperations = poolOperations;
            _poolId = poolId;
            _computeNodeId = computeNodeId;
        }
#endregion

#region // NodeFile

        public override async System.Threading.Tasks.Task CopyToStreamAsync(
            Stream stream,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(base.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.NodeFile, Models.FileGetFromComputeNodeHeaders>> asyncTask = 
                this._poolOperations.ParentBatchClient.ProtocolLayer.GetNodeFileByNode(
                    _poolId, 
                    _computeNodeId, 
                    base.Path, 
                    stream,
                    byteRange,
                    bhMgr, 
                    cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        public override async System.Threading.Tasks.Task DeleteAsync(bool? recursive = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(base.CustomBehaviors, additionalBehaviors);

            var asyncTask = _poolOperations.ParentBatchClient.ProtocolLayer.DeleteNodeFileByNode(
                _poolId, 
                _computeNodeId, 
                base.Path, 
                recursive,
                bhMgr, 
                cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

#endregion

#region IRefreshable

        public override async System.Threading.Tasks.Task RefreshAsync(
            DetailLevel detailLevel = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(base.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromComputeNodeHeaders>> asyncTask = 
                this._poolOperations.ParentBatchClient.ProtocolLayer.GetNodeFilePropertiesByNode(
                    _poolId, 
                    _computeNodeId, 
                    base.Path, 
                    bhMgr, 
                    cancellationToken);

            AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromComputeNodeHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // immediately available to all threads
            System.Threading.Interlocked.Exchange(ref base.fileItemBox, new FileItemBox(response.Body));
        }

        public override void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

#endregion

    }
}
