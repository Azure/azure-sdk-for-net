// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    
    /// <summary>
    /// A pool in the Azure Batch service.
    /// </summary>
    public partial class CloudPool : IRefreshable
    {
        #region CloudPool

        /// <summary>
        /// This property is an alias for <see cref="TargetDedicatedComputeNodes"/> and is supported only for backward compatibility.
        /// </summary>
        [Obsolete("Obsolete after 05/2017, use TargetDedicatedComputeNodes instead.")]
        public int? TargetDedicated
        {
            get { return this.TargetDedicatedComputeNodes; }
            set { this.TargetDedicatedComputeNodes = value; }
        }

        /// <summary>
        /// This property is an alias for <see cref="CurrentDedicatedComputeNodes"/> and is supported only for backward compatibility.
        /// </summary>
        [Obsolete("Obsolete after 05/2017, use CurrentDedicatedComputeNodes instead.")]
        public int? CurrentDedicated
        {
            get { return this.CurrentDedicatedComputeNodes; }
        }

        /// <summary>
        /// Deletes this pool.
        /// </summary>
        /// <remarks>
        /// <para>The delete operation requests that the pool be deleted.  The request puts the pool in the <see cref="Common.PoolState.Deleting"/> state.
        /// The Batch service will requeue any running tasks and perform the actual pool deletion without any further client action.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            Task asyncDelete = this.parentBatchClient.PoolOperations.DeletePoolAsync(
                this.Id,
                additionalBehaviors: additionalBehaviors,
                cancellationToken: cancellationToken);
            await asyncDelete.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes this pool.
        /// </summary>
        /// <remarks>
        /// <para>The delete operation requests that the pool be deleted.  The request puts the pool in the <see cref="Common.PoolState.Deleting"/> state.
        /// The Batch service will requeue any running tasks and perform the actual pool deletion without any further client action.</para>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteAsync"/>.</remarks>
        /// </remarks>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public void Delete(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Commits this <see cref="CloudPool" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The commit operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task CommitAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // mark this object readonly
            this.propertyContainer.IsReadOnly = true;

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // hold the tpl task for the server call
            System.Threading.Tasks.Task asyncTask;

            if (BindingState.Unbound == this.propertyContainer.BindingState)
            {
                // take all property changes and create a pool
                Models.PoolAddParameter protoPool = this.GetTransportObject();

                asyncTask = this.parentBatchClient.ProtocolLayer.AddPool(protoPool, bhMgr, cancellationToken);
            }
            else
            {
                // take all property changes and prepare to update a pool
                
                // TODO:  Get protcol layer to align the [] to IEnumerable<> for this request
                Models.CertificateReference[] certRefArray = UtilitiesInternal.ConvertToProtocolArray(this.CertificateReferences);
                Models.MetadataItem[] mdiArray = UtilitiesInternal.ConvertToProtocolArray(this.Metadata);
                Models.ApplicationPackageReference[] applicationPackageArray = UtilitiesInternal.ConvertToProtocolArray(this.ApplicationPackageReferences);
                Models.StartTask modelStartTask = UtilitiesInternal.CreateObjectWithNullCheck(this.StartTask, item => item.GetTransportObject());
                Models.NodeCommunicationMode? targetCommunicationMode = UtilitiesInternal.MapNullableEnum<Common.NodeCommunicationMode, Models.NodeCommunicationMode>(this.TargetNodeCommunicationMode);

                asyncTask = this.parentBatchClient.ProtocolLayer.UpdatePool(
                    this.Id,
                    modelStartTask, 
                    certRefArray, 
                    applicationPackageArray,
                    mdiArray,
                    targetCommunicationMode,
                    bhMgr, 
                    cancellationToken);
            }

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Commits this <see cref="CloudPool" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CommitAsync"/>.</para>
        /// </remarks>
        public void Commit(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = CommitAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Commits all pending changes to this <see cref="CloudPool" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// Updates an existing <see cref="CloudPool"/> on the Batch service by replacing its properties with the properties of this <see cref="CloudPool"/> which have been changed.
        /// Unchanged properties are ignored.
        /// All changes since the last time this entity was retrieved from the Batch service (either via <see cref="Refresh"/>, <see cref="PoolOperations.GetPool"/>,
        /// or <see cref="PoolOperations.ListPools"/>) are applied.
        /// Properties which are explicitly set to null will cause an exception because the Batch service does not support partial updates which set a property to null.
        /// If you need to set a property to null, use <see cref="Commit"/>.
        /// </para>
        /// <para>This operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task CommitChangesAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // mark this object readonly
            this.propertyContainer.IsReadOnly = true;

            // craft the bahavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // hold the tpl task for the server call
            Models.CertificateReference[] certRefArray =
                this.propertyContainer.CertificateReferencesProperty.GetTransportObjectIfChanged<CertificateReference, Models.CertificateReference>();
            Models.MetadataItem[] mdiArray = this.propertyContainer.MetadataProperty.GetTransportObjectIfChanged<MetadataItem, Models.MetadataItem>();
            Models.ApplicationPackageReference[] applicationPackageArray =
                this.propertyContainer.ApplicationPackageReferencesProperty.GetTransportObjectIfChanged<ApplicationPackageReference, Models.ApplicationPackageReference>();
            Models.StartTask modelStartTask = this.propertyContainer.StartTaskProperty.GetTransportObjectIfChanged<StartTask, Models.StartTask>();
            Models.NodeCommunicationMode? targetCommunicationMode = UtilitiesInternal.MapNullableEnum<Common.NodeCommunicationMode, Models.NodeCommunicationMode>(this.TargetNodeCommunicationMode);
            string displayName = this.propertyContainer.DisplayNameProperty.HasBeenModified ? this.propertyContainer.DisplayNameProperty.Value : null;
            string vmSize = this.propertyContainer.VirtualMachineSizeProperty.HasBeenModified ? this.propertyContainer.VirtualMachineSizeProperty.Value: null;
            int? taskSlotsPerNode = this.propertyContainer.TaskSlotsPerNodeProperty.HasBeenModified ? this.propertyContainer.TaskSlotsPerNodeProperty.Value : null;
            Models.TaskSchedulingPolicy taskSchedulingPolicy = this.propertyContainer.TaskSchedulingPolicyProperty.GetTransportObjectIfChanged<TaskSchedulingPolicy, Models.TaskSchedulingPolicy>();
            bool? enableInterNodeCommunication = this.propertyContainer.InterComputeNodeCommunicationEnabledProperty.HasBeenModified ? this.propertyContainer.InterComputeNodeCommunicationEnabledProperty.Value : null;
            Models.VirtualMachineConfiguration virtualMachineConfiguration = this.propertyContainer.VirtualMachineConfigurationProperty.GetTransportObjectIfChanged<VirtualMachineConfiguration, Models.VirtualMachineConfiguration>();
            Models.NetworkConfiguration networkConfiguration = this.propertyContainer.NetworkConfigurationProperty.GetTransportObjectIfChanged<NetworkConfiguration, Models.NetworkConfiguration>();
            Models.UserAccount[] userAccounts = this.propertyContainer.UserAccountsProperty.GetTransportObjectIfChanged<UserAccount, Models.UserAccount>();
            Models.MountConfiguration[] mountConfiguration = this.propertyContainer.MountConfigurationProperty.GetTransportObjectIfChanged<MountConfiguration, Models.MountConfiguration>();
            Models.UpgradePolicy upgradePolicy = this.propertyContainer.UpgradePolicyProperty.GetTransportObjectIfChanged<UpgradePolicy, Models.UpgradePolicy>();
            IDictionary<string, string> resourceTags = this.propertyContainer.ResourceTagsProperty.HasBeenModified ? this.propertyContainer.ResourceTagsProperty.Value : null;

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.ProtocolLayer.PatchPool(
                    this.Id,
                    modelStartTask,
                    certRefArray,
                    applicationPackageArray,
                    mdiArray,
                    targetCommunicationMode,
                    displayName,
                    vmSize,
                    taskSlotsPerNode,
                    taskSchedulingPolicy,
                    enableInterNodeCommunication,
                    virtualMachineConfiguration,
                    networkConfiguration,
                    userAccounts,
                    mountConfiguration,
                    upgradePolicy,
                    resourceTags,
                    bhMgr,
                    cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Commits all pending changes to this <see cref="CloudPool" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>
        /// Updates an existing <see cref="CloudPool"/> on the Batch service by replacing its properties with the properties of this <see cref="CloudPool"/> which have been changed.
        /// Unchanged properties are ignored.
        /// All changes since the last time this entity was retrieved from the Batch service (either via <see cref="Refresh"/>, <see cref="PoolOperations.GetPool"/>,
        /// or <see cref="PoolOperations.ListPools"/>) are applied.
        /// Properties which are explicitly set to null will cause an exception because the Batch service does not support partial updates which set a property to null.
        /// If you need to set a property to null, use the <see cref="Commit"/> method.
        /// </para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CommitChangesAsync"/>.</para>
        /// </remarks>
        public void CommitChanges(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = this.CommitChangesAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Resizes this pool.
        /// </summary>
        /// <param name="targetDedicatedComputeNodes">
        /// The desired number of dedicated compute nodes in the pool.
        /// At least one of <paramref name="targetDedicatedComputeNodes"/> and <paramref name="targetLowPriorityComputeNodes"/> is required.
        /// </param>
        /// <param name="targetLowPriorityComputeNodes">
        /// The desired number of low-priority compute nodes in the pool.
        /// At least one of <paramref name="targetDedicatedComputeNodes"/> and <paramref name="targetLowPriorityComputeNodes"/> is required.
        /// </param>
        /// <param name="resizeTimeout">The timeout for allocation of compute nodes to the pool or removal of compute nodes from the pool. If the pool has not reached the target size after this time, the resize is stopped. The default is 15 minutes.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool, if the pool size is decreasing. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The resize operation requests that the pool be resized.  The request puts the pool in the <see cref="Common.AllocationState.Resizing"/> allocation state.
        /// The Batch service will perform the actual resize without any further client action, and set the allocation state to <see cref="Common.AllocationState.Steady"/> once complete.</para>
        /// <para>
        /// You can only resize a pool when its <see cref="CloudPool.AllocationState"/> is <see cref="Common.AllocationState.Steady"/>.
        /// You cannot resize pools which are configured for automatic scaling (that is, the <see cref="CloudPool.AutoScaleEnabled"/> property of the pool is true).
        /// If you decrease the pool size, the Batch service chooses which nodes to remove.  To remove specific nodes, call <see cref="RemoveFromPoolAsync(IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.
        /// </para>
        /// <para>The resize operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task ResizeAsync(
            int? targetDedicatedComputeNodes = null,
            int? targetLowPriorityComputeNodes = null,
            TimeSpan? resizeTimeout = null,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.ResizePoolAsyncImpl(
                this.Id,
                targetDedicatedComputeNodes,
                targetLowPriorityComputeNodes,
                resizeTimeout,
                deallocationOption,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }


        /// <summary>
        /// Resizes this pool.
        /// </summary>
        /// <param name="targetDedicatedComputeNodes">
        /// The desired number of dedicated compute nodes in the pool.
        /// At least one of <paramref name="targetDedicatedComputeNodes"/> and <paramref name="targetLowPriorityComputeNodes"/> is required.
        /// </param>
        /// <param name="targetLowPriorityComputeNodes">
        /// The desired number of low-priority compute nodes in the pool.
        /// At least one of <paramref name="targetDedicatedComputeNodes"/> and <paramref name="targetLowPriorityComputeNodes"/> is required.
        /// </param>
        /// <param name="resizeTimeout">The timeout for allocation of compute nodes to the pool or removal of compute nodes from the pool. If the pool has not reached the target size after this time, the resize is stopped. The default is 15 minutes.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool, if the pool size is decreasing. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The resize operation requests that the pool be resized.  The request puts the pool in the <see cref="Common.AllocationState.Resizing"/> allocation state.
        /// The Batch service will perform the actual resize without any further client action, and set the allocation state to <see cref="Common.AllocationState.Steady"/> once complete.</para>
        /// <para>
        /// You can only resize a pool when its <see cref="CloudPool.AllocationState"/> is <see cref="Common.AllocationState.Steady"/>.
        /// You cannot resize pools which are configured for automatic scaling (that is, the <see cref="CloudPool.AutoScaleEnabled"/> property of the pool is true).
        /// If you decrease the pool size, the Batch service chooses which nodes to remove.  To remove specific nodes, call <see cref="RemoveFromPool(IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior})"/>.
        /// </para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="ResizeAsync"/>.</para>
        /// </remarks>
        public void Resize(
            int? targetDedicatedComputeNodes = null,
            int? targetLowPriorityComputeNodes = null,
            TimeSpan? resizeTimeout = null,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = ResizeAsync(targetDedicatedComputeNodes, targetLowPriorityComputeNodes, resizeTimeout, deallocationOption, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }


        /// <summary>
        /// Stops a resize operation on this pool.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// This operation stops an ongoing resize operation on the pool.  The pool size will stabilize at the number of nodes it is at
        /// when the stop operation is done.  During the stop operation, the pool <see cref="CloudPool.AllocationState"/> changes first
        /// to <see cref="Common.AllocationState.Stopping"/> and then to <see cref="Common.AllocationState.Steady"/>.
        /// </para>
        /// <para>The stop resize operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task StopResizeAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.StopResizePoolAsyncImpl(this.Id, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Stops a resize operation on this pool.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// This operation stops an ongoing resize operation on the pool.  The pool size will stabilize at the number of nodes it is at
        /// when the stop operation is done.  During the stop operation, the pool <see cref="CloudPool.AllocationState"/> changes first
        /// to <see cref="Common.AllocationState.Stopping"/> and then to <see cref="Common.AllocationState.Steady"/>.
        /// </para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="StopResizeAsync"/>.</para>
        /// </remarks>
        public void StopResize(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = StopResizeAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Enumerates the <see cref="ComputeNode">compute nodes</see> of this pool.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{ComputeNode}"/> that can be used to enumerate compute nodes asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the nodes are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; nodes are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<ComputeNode> ListComputeNodes(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<ComputeNode> computeNodeList = this.parentBatchClient.PoolOperations.ListComputeNodesImpl(this.Id, bhMgr, detailLevel);
            return computeNodeList;
        }

        /// <summary>
        /// Gets the specified compute node from this pool.
        /// </summary>
        /// <param name="computeNodeId">The id of the compute node to get from the pool.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="ComputeNode"/> containing information about the specified compute node.</returns>
        /// <remarks>The get node operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task<ComputeNode> GetComputeNodeAsync(
            string computeNodeId, 
            DetailLevel detailLevel = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<ComputeNode> asyncTask = this.parentBatchClient.PoolOperations.GetComputeNodeAsyncImpl(this.Id, computeNodeId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets the specified compute node from this pool.
        /// </summary>
        /// <param name="computeNodeId">The id of the compute node to get from the pool.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="ComputeNode"/> containing information about the specified compute node.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetComputeNodeAsync"/>.</remarks>
        public ComputeNode GetComputeNode(string computeNodeId, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<ComputeNode> asyncTask = GetComputeNodeAsync(computeNodeId, detailLevel, additionalBehaviors);

            ComputeNode result = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            return result;
        }

        /// <summary>
        /// Enables automatic scaling on this pool.
        /// </summary>
        /// <param name="autoscaleFormula">The formula for the desired number of compute nodes in the pool.</param>
        /// <param name="autoscaleEvaluationInterval">The time interval at which to automatically adjust the pool size according to the AutoScale formula. The default value is 15 minutes. The minimum allowed value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The formula is checked for validity before it is applied to the pool. If the formula is not valid, an exception occurs.</para>
        /// <para>You cannot enable automatic scaling on a pool if a resize operation is in progress on the pool.</para>
        /// <para>The enable autoscale operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task EnableAutoScaleAsync(
            string autoscaleFormula = null,
            TimeSpan? autoscaleEvaluationInterval = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.EnableAutoScaleAsyncImpl(this.Id, autoscaleFormula, autoscaleEvaluationInterval, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Enables automatic scaling on this pool.
        /// </summary>
        /// <param name="autoscaleFormula">The formula for the desired number of compute nodes in the pool.</param>
        /// <param name="autoscaleEvaluationInterval">The time interval at which to automatically adjust the pool size according to the AutoScale formula. The default value is 15 minutes. The minimum allowed value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The formula is checked for validity before it is applied to the pool. If the formula is not valid, an exception occurs.</para>
        /// <para>You cannot enable automatic scaling on a pool if a resize operation is in progress on the pool.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableAutoScaleAsync"/>.</para>
        /// </remarks>
        public void EnableAutoScale(
            string autoscaleFormula = null,
            TimeSpan? autoscaleEvaluationInterval = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = EnableAutoScaleAsync(autoscaleFormula, autoscaleEvaluationInterval, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Disables automatic scaling on this pool.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The disable autoscale operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task DisableAutoScaleAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.DisableAutoScaleAsyncImpl(this.Id, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Disables automatic scaling on this pool.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableAutoScaleAsync"/>.</para>
        /// </remarks>
        public void DisableAutoScale(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DisableAutoScaleAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Gets the result of evaluating an automatic scaling formula on this pool.  This 
        /// is primarily for validating an autoscale formula, as it simply returns the result
        /// without applying the formula to the pool.
        /// </summary>
        /// <param name="autoscaleFormula">The formula to be evaluated on the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>The result of evaluating the <paramref name="autoscaleFormula"/> on this pool.</returns>
        /// <remarks>
        /// <para>The formula is validated and its results calculated, but is not applied to the pool.  To apply the formula to the pool, use <see cref="EnableAutoScaleAsync"/>.</para>
        /// <para>This method does not change any state of the pool, and does not affect the <see cref="CloudPool.LastModified"/> or <see cref="CloudPool.ETag"/>.</para>
        /// <para>The evaluate operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task<AutoScaleRun> EvaluateAutoScaleAsync(
            string autoscaleFormula, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task<AutoScaleRun> asyncTask = this.parentBatchClient.PoolOperations.EvaluateAutoScaleAsyncImpl(this.Id, autoscaleFormula, bhMgr, cancellationToken);

            return await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Gets the result of evaluating an automatic scaling formula on this pool.  This 
        /// is primarily for validating an autoscale formula, as it simply returns the result
        /// without applying the formula to the pool.
        /// </summary>
        /// <param name="autoscaleFormula">The formula to be evaluated on the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>The result of evaluating the <paramref name="autoscaleFormula"/> on this pool.</returns>
        /// <remarks>
        /// <para>The formula is validated and its results calculated, but is not applied to the pool.  To apply the formula to the pool, use <see cref="EnableAutoScale"/>.</para>
        /// <para>This method does not change any state of the pool, and does not affect the <see cref="CloudPool.LastModified"/> or <see cref="CloudPool.ETag"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="EvaluateAutoScaleAsync"/>.</para>
        /// </remarks>
        public AutoScaleRun EvaluateAutoScale(string autoscaleFormula, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<AutoScaleRun> asyncTask = EvaluateAutoScaleAsync(autoscaleFormula, additionalBehaviors);
            AutoScaleRun autoScaleRun = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

            return autoScaleRun;
        }

        /// <summary>
        /// Removes the specified compute node from this pool.
        /// </summary>
        /// <param name="computeNodeId">The id of the compute node to remove from the pool.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If you need to remove multiple compute nodes from a pool, it is more efficient to use the <see cref="RemoveFromPoolAsync(IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/> overload.</para>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's <see cref="CloudPool.AllocationState"/> changes from <see cref="Common.AllocationState.Steady"/> to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>The remove operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task RemoveFromPoolAsync(
            string computeNodeId,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.RemoveFromPoolAsyncImpl(this.Id, new List<string> { computeNodeId }, deallocationOption, resizeTimeout, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Removes the specified compute node from this pool.
        /// </summary>
        /// <param name="computeNodeId">The id of the compute node to remove from the pool.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>If you need to remove multiple compute nodes from a pool, it is more efficient to use the <see cref="RemoveFromPool(IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior})"/> overload.</para>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's <see cref="CloudPool.AllocationState"/> changes from <see cref="Common.AllocationState.Steady"/> to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RemoveFromPoolAsync(string, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// </remarks>
        public void RemoveFromPool(
            string computeNodeId,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RemoveFromPoolAsync(computeNodeId, deallocationOption, resizeTimeout, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Removes the specified compute nodes from this pool.
        /// </summary>
        /// <param name="computeNodeIds">The ids of the compute nodes to remove from the pool.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's <see cref="CloudPool.AllocationState"/> changes from <see cref="Common.AllocationState.Steady"/> to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>The remove operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task RemoveFromPoolAsync(
            IEnumerable<string> computeNodeIds,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.RemoveFromPoolAsyncImpl(this.Id, computeNodeIds, deallocationOption, resizeTimeout, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Removes the specified compute nodes from this pool.
        /// </summary>
        /// <param name="computeNodeIds">The ids of the compute nodes to remove from the pool.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's <see cref="CloudPool.AllocationState"/> changes from <see cref="Common.AllocationState.Steady"/> to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RemoveFromPoolAsync(IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// </remarks>
        public void RemoveFromPool(
            IEnumerable<string> computeNodeIds,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RemoveFromPoolAsync(computeNodeIds, deallocationOption, resizeTimeout, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Removes the specified compute node from this pool.
        /// </summary>
        /// <param name="computeNode">The <see cref="ComputeNode"/> to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If you need to remove multiple compute nodes from a pool, it is more efficient to use the <see cref="RemoveFromPoolAsync(IEnumerable{ComputeNode}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/> overload.</para>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's <see cref="CloudPool.AllocationState"/> changes from <see cref="Common.AllocationState.Steady"/> to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>The remove operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task RemoveFromPoolAsync(
            ComputeNode computeNode,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.RemoveFromPoolAsyncImpl(
                this.Id, 
                new List<ComputeNode> { computeNode }, 
                deallocationOption, 
                resizeTimeout, 
                bhMgr,
                cancellationToken);
            
            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Removes the specified compute node from this pool.
        /// </summary>
        /// <param name="computeNode">The <see cref="ComputeNode"/> to remove from the pool.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>If you need to remove multiple compute nodes from a pool, it is more efficient to use the <see cref="RemoveFromPool(IEnumerable{ComputeNode}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior})"/> overload.</para>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's <see cref="CloudPool.AllocationState"/> changes from <see cref="Common.AllocationState.Steady"/> to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RemoveFromPoolAsync(ComputeNode, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// </remarks>
        public void RemoveFromPool(
            ComputeNode computeNode,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RemoveFromPoolAsync(computeNode, deallocationOption, resizeTimeout, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Removes the specified compute nodes from this pool.
        /// </summary>
        /// <param name="computeNodes">The <see cref="ComputeNode">compute nodes</see> to remove from the pool.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's <see cref="CloudPool.AllocationState"/> changes from <see cref="Common.AllocationState.Steady"/> to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>The remove operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task RemoveFromPoolAsync(
            IEnumerable<ComputeNode> computeNodes,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.RemoveFromPoolAsyncImpl(this.Id, computeNodes, deallocationOption, resizeTimeout, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }


        /// <summary>
        /// Removes the specified compute nodes from this pool.
        /// </summary>
        /// <param name="computeNodes">The <see cref="ComputeNode">compute nodes</see> to remove from the pool.</param>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's <see cref="CloudPool.AllocationState"/> changes from <see cref="Common.AllocationState.Steady"/> to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RemoveFromPoolAsync(IEnumerable{ComputeNode}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// </remarks>
        public void RemoveFromPool(
            IEnumerable<ComputeNode> computeNodes,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {

            Task asyncTask = RemoveFromPoolAsync(computeNodes, deallocationOption, resizeTimeout, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        #endregion CloudPool

        #region IRefreshable

        /// <summary>
        /// Refreshes the current <see cref="CloudPool"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the asynchronous refresh operation.</returns>
        public async System.Threading.Tasks.Task RefreshAsync(
            DetailLevel detailLevel = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>> asyncTask = this.parentBatchClient.ProtocolLayer.GetPool(
                this.Id,
                bhMgr,
                cancellationToken);

            AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // get pool from response
            Models.CloudPool newProtocolPool = response.Body;

            PropertyContainer newContainer = new PropertyContainer(newProtocolPool);
            this.propertyContainer = newContainer;
        }

        /// <summary>
        /// Refreshes the current <see cref="CloudPool"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }


        #endregion Irefreshable


    }
}
