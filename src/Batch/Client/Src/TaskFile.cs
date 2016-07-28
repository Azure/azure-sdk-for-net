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

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Models = Microsoft.Azure.Batch.Protocol.Models;
using System.Threading;

namespace Microsoft.Azure.Batch
{
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
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(base.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.NodeFile, Models.FileGetFromTaskHeaders>> asyncTask = 
                this._jobOperations.ParentBatchClient.ProtocolLayer.GetNodeFileByTask(
                    _jobId, 
                    _taskId, 
                    base.Name, 
                    stream, 
                    bhMgr, 
                    cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        public override async System.Threading.Tasks.Task DeleteAsync(bool? recursive = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(base.CustomBehaviors, additionalBehaviors);

            var asyncTask = this._jobOperations.ParentBatchClient.ProtocolLayer.DeleteNodeFileByTask(_jobId, _taskId, base.Name, recursive, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }
        
#endregion // NodeFile

#region IRefreshable

        public override async System.Threading.Tasks.Task RefreshAsync(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(base.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.NodeFile, Models.FileGetNodeFilePropertiesFromTaskHeaders>> asyncTask = 
                this._jobOperations.ParentBatchClient.ProtocolLayer.GetNodeFilePropertiesByTask(
                    _jobId, 
                    _taskId, 
                    this.Name, 
                    bhMgr, 
                    cancellationToken);

            AzureOperationResponse<Models.NodeFile, Models.FileGetNodeFilePropertiesFromTaskHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // immediately available to all threads
            System.Threading.Interlocked.Exchange(ref base.fileItemBox, new FileItemBox(response.Body));
        }

        public override void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

#endregion IRefreshable

    }
}
        

