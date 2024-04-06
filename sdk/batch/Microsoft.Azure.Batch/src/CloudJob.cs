// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Utils;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// An Azure Batch job.
    /// </summary>
    public partial class CloudJob : IRefreshable
    {

        #region // CloudJob


        /// <summary>
        /// Commits this <see cref="CloudJob" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If the <see cref="CloudJob"/> already exists on the Batch service, its properties are replaced by the properties of this <see cref="CloudJob"/>.</para>
        /// <para>The commit operation runs asynchronously.</para>
        /// </remarks>
        public async Task CommitAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default)
        {
            // first forbid actions during commit
            this.propertyContainer.IsReadOnly = true;

            // craft the behavior manager for this call
            BehaviorManager behaveMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // hold the tpl task for the server call
            Task asyncTask;

            if (BindingState.Unbound == this.propertyContainer.BindingState) // unbound commit
            {
                // take all property changes and create a job
                Models.JobAddParameter protoJob = this.GetTransportObject();

                asyncTask = parentBatchClient.ProtocolLayer.AddJob(protoJob, behaveMgr, cancellationToken);
            }
            else
            {
                Models.MetadataItem[] modelMetadata = UtilitiesInternal.ConvertToProtocolArray(this.Metadata);
                Models.JobConstraints modelJobConstraints = UtilitiesInternal.CreateObjectWithNullCheck(this.Constraints, item => item.GetTransportObject());
                Models.PoolInformation modelPoolInformation = UtilitiesInternal.CreateObjectWithNullCheck(this.PoolInformation, item => item.GetTransportObject());
                    
                asyncTask = this.parentBatchClient.ProtocolLayer.UpdateJob(
                    Id,
                    Priority,
                    UtilitiesInternal.MapNullableEnum<Common.OnAllTasksComplete, Models.OnAllTasksComplete>(this.OnAllTasksComplete),
                    modelPoolInformation,
                    modelJobConstraints,
                    MaxParallelTasks,
                    AllowTaskPreemption,
                    modelMetadata,
                    behaveMgr,
                    cancellationToken);
            }

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Commits this <see cref="CloudJob" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>If the <see cref="CloudJob"/> already exists on the Batch service, its properties are replaced by the properties of this <see cref="CloudJob"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CommitAsync"/>.</para>
        /// </remarks>
        public void Commit(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = CommitAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Commits all pending changes to this <see cref="CloudJob" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// Updates an existing <see cref="CloudJob"/> on the Batch service by replacing its properties with the properties of this <see cref="CloudJob"/> which have been changed.
        /// Unchanged properties are ignored.
        /// All changes since the last time this entity was retrieved from the Batch service (either via <see cref="Refresh"/>, <see cref="JobOperations.GetJob"/>,
        /// or <see cref="JobOperations.ListJobs"/>) are applied.
        /// Properties which are explicitly set to null will cause an exception because the Batch service does not support partial updates which set a property to null.
        /// If you need to set a property to null, use <see cref="Commit"/>.
        /// </para>
        /// <para>This operation runs asynchronously.</para>
        /// </remarks>
        public async Task CommitChangesAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            UtilitiesInternal.ThrowOnUnbound(propertyContainer.BindingState);

            // first forbid actions during patch
            this.propertyContainer.IsReadOnly = true;

            // craft the behavior manager for this call
            BehaviorManager behaveMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Models.MetadataItem[] modelMetadata = this.propertyContainer.MetadataProperty.
                GetTransportObjectIfChanged<MetadataItem, Models.MetadataItem>();
            Models.JobConstraints modelJobConstraints = this.propertyContainer.ConstraintsProperty.
                GetTransportObjectIfChanged<JobConstraints, Models.JobConstraints>();
            Models.PoolInformation modelPoolInformation = this.propertyContainer.PoolInformationProperty.
                GetTransportObjectIfChanged<PoolInformation, Models.PoolInformation>();
            int? priority = this.propertyContainer.PriorityProperty.GetIfChangedOrNull();
            int? maxParallelTasks = this.propertyContainer.MaxParallelTasksProperty.GetIfChangedOrNull();

            Task asyncTask = this.parentBatchClient.ProtocolLayer.PatchJob(
                Id,
                priority,
                maxParallelTasks,
                AllowTaskPreemption,
                UtilitiesInternal.MapNullableEnum<Common.OnAllTasksComplete, Models.OnAllTasksComplete>(this.OnAllTasksComplete),
                modelPoolInformation,
                modelJobConstraints,
                modelMetadata,
                behaveMgr,
                cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Commits all pending changes to this <see cref="CloudJob" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>
        /// Updates an existing <see cref="CloudJob"/> on the Batch service by replacing its properties with the properties of this <see cref="CloudJob"/> which have been changed.
        /// Unchanged properties are ignored.
        /// All changes since the last time this entity was retrieved from the Batch service (either via <see cref="Refresh"/>, <see cref="JobOperations.GetJob"/>,
        /// or <see cref="JobOperations.ListJobs"/>) are applied.
        /// Properties which are explicitly set to null will cause an exception because the Batch service does not support partial updates which set a property to null.
        /// If you need to set a property to null, use <see cref="Commit"/>.
        /// </para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CommitChangesAsync"/>.</para>
        /// </remarks>
        public void CommitChanges(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = this.CommitChangesAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Adds a single task to this <see cref="CloudJob"/>.  To add multiple tasks,
        /// use <see cref="JobOperations.AddTaskAsync(string,IEnumerable{CloudTask},BatchClientParallelOptions,ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}},TimeSpan?,IEnumerable{BatchClientBehavior})">JobOperations.AddTaskAsync</see>.
        /// </summary>
        /// <param name="taskToAdd">The <see cref="CloudTask"/> to add.</param>
        /// <param name="allFileStagingArtifacts">An optional collection to customize and receive information about the file staging process (see <see cref="CloudTask.FilesToStage"/>).
        /// For more information see <see cref="IFileStagingArtifact"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// Each call to this method incurs a request to the Batch service. Therefore, using this method to add
        /// multiple tasks is less efficient than using a bulk add method, and can incur HTTP connection restrictions.
        /// If you are performing many of these operations in parallel and are seeing client side timeouts (a <see cref="TaskCanceledException"/>), please see 
        /// http://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit%28v=vs.110%29.aspx
        /// or use 
        /// <see cref="JobOperations.AddTaskAsync(string,IEnumerable{CloudTask},BatchClientParallelOptions,ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}},TimeSpan?,IEnumerable{Microsoft.Azure.Batch.BatchClientBehavior})"/>.
        /// </para>
        /// <para>The add task operation runs asynchronously.</para>
        /// </remarks>
        public async Task AddTaskAsync(
            CloudTask taskToAdd,
            ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            UtilitiesInternal.ThrowOnUnbound(propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager behaveMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.JobOperations.AddTaskAsyncImpl(this.Id, taskToAdd, behaveMgr, cancellationToken, allFileStagingArtifacts);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Adds a single task to this <see cref="CloudJob"/>.  To add multiple tasks,
        /// use <see cref="JobOperations.AddTask(string,IEnumerable{CloudTask},BatchClientParallelOptions,ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}},TimeSpan?,IEnumerable{BatchClientBehavior})">JobOperations.AddTaskAsync</see>.
        /// </summary>
        /// <param name="taskToAdd">The <see cref="CloudTask"/> to add.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A collection of information about the file staging process (see <see cref="CloudTask.FilesToStage"/>).
        /// For more information see <see cref="IFileStagingArtifact"/>.</returns>
        /// <remarks>
        /// <para>
        /// Each call to this method incurs a request to the Batch service. Therefore, using this method to add
        /// multiple tasks is less efficient than using a bulk add method, and can incur HTTP connection restrictions.
        /// If you are performing many of these operations in parallel and are seeing client side timeouts (a <see cref="TaskCanceledException"/>), please see 
        /// http://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit%28v=vs.110%29.aspx
        /// or use 
        /// <see cref="JobOperations.AddTask(string,IEnumerable{CloudTask},BatchClientParallelOptions,ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}},TimeSpan?,IEnumerable{Microsoft.Azure.Batch.BatchClientBehavior})"/>.
        /// </para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="AddTaskAsync(CloudTask, ConcurrentDictionary{Type, IFileStagingArtifact}, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// </remarks>
        public ConcurrentDictionary<Type, IFileStagingArtifact> AddTask(CloudTask taskToAdd, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts = new ConcurrentDictionary<Type, IFileStagingArtifact>();

            Task asyncTask = AddTaskAsync(taskToAdd, allFileStagingArtifacts, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

            return allFileStagingArtifacts;
        }

        /// <summary>
        /// Adds tasks to a job.
        /// </summary>
        /// <param name="tasksToAdd">The <see cref="CloudTask"/>s to add.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="parallelOptions">
        /// Controls the number of simultaneous parallel AddTaskCollection requests issued to the Batch service.  Each AddTaskCollection request contains at most
        /// <see cref="Constants.MaxTasksInSingleAddTaskCollectionRequest"/> tasks in it.
        /// Also controls the cancellation token for the operation.
        /// If omitted, the default is used (see <see cref="BatchClientParallelOptions"/>.)
        /// </param>
        /// <param name="fileStagingArtifacts">An optional collection to receive information about the file staging process (see <see cref="CloudTask.FilesToStage"/>).
        /// An entry is added to the <see cref="ConcurrentBag{T}"/> for each set of tasks grouped for submission to the Batch service.
        /// Unlike single-task adds, you cannot use this parameter to customize the file staging process.
        /// For more information about the format of each entry, see <see cref="IFileStagingArtifact"/>.</param>
        /// <param name="timeout">The amount of time after which the operation times out.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The add task operation runs asynchronously.</para>
        /// <para>This method is not atomic; that is, it is possible for the method to start adding tasks and
        /// then fail. The collection of tasks to add is broken down into chunks of size at most <see cref="Constants.MaxTasksInSingleAddTaskCollectionRequest"/>,
        /// and an AddTaskCollection request is issued for each chunk.  Requests may be issued in parallel according to
        /// the <paramref name="parallelOptions"/>.</para>
        /// <para>Issuing a large number of simultaneous requests to the Batch service can incur HTTP connection restrictions.
        /// If you are performing many of these operations in parallel (or have specified a large MaxDegreeOfParallelism in
        /// the parallelOptions) and are seeing client side timeouts (a <see cref="TaskCanceledException"/>), please see 
        /// http://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit%28v=vs.110%29.aspx .</para>
        /// <para>The progress of the operation in the face of errors is determined by <see cref="AddTaskCollectionResultHandler"/> behavior.
        /// You do not normally need to specify this behavior, as the Batch client uses a default which works in normal circumstances.
        /// If you do want to customize this behavior, specify an AddTaskCollectionResultHandler in the <see cref="CustomBehaviors"/>
        /// or <paramref name="additionalBehaviors"/> collections.</para>
        /// </remarks>
        /// <exception cref="ParallelOperationsException">Thrown if one or more requests to the Batch service fail.</exception>
        public async Task AddTaskAsync(
            IEnumerable<CloudTask> tasksToAdd,
            BatchClientParallelOptions parallelOptions = null,
            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> fileStagingArtifacts = null,
            TimeSpan? timeout = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager behaveMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.JobOperations.AddTaskAsyncImpl(this.Id, tasksToAdd, parallelOptions, fileStagingArtifacts, timeout, behaveMgr);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Adds tasks to a job.
        /// </summary>
        /// <param name="tasksToAdd">The <see cref="CloudTask"/>s to add.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="parallelOptions">
        /// Controls the number of simultaneous parallel AddTaskCollection requests issued to the Batch service.  Each AddTaskCollection request contains at most
        /// <see cref="Constants.MaxTasksInSingleAddTaskCollectionRequest"/> tasks in it.
        /// Also controls the cancellation token for the operation.
        /// If omitted, the default is used (see <see cref="BatchClientParallelOptions"/>.)
        /// </param>
        /// <param name="fileStagingArtifacts">An optional collection to receive information about the file staging process (see <see cref="CloudTask.FilesToStage"/>).
        /// An entry is added to the <see cref="ConcurrentBag{T}"/> for each set of tasks grouped for submission to the Batch service.
        /// Unlike single-task adds, you cannot use this parameter to customize the file staging process.
        /// For more information about the format of each entry, see <see cref="IFileStagingArtifact"/>.</param>
        /// <param name="timeout">The amount of time after which the operation times out.</param>
        /// <remarks>
        /// <para>This is a blocking operation; for a non-blocking equivalent, see <see cref="AddTaskAsync(IEnumerable{CloudTask}, BatchClientParallelOptions, ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}}, TimeSpan?, IEnumerable{BatchClientBehavior})"/>.</para>
        /// <para>This method is not atomic; that is, it is possible for the method to start adding tasks and
        /// then fail. The collection of tasks to add is broken down into chunks of size at most <see cref="Constants.MaxTasksInSingleAddTaskCollectionRequest"/>,
        /// and an AddTaskCollection request is issued for each chunk.  Requests may be issued in parallel according to
        /// the <paramref name="parallelOptions"/>.</para>
        /// <para>Issuing a large number of simultaneous requests to the Batch service can incur HTTP connection restrictions.
        /// If you are performing many of these operations in parallel (or have specified a large MaxDegreeOfParallelism in
        /// the parallelOptions) and are seeing client side timeouts (a <see cref="TaskCanceledException"/>), please see 
        /// http://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit%28v=vs.110%29.aspx .</para>
        /// <para>The progress of the operation in the face of errors is determined by <see cref="AddTaskCollectionResultHandler"/> behavior.
        /// You do not normally need to specify this behavior, as the Batch client uses a default which works in normal circumstances.
        /// If you do want to customize this behavior, specify an AddTaskCollectionResultHandler in the <see cref="CustomBehaviors"/>
        /// or <paramref name="additionalBehaviors"/> collections.</para>
        /// </remarks>
        /// <exception cref="ParallelOperationsException">Thrown if one or more requests to the Batch service fail.</exception>
        public void AddTask(
            IEnumerable<CloudTask> tasksToAdd,
            BatchClientParallelOptions parallelOptions = null,
            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> fileStagingArtifacts = null,
            TimeSpan? timeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            Task asyncTask = this.AddTaskAsync(tasksToAdd, parallelOptions, fileStagingArtifacts, timeout, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Enumerates the <see cref="CloudTask">tasks</see> of this <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{CloudTask}"/> that can be used to enumerate tasks asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the tasks are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; tasks are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<CloudTask> ListTasks(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager behaveMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<CloudTask> ienumAsync = this.parentBatchClient.JobOperations.ListTasksImpl(this.Id, behaveMgr, detailLevel);

            return ienumAsync;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="taskId">The id of the task to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="CloudTask"/> containing information about the specified Azure Batch task.</returns>
        /// <remarks>The get task operation runs asynchronously.</remarks>
        public async Task<CloudTask> GetTaskAsync(
            string taskId, 
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            Task<CloudTask> asyncTask = this.parentBatchClient.JobOperations.GetTaskAsyncImpl(this.Id, taskId, bhMgr, cancellationToken);
            CloudTask theTask = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            return theTask;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="taskId">The id of the task to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>A <see cref="CloudTask"/> containing information about the specified Azure Batch task.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetTaskAsync"/>.</remarks>
        public CloudTask GetTask(
                                string taskId, 
                                DetailLevel detailLevel = null, 
                                IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<CloudTask> asyncTask = GetTaskAsync(taskId, detailLevel, additionalBehaviors);
            CloudTask cloudTask = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

            return cloudTask;
        }

        /// <summary>
        /// Enables this <see cref="CloudJob"/>, allowing new tasks to run.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The enable operation runs asynchronously.</remarks>
        public Task EnableAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default)
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);
            
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            // start call
            Task asyncTask = parentBatchClient.ProtocolLayer.EnableJob(Id, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Enables this <see cref="CloudJob"/>, allowing new tasks to run.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableAsync"/>.</remarks>
        public void Enable(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = EnableAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Disables this <see cref="CloudJob"/>.  Disabled jobs do not run new tasks, but may be re-enabled later.
        /// </summary>
        /// <param name="disableJobOption">Specifies what to do with active tasks associated with the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The disable operation runs asynchronously.</remarks>
        public Task DisableAsync(
            Common.DisableJobOption disableJobOption, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default)
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            // start call
            Task asyncTask = this.parentBatchClient.ProtocolLayer.DisableJob(Id, disableJobOption, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Disables this <see cref="CloudJob"/>.  Disabled jobs do not run new tasks, but may be re-enabled later.
        /// </summary>
        /// <param name="disableJobOption">Specifies what to do with active tasks associated with the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableAsync"/>.</remarks>
        public void Disable(Common.DisableJobOption disableJobOption, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DisableAsync(disableJobOption, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Terminates this <see cref="CloudJob"/>, marking it as completed.
        /// </summary>
        /// <param name="terminateReason">The text you want to appear as the job's <see cref="JobExecutionInformation.TerminateReason"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>The terminate operation runs asynchronously.</remarks>
        public Task TerminateAsync(
            string terminateReason = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default)
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            // start call
            Task asyncTask = this.parentBatchClient.ProtocolLayer.TerminateJob(Id, terminateReason, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Terminates this <see cref="CloudJob"/>, marking it as completed.
        /// </summary>
        /// <param name="terminateReason">The text you want to appear as the job's <see cref="JobExecutionInformation.TerminateReason"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="TerminateAsync"/>.</remarks>
        public void Terminate(string terminateReason = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = TerminateAsync(terminateReason, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Deletes this <see cref="CloudJob" />.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the job be deleted.  The request puts the job in the <see cref="Common.JobState.Deleting"/> state.
        /// The Batch service will stop any running tasks and perform the actual job deletion without any further client action.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        public Task DeleteAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default)
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            // start call
            Task asyncTask = parentBatchClient.ProtocolLayer.DeleteJob(Id, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Deletes this <see cref="CloudJob" />.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The delete operation requests that the job be deleted.  The request puts the job in the <see cref="Common.JobState.Deleting"/> state.
        /// The Batch service will stop any running tasks and perform the actual job deletion without any further client action.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteAsync"/>.</para>
        /// </remarks>
        public void Delete(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Refreshes the current <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous refresh operation.</returns>
        public async Task RefreshAsync(
            DetailLevel detailLevel = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors, detailLevel);

            // start operation
            Task<AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>> asyncTask =
                this.parentBatchClient.ProtocolLayer.GetJob(Id, bhMgr, cancellationToken);

            AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // get job from response
            Models.CloudJob newProtocolJob = response.Body;

            PropertyContainer container = new PropertyContainer(newProtocolJob);

            // immediately available to all threads
            this.propertyContainer = container;
        }

        /// <summary>
        /// Refreshes the current <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Gets the Task counts for the specified Job.  Task counts provide a count of the Tasks by active, running or completed Task state, and a count of Tasks which succeeded
        /// or failed.Tasks in the preparing state are counted as running.Note that the numbers returned may not always be up to date. If you need exact task counts, use a list query.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <remarks>The get job task counts operation runs asynchronously.</remarks>
        /// <returns>A <see cref="TaskCounts"/> object containing the task counts for the job.</returns>
        public async Task<TaskCountsResult> GetTaskCountsAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors, detailLevel: null);
            TaskCountsResult counts = await parentBatchClient.JobOperations.GetJobTaskCountsAsyncImpl(Id, bhMgr, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            return counts;
        }

        /// <summary>
        /// Gets the Task counts for the specified Job.  Task counts provide a count of the Tasks by active, running or completed Task state, and a count of Tasks which succeeded
        /// or failed.Tasks in the preparing state are counted as running.Note that the numbers returned may not always be up to date. If you need exact task counts, use a list query.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="TaskCounts"/> object containing the task counts for the job</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetTaskCountsAsync"/>.</remarks>
        public TaskCountsResult GetTaskCounts(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            TaskCountsResult result = GetTaskCountsAsync(additionalBehaviors).WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            return result;
        }

        #endregion // CloudJob

    }
}
