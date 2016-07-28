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
using System.Threading;
using System.IO;
using Common = Microsoft.Azure.Batch.Common;

namespace Microsoft.Azure.Batch
{
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Performs pool-related operations on an Azure Batch account.
    /// </summary>
    public class PoolOperations : IInheritedBehaviors
    {
        private readonly BatchClient _parentBatchClient;

        #region // constructors

        private PoolOperations()
        {
        }

        internal PoolOperations(BatchClient parentBC, IEnumerable<BatchClientBehavior> inheritedBehaviors)
        {
            _parentBatchClient = parentBC;

            // implement inheritance of behaviors
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, inheritedBehaviors);
        }

#endregion // constructors

#region // internal properties/methods

        internal BatchClient ParentBatchClient
        {
            get { return _parentBatchClient; }
        }

#endregion // internal properties/methods

#region IInheritedBehaviors

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service
        /// made via this <see cref="PoolOperations"/>.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors { get; set; }

#endregion  IInheeritedBehaviors

#region // PoolOperations

        /// <summary>
        /// Enumerates the <see cref="CloudPool">pools</see> in the Batch account.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{CloudPool}"/> that can be used to enumerate pools asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the pools are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; pools are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<CloudPool> ListPools(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            PagedEnumerable<CloudPool> enumerable = new PagedEnumerable<CloudPool>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListPoolsEnumerator typedEnumerator = new AsyncListPoolsEnumerator(this, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<CloudPool> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudPool"/>.
        /// </summary>
        /// <param name="poolId">The id of the pool to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="CloudPool"/> containing information about the specified Azure Batch pool.</returns>
        /// <remarks>The get pool operation runs asynchronously.</remarks>
        public async System.Threading.Tasks.Task<CloudPool> GetPoolAsync(
            string poolId,
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            // start call to server
            System.Threading.Tasks.Task<AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>> asyncTask =
                this.ParentBatchClient.ProtocolLayer.GetPool(poolId, bhMgr, cancellationToken);

            AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // construct object model Pool
            CloudPool bcPool = new CloudPool(this.ParentBatchClient, response.Body, this.CustomBehaviors);

            return bcPool;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudPool"/>.
        /// </summary>
        /// <param name="poolId">The id of the pool to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>A <see cref="CloudPool"/> containing information about the specified Azure Batch pool.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetPoolAsync"/>.</remarks>
        public CloudPool GetPool(
            string poolId,
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<CloudPool> asyncTask = GetPoolAsync(poolId, detailLevel, additionalBehaviors))
            {
                return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal async System.Threading.Tasks.Task DeletePoolAsyncImpl(string poolIdToDelete, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            System.Threading.Tasks.Task<AzureOperationHeaderResponse<Models.PoolDeleteHeaders>> asyncTask = _parentBatchClient.ProtocolLayer.DeletePool(poolIdToDelete, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool to delete.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the pool be deleted.  The request puts the pool in the <see cref="Common.PoolState.Deleting"/> state.
        /// The Batch service will requeue any running tasks and perform the actual pool deletion without any further client action.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task DeletePoolAsync(
            string poolId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = DeletePoolAsyncImpl(poolId, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool to delete.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The delete operation requests that the pool be deleted.  The request puts the pool in the <see cref="Common.PoolState.Deleting"/> state.
        /// The Batch service will requeue any running tasks and perform the actual pool deletion without any further client action.</para>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeletePoolAsync"/>.</remarks>
        /// </remarks>
        public void DeletePool(string poolId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = DeletePoolAsync(poolId, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Creates an instance of CloudPool that is unbound and does not have a consistency relationship to any pool in the Batch service.
        /// </summary>
        /// <returns>A <see cref="CloudPool"/> representing a new pool that has not been added to the Batch service.
        /// To add the pool to the Batch account, call <see cref="CloudPool.CommitAsync"/>.</returns>
        public CloudPool CreatePool()
        {
            CloudPool unboundPool = new CloudPool(this.ParentBatchClient, this.CustomBehaviors);

            return unboundPool;
        }

        /// <summary>
        /// Creates an instance of CloudPool that is unbound and does not have a consistency relationship to any pool in the Batch service.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="virtualMachineSize">The size of virtual machines in the pool.  See https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-size-specs/ for sizes.</param>
        /// <param name="cloudServiceConfiguration">The <see cref="CloudServiceConfiguration"/> for the pool.</param>
        /// <param name="targetDedicated">The desired number of compute nodes in the pool. If omitted, you must set the <see cref="CloudPool.AutoScaleEnabled"/> property.</param>
        /// <returns>A <see cref="CloudPool"/> representing a new pool that has not been added to the Batch service.
        /// To add the pool to the Batch account, call <see cref="CloudPool.CommitAsync"/>.</returns>
        /// <remarks>
        /// <para>For information about Azure Guest OS families, see https://azure.microsoft.com/documentation/articles/cloud-services-guestos-update-matrix/ </para>
        /// <para>For information about available sizes of virtual machines, see https://azure.microsoft.com/documentation/articles/cloud-services-sizes-specs/.
        /// Batch supports all Azure cloud service VM sizes except ExtraSmall.</para>
        /// </remarks>
        public CloudPool CreatePool(
            string poolId,
            string virtualMachineSize,
            CloudServiceConfiguration cloudServiceConfiguration,
            int? targetDedicated = null)
        {
            CloudPool unboundPool = new CloudPool(this.ParentBatchClient, this.CustomBehaviors)
                                    {
                                        CloudServiceConfiguration = cloudServiceConfiguration,
                                        Id = poolId,
                                        VirtualMachineSize = virtualMachineSize,
                                        TargetDedicated = targetDedicated
                                    };

            return unboundPool;
        }

        /// <summary>
        /// Creates an instance of CloudPool that is unbound and does not have a consistency relationship to any pool in the Batch service.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="virtualMachineSize">The size of virtual machines in the pool.  See https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-size-specs/ for sizes.</param>
        /// <param name="virtualMachineConfiguration">The <see cref="VirtualMachineConfiguration"/> for the pool.</param>
        /// <param name="targetDedicated">The desired number of compute nodes in the pool. If omitted, you must set the <see cref="CloudPool.AutoScaleEnabled"/> property.</param>
        /// <returns>A <see cref="CloudPool"/> representing a new pool that has not been added to the Batch service.
        /// To add the pool to the Batch account, call <see cref="CloudPool.CommitAsync"/>.</returns>
        public CloudPool CreatePool(
            string poolId,
            string virtualMachineSize,
            VirtualMachineConfiguration virtualMachineConfiguration,
            int? targetDedicated = null)
        {
            CloudPool unboundPool = new CloudPool(this.ParentBatchClient, this.CustomBehaviors)
                {
                    Id = poolId,
                    VirtualMachineConfiguration = virtualMachineConfiguration,
                    VirtualMachineSize = virtualMachineSize,
                    TargetDedicated = targetDedicated
                };

            return unboundPool;
        }

        internal System.Threading.Tasks.Task ResizePoolAsyncImpl(
            string poolId,
            int targetDedicated,
            TimeSpan? resizeTimeout,
            Common.ComputeNodeDeallocationOption? deallocationOption,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.ResizePool(
                poolId,
                targetDedicated,
                resizeTimeout,
                deallocationOption,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Resizes the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="targetDedicated">The desired number of compute nodes in the pool.</param>
        /// <param name="resizeTimeout">The timeout for allocation of compute nodes to the pool or removal of compute nodes from the pool. If the pool has not reached the target size after this time, the resize is stopped. The default is 15 minutes.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool, if the pool size is decreasing. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The resize operation requests that the pool be resized.  The request puts the pool in the <see cref="Common.AllocationState.Resizing"/> allocation state.
        /// The Batch service will perform the actual resize without any further client action, and set the allocation state to <see cref="Common.AllocationState.Steady"/> once complete.</para>
        /// <para>
        /// You can only resize a pool when its <see cref="CloudPool.AllocationState"/> is <see cref="Common.AllocationState.Steady"/>.
        /// You cannot resize pools which are configured for automatic scaling (that is, the <see cref="CloudPool.AutoScaleEnabled"/> property of the pool is true).
        /// If you decrease the pool size, the Batch service chooses which nodes to remove.  To remove specific nodes, call <see cref="PoolOperations.RemoveFromPoolAsync(string, IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.
        /// </para>
        /// <para>The resize operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task ResizePoolAsync(
            string poolId,
            int targetDedicated,
            TimeSpan? resizeTimeout = null,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = ResizePoolAsyncImpl(
                poolId,
                targetDedicated,
                resizeTimeout,
                deallocationOption,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }


        /// <summary>
        /// Resizes the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="targetDedicated">The desired number of compute nodes in the pool.</param>
        /// <param name="resizeTimeout">The timeout for allocation of compute nodes to the pool or removal of compute nodes from the pool. If the pool has not reached the target size after this time, the resize is stopped. The default is 15 minutes.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool, if the pool size is decreasing. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The resize operation requests that the pool be resized.  The request puts the pool in the <see cref="Common.AllocationState.Resizing"/> allocation state.
        /// The Batch service will perform the actual resize without any further client action, and set the allocation state to <see cref="Common.AllocationState.Steady"/> once complete.</para>
        /// <para>
        /// You can only resize a pool when its <see cref="CloudPool.AllocationState"/> is <see cref="Common.AllocationState.Steady"/>.
        /// You cannot resize pools which are configured for automatic scaling (that is, the <see cref="CloudPool.AutoScaleEnabled"/> property of the pool is true).
        /// If you decrease the pool size, the Batch service chooses which nodes to remove.  To remove specific nodes, call <see cref="PoolOperations.RemoveFromPool(string, IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior})"/>.
        /// </para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="ResizePoolAsync"/>.</para>
        /// </remarks>
        public void ResizePool(
            string poolId,
            int targetDedicated,
            TimeSpan? resizeTimeout = null,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = ResizePoolAsync(poolId, targetDedicated, resizeTimeout, deallocationOption, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal System.Threading.Tasks.Task StopResizePoolAsyncImpl(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.StopResizePool(poolId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Stops a pool resize operation.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
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
        public System.Threading.Tasks.Task StopResizePoolAsync(
            string poolId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = StopResizePoolAsyncImpl(poolId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Stops a pool resize operation.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// This operation stops an ongoing resize operation on the pool.  The pool size will stabilize at the number of nodes it is at
        /// when the stop operation is done.  During the stop operation, the pool <see cref="CloudPool.AllocationState"/> changes first
        /// to <see cref="Common.AllocationState.Stopping"/> and then to <see cref="Common.AllocationState.Steady"/>.
        /// </para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="StopResizePoolAsync"/>.</para>
        /// </remarks>
        public void StopResizePool(string poolId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = StopResizePoolAsync(poolId, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }


        internal IPagedEnumerable<ComputeNode> ListComputeNodesImpl(string poolId, BehaviorManager bhMgr, DetailLevel detailLevel)
        {
            PagedEnumerable<ComputeNode> enumerable = new PagedEnumerable<ComputeNode>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListComputeNodesEnumerator typedEnumerator = new AsyncListComputeNodesEnumerator(
                        this,
                        poolId,
                        bhMgr,
                        detailLevel);

                    // here is the base

                    PagedEnumeratorBase<ComputeNode> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Enumerates the <see cref="ComputeNode">compute nodes</see> of the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{ComputeNode}"/> that can be used to enumerate compute nodes asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the nodes are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; nodes are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<ComputeNode> ListComputeNodes(string poolId, DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            // get enumerable
            IPagedEnumerable<ComputeNode> enumerable = ListComputeNodesImpl(poolId, bhMgr, detailLevel);

            return enumerable;
        }


        internal async System.Threading.Tasks.Task<ComputeNode> GetComputeNodeAsyncImpl(
            string poolId,
            string computeNodeId, 
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            using (System.Threading.Tasks.Task<AzureOperationResponse<Models.ComputeNode, Models.ComputeNodeGetHeaders>> asyncTask = 
                this.ParentBatchClient.ProtocolLayer.GetComputeNode(poolId, computeNodeId, bhMgr, cancellationToken))
            {
                AzureOperationResponse<Models.ComputeNode, Models.ComputeNodeGetHeaders> result = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                // construct a new object bound to the protocol layer object
                ComputeNode newComputeNode = new ComputeNode(this.ParentBatchClient, poolId, result.Body, bhMgr.BaseBehaviors);

                return newComputeNode;
            }
        }

        /// <summary>
        /// Gets the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeId">The id of the compute node to get from the pool.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="ComputeNode"/> containing information about the specified compute node.</returns>
        /// <remarks>The get node operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task<ComputeNode> GetComputeNodeAsync(
            string poolId, 
            string computeNodeId,
            DetailLevel detailLevel = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<ComputeNode> asyncTask = GetComputeNodeAsyncImpl(poolId, computeNodeId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeId">The id of the compute node to get from the pool.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="ComputeNode"/> containing information about the specified compute node.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetComputeNodeAsync"/>.</remarks>
        public ComputeNode GetComputeNode(
            string poolId, 
            string computeNodeId, 
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<ComputeNode> asyncTask = GetComputeNodeAsync(poolId, computeNodeId, detailLevel, additionalBehaviors))
            {
                return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Enables task scheduling on the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>This operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task EnableComputeNodeSchedulingAsync(
            string poolId, 
            string computeNodeId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.ParentBatchClient.ProtocolLayer.EnableComputeNodeScheduling(poolId, computeNodeId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Enables task scheduling on the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableComputeNodeScheduling"/>.</remarks>
        public void EnableComputeNodeScheduling(
            string poolId, 
            string computeNodeId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = EnableComputeNodeSchedulingAsync(poolId, computeNodeId, additionalBehaviors, CancellationToken.None))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Disables task scheduling on the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="disableComputeNodeSchedulingOption">Specifies what to do with currently running tasks. The default is <see cref="Common.DisableComputeNodeSchedulingOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>This operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task DisableComputeNodeSchedulingAsync(
            string poolId,
            string computeNodeId,
            Common.DisableComputeNodeSchedulingOption? disableComputeNodeSchedulingOption,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.ParentBatchClient.ProtocolLayer.DisableComputeNodeScheduling(poolId, computeNodeId, disableComputeNodeSchedulingOption, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Disables task scheduling on the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="disableComputeNodeSchedulingOption">Specifies what to do with currently running tasks. The default is <see cref="Common.DisableComputeNodeSchedulingOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableComputeNodeSchedulingAsync"/>.</remarks>
        public void DisableComputeNodeScheduling(
            string poolId,
            string computeNodeId,
            Common.DisableComputeNodeSchedulingOption? disableComputeNodeSchedulingOption,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = DisableComputeNodeSchedulingAsync(poolId, computeNodeId, disableComputeNodeSchedulingOption, additionalBehaviors, CancellationToken.None))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal async System.Threading.Tasks.Task EnableAutoScaleAsyncImpl(
            string poolId, 
            string autoscaleFormula,
            TimeSpan? autoscaleEvaluationInterval,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            // start call
            System.Threading.Tasks.Task asyncTask = this.ParentBatchClient.ProtocolLayer.EnableAutoScale(
                poolId,
                autoscaleFormula,
                autoscaleEvaluationInterval,
                bhMgr,
                cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Enables automatic scaling on the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
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
            string poolId, 
            string autoscaleFormula = null,
            TimeSpan? autoscaleEvaluationInterval = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // start call
            System.Threading.Tasks.Task asyncTask = EnableAutoScaleAsyncImpl(poolId, autoscaleFormula, autoscaleEvaluationInterval, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Enables automatic scaling on the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="autoscaleFormula">The formula for the desired number of compute nodes in the pool.</param>
        /// <param name="autoscaleEvaluationInterval">The time interval at which to automatically adjust the pool size according to the AutoScale formula. The default value is 15 minutes. The minimum allowed value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The formula is checked for validity before it is applied to the pool. If the formula is not valid, an exception occurs.</para>
        /// <para>You cannot enable automatic scaling on a pool if a resize operation is in progress on the pool.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableAutoScaleAsync"/>.</para>
        /// </remarks>
        public void EnableAutoScale(
            string poolId, 
            string autoscaleFormula = null,
            TimeSpan? autoscaleEvaluationInterval = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = EnableAutoScaleAsync(poolId, autoscaleFormula, autoscaleEvaluationInterval, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal async System.Threading.Tasks.Task DisableAutoScaleAsyncImpl(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            // start call
            System.Threading.Tasks.Task asyncTask = this.ParentBatchClient.ProtocolLayer.DisableAutoScale(poolId, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Disables automatic scaling on the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The disable autoscale operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task DisableAutoScaleAsync(
            string poolId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // start call
            System.Threading.Tasks.Task asyncTask = DisableAutoScaleAsyncImpl(poolId, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }


        /// <summary>
        /// Disables automatic scaling on the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableAutoScaleAsync"/>.</para>
        /// </remarks>
        public void DisableAutoScale(string poolId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = DisableAutoScaleAsync(poolId, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal async System.Threading.Tasks.Task<AutoScaleRun> EvaluateAutoScaleAsyncImpl(
            string poolId,
            string autoscaleFormula,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            // start call
            System.Threading.Tasks.Task<AzureOperationResponse<Models.AutoScaleRun, Models.PoolEvaluateAutoScaleHeaders>> asyncTask =
                this._parentBatchClient.ProtocolLayer.EvaluateAutoScale(poolId, autoscaleFormula, bhMgr, cancellationToken);

            var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
            
            return new AutoScaleRun(response.Body);
        }

        /// <summary>
        /// Gets the result of evaluating an automatic scaling formula on the specified pool.  This 
        /// is primarily for validating an autoscale formula, as it simply returns the result
        /// without applying the formula to the pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="autoscaleFormula">The formula to be evaluated on the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>The result of evaluating the <paramref name="autoscaleFormula"/> on the specified pool.</returns>
        /// <remarks>
        /// <para>The formula is validated and its results calculated, but is not applied to the pool.  To apply the formula to the pool, use <see cref="EnableAutoScaleAsync"/>.</para>
        /// <para>This method does not change any state of the pool, and does not affect the <see cref="CloudPool.LastModified"/> or <see cref="CloudPool.ETag"/>.</para>
        /// <para>The evaluate operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task<AutoScaleRun> EvaluateAutoScaleAsync(
            string poolId,
            string autoscaleFormula,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // start call
            System.Threading.Tasks.Task<AutoScaleRun> asyncTask = EvaluateAutoScaleAsyncImpl(
                poolId,
                autoscaleFormula, 
                bhMgr,
                cancellationToken);

            AutoScaleRun evaluation = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            return evaluation;
        }

        /// <summary>
        /// Gets the result of evaluating an automatic scaling formula on the specified pool.  This 
        /// is primarily for validating an autoscale formula, as it simply returns the result
        /// without applying the formula to the pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="autoscaleFormula">The formula to be evaluated on the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>The result of evaluating the <paramref name="autoscaleFormula"/> on the specified pool.</returns>
        /// <remarks>
        /// <para>The formula is validated and its results calculated, but is not applied to the pool.  To apply the formula to the pool, use <see cref="EnableAutoScale"/>.</para>
        /// <para>This method does not change any state of the pool, and does not affect the <see cref="CloudPool.LastModified"/> or <see cref="CloudPool.ETag"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="EvaluateAutoScaleAsync"/>.</para>
        /// </remarks>
        public AutoScaleRun EvaluateAutoScale(
            string poolId,
            string autoscaleFormula,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<AutoScaleRun> asyncTask = EvaluateAutoScaleAsync(poolId, autoscaleFormula, additionalBehaviors))
            {
                return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Removes the specified compute node from the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeId">The id of the compute node to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If you need to remove multiple compute nodes from a pool, it is more efficient to use the <see cref="RemoveFromPoolAsync(string, IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/> overload.</para>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's AllocationState changes from Steady to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>The remove operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task RemoveFromPoolAsync(
            string poolId,
            string computeNodeId,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            //Create a dummy compute node id list with just one element
            List<string> computeNodeIdList = new List<string> {computeNodeId};

            System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsync(poolId, computeNodeIdList, deallocationOption,
                resizeTimeout, additionalBehaviors);

            return asyncTask;
        }

        /// <summary>
        /// Removes the specified compute node from the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeId">The id of the compute node to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>If you need to remove multiple compute nodes from a pool, it is more efficient to use the <see cref="RemoveFromPool(string, IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior})"/> overload.</para>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's AllocationState changes from Steady to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RemoveFromPoolAsync(string, string, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior})"/>.</para>
        /// </remarks>
        public void RemoveFromPool(
            string poolId,
            string computeNodeId,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsync(poolId, computeNodeId, deallocationOption,resizeTimeout, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal System.Threading.Tasks.Task RemoveFromPoolAsyncImpl(
            string poolId,
            IEnumerable<string> computeNodeIds,
            Common.ComputeNodeDeallocationOption? deallocationOption,
            TimeSpan? resizeTimeout,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            // start call
            System.Threading.Tasks.Task asyncTask = this._parentBatchClient.ProtocolLayer.RemovePoolComputeNodes(
                poolId, 
                computeNodeIds, 
                deallocationOption, 
                resizeTimeout, 
                bhMgr, 
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Removes the specified compute nodes from the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeIds">The ids of the compute nodes to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's AllocationState changes from Steady to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>The remove operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task RemoveFromPoolAsync(
            string poolId,
            IEnumerable<string> computeNodeIds,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // start call
            System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsyncImpl(
                poolId, 
                computeNodeIds, 
                deallocationOption,
                resizeTimeout, 
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Removes the specified compute nodes from the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodeIds">The ids of the compute nodes to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's AllocationState changes from Steady to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RemoveFromPoolAsync(string, IEnumerable{string}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// </remarks>
        public void RemoveFromPool(
            string poolId,
            IEnumerable<string> computeNodeIds,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsync(poolId, computeNodeIds, deallocationOption, resizeTimeout, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Removes the specified compute node from the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNode">The <see cref="ComputeNode"/> to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If you need to remove multiple compute nodes from a pool, it is more efficient to use the <see cref="RemoveFromPoolAsync(string, IEnumerable{ComputeNode}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/> overload.</para>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's AllocationState changes from Steady to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>The remove operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task RemoveFromPoolAsync(
            string poolId,
            ComputeNode computeNode,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            //Create a dummy ComputeNode list with just one element
            List<ComputeNode> computeNodeList = new List<ComputeNode> {computeNode};

            System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsync(poolId, computeNodeList, deallocationOption,
                resizeTimeout, additionalBehaviors);

            return asyncTask;
        }

        /// <summary>
        /// Removes the specified compute node from the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNode">The <see cref="ComputeNode"/> to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>If you need to remove multiple compute nodes from a pool, it is more efficient to use the <see cref="RemoveFromPool(string, IEnumerable{ComputeNode}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior})"/> overload.</para>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's AllocationState changes from Steady to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RemoveFromPoolAsync(string, ComputeNode, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior})"/>.</para>
        /// </remarks>
        public void RemoveFromPool(
            string poolId,
            ComputeNode computeNode,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsync(poolId, computeNode, deallocationOption, resizeTimeout, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal System.Threading.Tasks.Task RemoveFromPoolAsyncImpl(
            string poolId,
            IEnumerable<ComputeNode> computeNodes,
            Common.ComputeNodeDeallocationOption? deallocationOption,
            TimeSpan? resizeTimeout,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            // Process the list of compute nodes to ensure that they have names
            List<string> computeNodeIds = new List<string>();
            foreach (ComputeNode computeNode in computeNodes)
            {
                computeNodeIds.Add(computeNode.Id);
            }

            // start call
            System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsyncImpl(
                poolId, 
                computeNodeIds, 
                deallocationOption,
                resizeTimeout, 
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Removes the specified compute nodes from the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodes">The <see cref="ComputeNode">compute nodes</see> to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's AllocationState changes from Steady to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>The remove operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task RemoveFromPoolAsync(
            string poolId,
            IEnumerable<ComputeNode> computeNodes,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // start call
            System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsyncImpl(
                poolId, 
                computeNodes, 
                deallocationOption,
                resizeTimeout, 
                bhMgr,
                cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Removes the specified compute nodes from the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="computeNodes">The <see cref="ComputeNode">compute nodes</see> to remove from the pool.</param>
        /// <param name="deallocationOption">Specifies when nodes may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.</param>
        /// <param name="resizeTimeout">Specifies the timeout for removal of compute nodes from the pool. The default value is 15 minutes. The minimum value is 5 minutes.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>You can only remove nodes from a pool when the <see cref="CloudPool.AllocationState"/> of the pool is <see cref="Common.AllocationState.Steady"/>. If the pool is already resizing, an exception occurs.</para>
        /// <para>When you remove nodes from a pool, the pool's AllocationState changes from Steady to <see cref="Common.AllocationState.Resizing"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RemoveFromPoolAsync(string, IEnumerable{ComputeNode}, Common.ComputeNodeDeallocationOption?, TimeSpan?, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// </remarks>
        public void RemoveFromPool(
            string poolId,
            IEnumerable<ComputeNode> computeNodes,
            Common.ComputeNodeDeallocationOption? deallocationOption = null,
            TimeSpan? resizeTimeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = RemoveFromPoolAsync(poolId, computeNodes, deallocationOption, resizeTimeout, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Creates a <see cref="ComputeNodeUser"/> representing a new compute node user account that
        /// does not yet exist in the Batch service.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node where the user account will be created.</param>
        /// <returns>An unbound <see cref="ComputeNodeUser"/> representing a new user account that has not been added to the compute node.</returns>
        /// <remarks>To add the new user, call <see cref="ComputeNodeUser.CommitAsync"/>.</remarks>
        public ComputeNodeUser CreateComputeNodeUser(string poolId, string computeNodeId)
        {
            ComputeNodeUser newUser = new ComputeNodeUser(this.ParentBatchClient, this.CustomBehaviors, poolId, computeNodeId);

            return newUser;
        }

        /// <summary>
        /// Deletes the specified user account from the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node from which you want to delete the user account.</param>
        /// <param name="userName">The name of the user account to be deleted.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>You can delete a user account from a compute node only when it is in the <see cref="Common.ComputeNodeState.Idle"/> or <see cref="Common.ComputeNodeState.Running"/> state.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task DeleteComputeNodeUserAsync(
            string poolId, 
            string computeNodeId,
            string userName, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.DeleteComputeNodeUser(
                poolId,
                computeNodeId, 
                userName, 
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Deletes the specified user account from the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node from which you want to delete the user account.</param>
        /// <param name="userName">The name of the user account to be deleted.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>You can delete a user account from a compute node only when it is in the <see cref="Common.ComputeNodeState.Idle"/> or <see cref="Common.ComputeNodeState.Running"/> state.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteComputeNodeUserAsync"/>.</para>
        /// </remarks>
        public void DeleteComputeNodeUser(string poolId, string computeNodeId, string userName,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = DeleteComputeNodeUserAsync(poolId, computeNodeId, userName, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Gets a Remote Desktop Protocol (RDP) file for the specified node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node for which to get a Remote Desktop file.</param>
        /// <param name="rdpStream">The <see cref="Stream"/> into which the RDP file contents will be written.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>This method does not close the <paramref name="rdpStream"/> stream, and it does not reset the position after writing.
        /// It is the caller's responsibility to close the stream, or to reset the position if required.</para>
        /// <para>The get RDP file operation runs asynchronously.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="CloudServiceConfiguration" /> property. 
        /// If this method is invoked on pools created with <see cref="VirtualMachineConfiguration"/>, then Batch service returns 409 (Conflict). 
        /// For pools with <see cref="VirtualMachineConfiguration"/> property, the new method <see cref="GetRemoteLoginSettings"/> must be used.</para>
        /// </remarks>
        public System.Threading.Tasks.Task GetRDPFileAsync(
            string poolId, 
            string computeNodeId, 
            Stream rdpStream,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.GetComputeNodeRDPFile(
                poolId,
                computeNodeId, 
                rdpStream, 
                bhMgr,
                cancellationToken);

            return asyncTask;
        }


        /// <summary>
        /// Gets a Remote Desktop Protocol (RDP) file for the specified node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node for which to get a Remote Desktop file.</param>
        /// <param name="rdpStream">The <see cref="Stream"/> into which the RDP file contents will be written.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This method does not close the <paramref name="rdpStream"/> stream, and it does not reset the position after writing.
        /// It is the caller's responsibility to close the stream, or to reset the position if required.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetRDPFileAsync(string, string, Stream, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="CloudServiceConfiguration" /> property. 
        /// If this method is invoked on pools created with <see cref="VirtualMachineConfiguration"/>, then Batch service returns 409 (Conflict). 
        /// For pools with <see cref="VirtualMachineConfiguration"/> property, the new method <see cref="GetRemoteLoginSettings"/> must be used.</para>
        /// </remarks>
        public void GetRDPFile(string poolId, string computeNodeId, Stream rdpStream,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = GetRDPFileAsync(poolId, computeNodeId, rdpStream, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal async System.Threading.Tasks.Task GetRDPFileViaFileNameAsyncImpl(
            string poolId, 
            string computeNodeId,
            string rdpFileNameToCreate, 
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            // create the file
            using (FileStream rdpStream = File.Create(rdpFileNameToCreate))
            {
                System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.GetComputeNodeRDPFile(poolId,
                    computeNodeId, rdpStream, bhMgr, cancellationToken);

                await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                // stream has rdp contents, flush and close
                await rdpStream.FlushAsync().ConfigureAwait(continueOnCapturedContext: false);

                rdpStream.Close();
            }
        }

        /// <summary>
        /// Gets a Remote Desktop Protocol file for the specified node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node for which to get a Remote Desktop file.</param>
        /// <param name="rdpFileNameToCreate">The file path at which to create the RDP file.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If the file specified by <paramref name="rdpFileNameToCreate"/> already exists, it is overwritten.</para>
        /// <para>The get RDP file operation runs asynchronously.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="CloudServiceConfiguration" /> property. 
        /// If this method is invoked on pools created with <see cref="VirtualMachineConfiguration"/>, then Batch service returns 409 (Conflict). 
        /// For pools with <see cref="VirtualMachineConfiguration"/> property, the new method <see cref="GetRemoteLoginSettingsAsync"/> must be used.</para>
        /// </remarks>
        public System.Threading.Tasks.Task GetRDPFileAsync(
            string poolId, 
            string computeNodeId,
            string rdpFileNameToCreate, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = GetRDPFileViaFileNameAsyncImpl(
                poolId, 
                computeNodeId,
                rdpFileNameToCreate, 
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets a Remote Desktop Protocol file for the specified node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node for which to get a Remote Desktop file.</param>
        /// <param name="rdpFileNameToCreate">The file path at which to create the RDP file.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>If the file specified by <paramref name="rdpFileNameToCreate"/> already exists, it is overwritten.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetRDPFileAsync(string, string, string, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="CloudServiceConfiguration" /> property. 
        /// If this method is invoked on pools created with <see cref="VirtualMachineConfiguration"/>, then Batch service returns 409 (Conflict). 
        /// For pools with <see cref="VirtualMachineConfiguration"/> property, the new method <see cref="GetRemoteLoginSettings"/> must be used.</para>
        /// </remarks>
        public void GetRDPFile(string poolId, string computeNodeId, string rdpFileNameToCreate,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = GetRDPFileAsync(poolId, computeNodeId, rdpFileNameToCreate, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal async System.Threading.Tasks.Task<RemoteLoginSettings> GetRemoteLoginSettingsImpl(string poolId, string computeNodeId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var asyncTask = _parentBatchClient.ProtocolLayer.GetRemoteLoginSettings(poolId, computeNodeId, bhMgr, cancellationToken);

            var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
            
            Models.ComputeNodeGetRemoteLoginSettingsResult rlSettings = response.Body;
            
            RemoteLoginSettings rls = new RemoteLoginSettings(rlSettings);

            return rls;
        }

        /// <summary>
        /// Gets the settings required for remote login to a compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node for which to get a Remote Desktop file.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The get remote login settings operation runs asynchronously.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="VirtualMachineConfiguration"/> property. 
        /// If this method is invoked on pools created with <see cref="Microsoft.Azure.Batch.CloudServiceConfiguration" />, then Batch service returns 409 (Conflict). 
        /// For pools with a <see cref="Microsoft.Azure.Batch.CloudServiceConfiguration" /> property, one of the GetRDPFileAsync/GetRDPFile methods must be used.</para>
        /// </remarks>
        public System.Threading.Tasks.Task<RemoteLoginSettings> GetRemoteLoginSettingsAsync(
            string poolId, 
            string computeNodeId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task<RemoteLoginSettings> asyncTask = GetRemoteLoginSettingsImpl(
                    poolId,
                    computeNodeId,
                    bhMgr,
                    cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets the settings required for remote login to a compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node for which to get a Remote Desktop file.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetRemoteLoginSettingsAsync(string, string, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="VirtualMachineConfiguration"/> property. 
        /// If this method is invoked on pools created with <see cref="CloudServiceConfiguration" />, then Batch service returns 409 (Conflict). 
        /// For pools with a <see cref="CloudServiceConfiguration" /> property, one of the GetRDPFileAsync/GetRDPFile methods must be used.</para>
        /// </remarks>
        public RemoteLoginSettings GetRemoteLoginSettings(
            string poolId, 
            string computeNodeId, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<RemoteLoginSettings> asyncTask = GetRemoteLoginSettingsAsync(poolId, computeNodeId, additionalBehaviors))
            {
                RemoteLoginSettings rls = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

                return rls;
            }
        }

        /// <summary>
        /// Reboots the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node to reboot.</param>
        /// <param name="rebootOption">Specifies when to reboot the node and what to do with currently running tasks. The default is <see cref="Common.ComputeNodeRebootOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>You can reboot a compute node only when it is in the <see cref="Common.ComputeNodeState.Idle"/> or <see cref="Common.ComputeNodeState.Running"/> state.</para>
        /// <para>The reboot operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task RebootAsync(string poolId, 
            string computeNodeId,
            Common.ComputeNodeRebootOption? rebootOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.RebootComputeNode(
                poolId,
                computeNodeId, 
                rebootOption, 
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Reboots the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node to reboot.</param>
        /// <param name="rebootOption">Specifies when to reboot the node and what to do with currently running tasks. The default is <see cref="Common.ComputeNodeRebootOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>You can reboot a compute node only when it is in the <see cref="Common.ComputeNodeState.Idle"/> or <see cref="Common.ComputeNodeState.Running"/> state.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="RebootAsync"/>.</para>
        /// </remarks>
        public void Reboot(string poolId, string computeNodeId, Common.ComputeNodeRebootOption? rebootOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = RebootAsync(poolId, computeNodeId, rebootOption, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Reinstalls the operating system on the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node to reimage.</param>
        /// <param name="reimageOption">Specifies when to reimage the node and what to do with currently running tasks. The default is <see cref="Common.ComputeNodeReimageOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>You can reimage a compute node only when it is in the <see cref="Common.ComputeNodeState.Idle"/> or <see cref="Common.ComputeNodeState.Running"/> state.</para>
        /// <para>The reimage operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task ReimageAsync(
            string poolId, 
            string computeNodeId,
            Common.ComputeNodeReimageOption? reimageOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.ReimageComputeNode(poolId, computeNodeId, reimageOption, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Reinstalls the operating system on the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node to reimage.</param>
        /// <param name="reimageOption">Specifies when to reimage the node and what to do with currently running tasks. The default is <see cref="Common.ComputeNodeReimageOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>You can reimage a compute node only when it is in the <see cref="Common.ComputeNodeState.Idle"/> or <see cref="Common.ComputeNodeState.Running"/> state.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="ReimageAsync"/>.</para>
        /// </remarks>
        public void Reimage(string poolId, string computeNodeId, Common.ComputeNodeReimageOption? reimageOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = ReimageAsync(poolId, computeNodeId, reimageOption, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Changes the operating system version of the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="targetOSVersion">The Azure Guest OS version to be installed on the virtual machines in the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>During the change OS version operation, the Batch service traverses the nodes of the pool, changing the OS version of compute nodes.  When a compute node is chosen, any tasks running on that node are removed from the node and requeued to be rerun later (or on a different compute node).  The node will be unavailable until the version change is complete.</para>
        /// <para>The operation will result in temporarily reduced pool capacity as nodes are taken out of service to have their OS version changed. Although the Batch service tries to avoid changing all compute nodes at the same time, it does not guarantee to do this (particularly on small pools); therefore, the operation may result in the pool being temporarily unavailable to run tasks.</para>
        /// <para>When you request an OS version change, the pool state changes to <see cref="Common.PoolState.Upgrading"/>.  When all compute nodes have finished changing version, the pool state returns to <see cref="Common.PoolState.Active"/>.</para>
        /// <para>While the version change is in progress, the pool's <see cref="Microsoft.Azure.Batch.CloudServiceConfiguration.CurrentOSVersion"/> reflects the OS version that nodes are changing from, and <see cref="Microsoft.Azure.Batch.CloudServiceConfiguration.TargetOSVersion"/> reflects the OS version that nodes are changing to. Once the change is complete, CurrentOSVersion is updated to reflect the OS version now running on all nodes.</para>
        /// <para>The change version operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task ChangeOSVersionAsync(
            string poolId, 
            string targetOSVersion,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.UpgradePoolOS(
                poolId,
                targetOSVersion, 
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Changes the operating system version of the specified pool.
        /// </summary>
        /// <param name="poolId">The id of the pool.</param>
        /// <param name="targetOSVersion">The Azure Guest OS version to be installed on the virtual machines in the pool.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>During the change OS version operation, the Batch service traverses the nodes of the pool, changing the OS version of compute nodes.  When a compute node is chosen, any tasks running on that node are removed from the node and requeued to be rerun later (or on a different compute node).  The node will be unavailable until the version change is complete.</para>
        /// <para>The operation will result in temporarily reduced pool capacity as nodes are taken out of service to have their OS version changed. Although the Batch service tries to avoid changing all compute nodes at the same time, it does not guarantee to do this (particularly on small pools); therefore, the operation may result in the pool being temporarily unavailable to run tasks.</para>
        /// <para>When you request an OS version change, the pool state changes to <see cref="Common.PoolState.Upgrading"/>.  When all compute nodes have finished changing version, the pool state returns to <see cref="Common.PoolState.Active"/>.</para>
        /// <para>While the version change is in progress, the pool's <see cref="Microsoft.Azure.Batch.CloudServiceConfiguration.CurrentOSVersion"/> reflects the OS version that nodes are changing from, and <see cref="Microsoft.Azure.Batch.CloudServiceConfiguration.TargetOSVersion"/> reflects the OS version that nodes are changing to. Once the change is complete, CurrentOSVersion is updated to reflect the OS version now running on all nodes.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="ChangeOSVersionAsync"/>.</para>
        /// </remarks>
        public void ChangeOSVersion(string poolId, string targetOSVersion,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = ChangeOSVersionAsync(poolId, targetOSVersion, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal async System.Threading.Tasks.Task<NodeFile> GetNodeFileAsyncImpl(
            string poolId,
            string computeNodeId,
            string fileName,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var getNodeFilePropertiesTask = await this.ParentBatchClient.ProtocolLayer.GetNodeFilePropertiesByNode(
                poolId, 
                computeNodeId, 
                fileName, 
                bhMgr,
                cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
         
            Models.NodeFile file = getNodeFilePropertiesTask.Body;

            // wrap protocol object
            NodeFile wrapped = new ComputeNodeFile(this, poolId, computeNodeId, file, bhMgr.BaseBehaviors);

            return wrapped;
        }

        /// <summary>
        /// Gets information about a file on a compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="fileName">The name of the file to retrieve.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="NodeFile"/> containing information about the file, and which can be used to download the file (see <see cref="NodeFile.CopyToStreamAsync"/>).</returns>
        /// <remarks>The get file operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task<NodeFile> GetNodeFileAsync(
            string poolId, 
            string computeNodeId,
            string fileName, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task<NodeFile> asyncTask = this.GetNodeFileAsyncImpl(
                poolId, 
                computeNodeId, 
                fileName,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets information about a file on a compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="fileName">The name of the file to retrieve.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="NodeFile"/> containing information about the file, and which can be used to download the file (see <see cref="NodeFile.CopyToStream"/>).</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetNodeFileAsync"/>.</remarks>
        public NodeFile GetNodeFile(string poolId, string computeNodeId, string fileName,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<NodeFile> asyncTask = this.GetNodeFileAsync(poolId, computeNodeId, fileName, additionalBehaviors))
            {
                return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal IPagedEnumerable<NodeFile> ListNodeFilesImpl(
            string poolId,
            string computeNodeId,
            bool? recursive,
            BehaviorManager bhMgr,
            DetailLevel detailLevel)
        {
            PagedEnumerable<NodeFile> enumerable = new PagedEnumerable<NodeFile>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListNodeFilesByNodeEnumerator typedEnumerator = new AsyncListNodeFilesByNodeEnumerator(this, poolId, computeNodeId, recursive, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<NodeFile> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Enumerates files on the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="recursive">If true, recursively enumerates all files on the compute node. If false, enumerates only the files in the compute node root directory.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{NodeFile}"/> that can be used to enumerate files asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the file data is retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; file data is retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<NodeFile> ListNodeFiles(
            string poolId,
            string computeNodeId,
            bool? recursive = null,
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // get the enumerable
            IPagedEnumerable<NodeFile> enumerable = this.ListNodeFilesImpl(
                poolId,
                computeNodeId,
                recursive,
                bhMgr,
                detailLevel);

            return enumerable;
        }

        /// <summary>
        /// Deletes the specified file from the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="fileName">The name of the file to delete.</param>
        /// <param name="recursive">
        /// If the file-path parameter represents a directory instead of a file, you can set the optional 
        /// recursive parameter to true to delete the directory and all of the files and subdirectories in it. If recursive is false 
        /// then the directory must be empty or deletion will fail.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The delete operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task DeleteNodeFileAsync(
            string poolId, 
            string computeNodeId, 
            string fileName,
            bool? recursive = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = _parentBatchClient.ProtocolLayer.DeleteNodeFileByNode(
                poolId,
                computeNodeId, 
                fileName, 
                recursive,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Deletes the specified file from the specified compute node.
        /// </summary>
        /// <param name="poolId">The id of the pool that contains the compute node.</param>
        /// <param name="computeNodeId">The id of the compute node.</param>
        /// <param name="fileName">The name of the file to delete.</param>
        /// <param name="recursive">
        /// If the file-path parameter represents a directory instead of a file, you can set the optional 
        /// recursive parameter to true to delete the directory and all of the files and subdirectories in it. If recursive is false 
        /// then the directory must be empty or deletion will fail.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation.  For a non-blocking equivalent, see <see cref="DeleteNodeFileAsync"/>.</remarks>
        public void DeleteNodeFile(
            string poolId, 
            string computeNodeId, 
            string fileName,
            bool? recursive = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = this.DeleteNodeFileAsync(poolId, computeNodeId, fileName, recursive, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }


        /// <summary>
        /// Gets lifetime summary statistics for all of the pools in the current account.  
        /// Statistics are aggregated across all pools that have ever existed in the account, from account creation to the last update time of the statistics.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>The aggregated pool statistics.</returns>
        /// <remarks>The get statistics operation runs asynchronously.</remarks>
        public async System.Threading.Tasks.Task<PoolStatistics> GetAllPoolsLifetimeStatisticsAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.PoolStatistics, Models.PoolGetAllPoolsLifetimeStatisticsHeaders>> asyncTask = 
                this.ParentBatchClient.ProtocolLayer.GetAllPoolLifetimeStats(bhMgr, cancellationToken);

            var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            PoolStatistics statistics = new PoolStatistics(response.Body);

            return statistics;
        }

        /// <summary>
        /// Gets lifetime summary statistics for all of the pools in the current account.  
        /// Statistics are aggregated across all pools that have ever existed in the account, from account creation to the last update time of the statistics.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>The aggregated pool statistics.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetAllPoolsLifetimeStatisticsAsync"/>.</remarks>
        public PoolStatistics GetAllPoolsLifetimeStatistics(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<PoolStatistics> asyncTask = this.GetAllPoolsLifetimeStatisticsAsync(additionalBehaviors))
            {
                PoolStatistics statistics = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

                return statistics;
            }
        }

        /// <summary>
        /// Enumerates pool usage metrics.
        /// </summary>
        /// <param name="startTime">The start time of the aggregation interval covered by this entry.</param>
        /// <param name="endTime">The end time of the aggregation interval for this entry.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{PoolUsageMetrics}"/> that can be used to enumerate metrics asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the metrics data is retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; metrics data is retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<PoolUsageMetrics> ListPoolUsageMetrics(DateTime? startTime = null, DateTime? endTime = null, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            PagedEnumerable<PoolUsageMetrics> enumerable = new PagedEnumerable<PoolUsageMetrics>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListPoolUsageMetricsEnumerator typedEnumerator = new AsyncListPoolUsageMetricsEnumerator(this, startTime, endTime, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<PoolUsageMetrics> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Enumerates the node agent Sku values supported by Batch Service. 
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{NodeAgentSku}"/> that can be used to enumerate node agent sku values asynchronously or synchronously.</returns>
        public IPagedEnumerable<NodeAgentSku> ListNodeAgentSkus(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            PagedEnumerable<NodeAgentSku> enumerable = new PagedEnumerable<NodeAgentSku>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListNodeAgentSkusEnumerator typedEnumerator = new AsyncListNodeAgentSkusEnumerator(this, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<NodeAgentSku> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

#endregion // PoolOperations
    }
}