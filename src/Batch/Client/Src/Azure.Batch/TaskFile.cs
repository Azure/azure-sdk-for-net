// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Threading.Tasks;
    using System.Threading;
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Rest.Azure;

    internal class TaskFile : NodeFile
    {
        private readonly JobOperations _jobOperations;
        private readonly string _jobId;
        private readonly string _taskId;
        
#region  // constructors
        
        internal TaskFile(
            JobOperations jobOperations,
            string jobId,
            string taskId, 
            Models.NodeFile boundToThis, 
            IEnumerable<BatchClientBehavior> inheritTheseBehaviors) : base(boundToThis, inheritTheseBehaviors)
        {
            _jobOperations = jobOperations;
            _jobId = jobId;
            _taskId = taskId;
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

            System.Threading.Tasks.Task<AzureOperationResponse<Models.NodeFile, Models.FileGetFromTaskHeaders>> asyncTask = 
                this._jobOperations.ParentBatchClient.ProtocolLayer.GetNodeFileByTask(
                    _jobId, 
                    _taskId, 
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

            var asyncTask = this._jobOperations.ParentBatchClient.ProtocolLayer.DeleteNodeFileByTask(_jobId, _taskId, base.Path, recursive, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }
        
#endregion // NodeFile

#region IRefreshable

        public override async System.Threading.Tasks.Task RefreshAsync(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(base.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromTaskHeaders>> asyncTask = 
                this._jobOperations.ParentBatchClient.ProtocolLayer.GetNodeFilePropertiesByTask(
                    _jobId, 
                    _taskId, 
                    this.Path, 
                    bhMgr, 
                    cancellationToken);

            AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromTaskHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // immediately available to all threads
            System.Threading.Interlocked.Exchange(ref base.fileItemBox, new FileItemBox(response.Body));
        }

        public override void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

#endregion IRefreshable

    }
}
        

