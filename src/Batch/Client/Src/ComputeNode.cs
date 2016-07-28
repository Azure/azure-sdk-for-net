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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// Summarizes the state of a compute node.
    /// </summary>
    public partial class ComputeNode : IRefreshable
    {

#region ComputeNode

        /// <summary>
        /// Instantiates an unbound ComputeNodeUser object to be populated by the caller and used to create a user account on the compute node in the Azure Batch service.
        /// </summary>
        /// <returns>An <see cref="ComputeNodeUser"/> object.</returns>
        public ComputeNodeUser CreateComputeNodeUser()
        {
            ComputeNodeUser newUser = new ComputeNodeUser(this.parentBatchClient, this.CustomBehaviors, this.parentPoolId, this.Id);

            return newUser;
        }

        /// <summary>
        /// Begins an asynchronous call to delete the specified ComputeNodeUser.
        /// </summary>
        /// <param name="userName">The name of the ComputeNodeUser to be deleted.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task DeleteComputeNodeUserAsync(
            string userName, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.DeleteComputeNodeUser(this.parentPoolId, this.Id, userName, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to delete the specified ComputeNodeUser.
        /// </summary>
        /// <param name="userName">The name of the ComputeNodeUser to be deleted.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>

        public void DeleteComputeNodeUser(string userName, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = DeleteComputeNodeUserAsync(userName, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Begins an asynchronous call to get RDP file data targeting the compute node of the current instance and write them to a specified Stream.
        /// </summary>
        /// <param name="rdpStream">The Stream into which the RDP file data will be written.  This stream will not be closed or rewound by this call.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task GetRDPFileAsync(Stream rdpStream, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.GetComputeNodeRDPFile(this.parentPoolId, this.Id, rdpStream, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to get RDP file data targeting the compute node of the current instance and write them to a specified Stream.
        /// </summary>
        /// <param name="rdpStream">The Stream into which the RDP file data will be written.  This stream will not be closed or rewound by this call.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void GetRDPFile(Stream rdpStream, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = GetRDPFileAsync(rdpStream, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Begins an asynchronous call to get RDP file data targeting the compute node of the current instance and write them to a file with the specified name.
        /// </summary>
        /// <param name="rdpFileNameToCreate">The name of the RDP file to be created.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task GetRDPFileAsync(
            string rdpFileNameToCreate, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.PoolOperations.GetRDPFileViaFileNameAsyncImpl(this.parentPoolId, this.Id, rdpFileNameToCreate, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to get RDP file data targeting the compute node of the current instance and write them to a file with the specified name.
        /// </summary>
        /// <param name="rdpFileNameToCreate">The name of the RDP file to be created.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void GetRDPFile(string rdpFileNameToCreate, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = GetRDPFileAsync(rdpFileNameToCreate, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Gets the settings required for remote login to a compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The get remote login settings operation runs asynchronously.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="VirtualMachineConfiguration"/> property. 
        /// If this method is invoked on pools created with <see cref="CloudServiceConfiguration" />, then Batch service returns 409 (Conflict). 
        /// For pools with a <see cref="CloudServiceConfiguration" /> property, one of the GetRDPFileAsync/GetRDPFile methods must be used.</para>
        /// </remarks>
        public System.Threading.Tasks.Task<RemoteLoginSettings> GetRemoteLoginSettingsAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null,  CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task<RemoteLoginSettings> asyncTask = this.parentBatchClient.PoolOperations.GetRemoteLoginSettingsImpl(
                    this.parentPoolId,
                    this.Id,
                    bhMgr,
                    cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets the settings required for remote login to a compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="Microsoft.Azure.Batch.ComputeNode.GetRemoteLoginSettingsAsync"/>.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="Microsoft.Azure.Batch.VirtualMachineConfiguration"/> property. 
        /// If this method is invoked on pools created with <see cref="Microsoft.Azure.Batch.CloudServiceConfiguration" />, then Batch service returns 409 (Conflict). 
        /// For pools with a <see cref="Microsoft.Azure.Batch.CloudServiceConfiguration" /> property, one of the GetRDPFileAsync/GetRDPFile methods must be used.</para>
        /// </remarks>
        public RemoteLoginSettings GetRemoteLoginSettings(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<RemoteLoginSettings> asyncTask = GetRemoteLoginSettingsAsync( additionalBehaviors))
            {
                RemoteLoginSettings rls = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

                return rls;
            }
        }

        /// <summary>
        /// Begins an asynchronous call to remove the compute node from the pool.
        /// </summary>
        /// <param name="deallocationOption">The deallocation option to use when removing the compute node from the pool.</param>
        /// <param name="resizeTimeout">The maximum amount of time which the RemoveFromPool operation can take before being terminated by the Azure Batch system.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task RemoveFromPoolAsync(
            Common.ComputeNodeDeallocationOption? deallocationOption = null, 
            TimeSpan? resizeTimeout = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            List<string> computeNodeIds = new List<string> {this.Id};

            Task asyncTask = this.parentBatchClient.PoolOperations.RemoveFromPoolAsyncImpl(this.parentPoolId, computeNodeIds, deallocationOption, resizeTimeout, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to remove the compute node from the pool.
        /// </summary>
        /// <param name="deallocationOption">The deallocation option to use when removing the compute node from the pool.</param>
        /// <param name="resizeTimeout">The maximum amount of time which the RemoveFromPool operation can take before being terminated by the Azure Batch system.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void RemoveFromPool(Common.ComputeNodeDeallocationOption? deallocationOption = null, TimeSpan? resizeTimeout = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = RemoveFromPoolAsync(deallocationOption, resizeTimeout, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Begins an asynchronous call to reboot the compute node.
        /// </summary>
        /// <param name="rebootOption">The reboot option associated with the reboot.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task RebootAsync(
            Common.ComputeNodeRebootOption? rebootOption = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.RebootComputeNode(this.parentPoolId, this.Id, rebootOption, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to reboot the compute node.
        /// </summary>
        /// <param name="rebootOption">The reboot option associated with the reboot.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void Reboot(Common.ComputeNodeRebootOption? rebootOption = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = RebootAsync(rebootOption, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Begins an asynchronous call to reimage the compute node.
        /// </summary>
        /// <param name="reimageOption">The reimage option associated with the reimage.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task ReimageAsync(
            Common.ComputeNodeReimageOption? reimageOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.ReimageComputeNode(this.parentPoolId, this.Id, reimageOption, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to reimage the compute node.
        /// </summary>
        /// <param name="reimageOption">The reimage option associated with the reimage.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void Reimage(Common.ComputeNodeReimageOption? reimageOption = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = ReimageAsync(reimageOption, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Begins an asynchronous request to get the specified NodeFile.
        /// </summary>
        /// <param name="fileName">The name of the NodeFile.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public System.Threading.Tasks.Task<NodeFile> GetNodeFileAsync(
            string fileName, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task<NodeFile> asyncTask = this.parentBatchClient.PoolOperations.GetNodeFileAsyncImpl(this.parentPoolId, this.Id, fileName, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to get the specified NodeFile.
        /// </summary>
        /// <param name="fileName">The name of the NodeFile.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <returns>A bound <see cref="NodeFile"/> object.</returns>
        public NodeFile GetNodeFile(string fileName, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task<NodeFile> asyncTask = this.GetNodeFileAsync(fileName, additionalBehaviors))
            {
                return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Exposes synchronous and asynchronous enumeration of the files for the node.
        /// </summary>
        /// <param name="recursive">If true, performs a recursive list of all files of the node. If false, returns only the files at the node directory root.</param>
        /// <param name="detailLevel">Controls the detail level of the data returned by a call to the Azure Batch Service.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object and after the behavior implementing the DetailLevel.</param>
        /// <returns>An instance of IPagedEnumerable that can be used to enumerate objects using either synchronous or asynchronous patterns.</returns>
        public IPagedEnumerable<NodeFile> ListNodeFiles(bool? recursive = null, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<NodeFile> enumerator = this.parentBatchClient.PoolOperations.ListNodeFilesImpl(this.parentPoolId, this.Id, recursive, bhMgr, detailLevel);

            return enumerator;
        }

        /// <summary>
        /// Enables task scheduling on the compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>This operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task EnableSchedulingAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.EnableComputeNodeSchedulingAsync(this.parentPoolId, this.Id, additionalBehaviors, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Enables task scheduling on the compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableScheduling"/>.</remarks>
        public void EnableScheduling(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = EnableSchedulingAsync(additionalBehaviors, CancellationToken.None))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Disables task scheduling on the compute node.
        /// </summary>
        /// <param name="disableComputeNodeSchedulingOption">Specifies what to do with currently running tasks. The default is <see cref="Common.DisableComputeNodeSchedulingOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>This operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task DisableSchedulingAsync(
            Common.DisableComputeNodeSchedulingOption? disableComputeNodeSchedulingOption,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.DisableComputeNodeSchedulingAsync(this.parentPoolId, this.Id, disableComputeNodeSchedulingOption, additionalBehaviors, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Disables task scheduling on the compute node.
        /// </summary>
        /// <param name="disableComputeNodeSchedulingOption">Specifies what to do with currently running tasks. The default is <see cref="Common.DisableComputeNodeSchedulingOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableSchedulingAsync"/>.</remarks>
        public void DisableScheduling(
            Common.DisableComputeNodeSchedulingOption? disableComputeNodeSchedulingOption,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = DisableSchedulingAsync(disableComputeNodeSchedulingOption, additionalBehaviors, CancellationToken.None))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

#endregion ComputeNode

#region IRefreshable

        /// <summary>
        /// Refreshes the current <see cref="ComputeNode"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh. If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous refresh operation.</returns>
        public async Task RefreshAsync(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.ComputeNode, Models.ComputeNodeGetHeaders>> asyncTask = 
                this.parentBatchClient.ProtocolLayer.GetComputeNode(this.parentPoolId, this.Id, bhMgr, cancellationToken);

            AzureOperationResponse<Models.ComputeNode, Models.ComputeNodeGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // get pool from response
            Models.ComputeNode newProtocolComputeNode = response.Body;

            this.propertyContainer = new PropertyContainer(newProtocolComputeNode);
        }

        /// <summary>
        /// Refreshes the <see cref="ComputeNode"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh. If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

#endregion
    }

}
