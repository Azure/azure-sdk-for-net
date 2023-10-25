// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;

namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Text;
    using System.Security;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Batch.Common;
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Performs operations on Azure Batch jobs.
    /// </summary>
    /// <seealso cref="CloudJob"/>
    public class JobOperations : IInheritedBehaviors
    {

        #region // constructors

        public JobOperations()
        {
        }

        internal JobOperations(BatchClient parentBatchClient, IEnumerable<BatchClientBehavior> inheritedBehaviors)
        {
            ParentBatchClient = parentBatchClient;

            // set up the behavior inheritance
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, inheritedBehaviors);
        }

        #endregion //constructors

        #region IInheritedBehaviors

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service
        /// made via this <see cref="JobOperations"/>.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors { get; set; }

        #endregion IInheritedBehaviors

        #region // JobOperations

        /// <summary>
        /// Creates an instance of CloudJob that is unbound and does not have a consistency relationship to any job in the Batch Service.
        /// </summary>
        /// <returns>A <see cref="CloudJob"/> representing a new job that has not been submitted to the Batch service.</returns>
        public CloudJob CreateJob()
        {
            string id = Guid.NewGuid().ToString();
            CloudJob unboundJob = new CloudJob(ParentBatchClient, CustomBehaviors)
            {
                //TODO: Do we want to do this...?
                Id = id // we lose the ability to construct an unbound job with zero changes (ie not marked dirty)
            };

            return unboundJob;
        }

        /// <summary>
        /// Creates an instance of CloudJob that is unbound and does not have a consistency relationship to any job in the Batch Service.
        /// </summary>
        /// <param name="jobId">The Id of the job.</param>
        /// <param name="poolInformation">The information about the pool the job will run on.</param>
        /// <returns>A <see cref="CloudJob"/> representing a new job that has not been submitted to the Batch service.</returns>
        public CloudJob CreateJob(string jobId, PoolInformation poolInformation)
        {
            CloudJob unboundJob = new CloudJob(ParentBatchClient, CustomBehaviors)
            {
                Id = jobId,
                PoolInformation = poolInformation
            };

            return unboundJob;
        }

        internal IPagedEnumerable<CloudJob> ListJobsImpl(BehaviorManager bhMgr, DetailLevel detailLevel)
        {
            PagedEnumerable<CloudJob> enumerable = new PagedEnumerable<CloudJob>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListJobsEnumerator typedEnumerator = new AsyncListJobsEnumerator(ParentBatchClient, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<CloudJob> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Enumerates the <see cref="CloudJob">jobs</see> in the Batch account.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{CloudJob}"/> that can be used to enumerate jobs asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the jobs are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; jobs are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<CloudJob> ListJobs(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<CloudJob> enumerable = ListJobsImpl(bhMgr, detailLevel);

            return enumerable;
        }

        internal async Task<CloudJob> GetJobAsyncImpl(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>> asyncTask = ParentBatchClient.ProtocolLayer.GetJob(jobId, bhMgr, cancellationToken);

            AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // extract job from response
            Models.CloudJob protoJob = response.Body;

            // convert to bound object layer equiv
            CloudJob openedJob = new CloudJob(ParentBatchClient, protoJob, bhMgr.BaseBehaviors);

            return openedJob;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="jobId">The id of the job to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="CloudJob"/> containing information about the specified Azure Batch job.</returns>
        /// <remarks>The get job operation runs asynchronously.</remarks>
        public async Task<CloudJob> GetJobAsync(
            string jobId,
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors, detailLevel);

            Task<CloudJob> asyncTask = GetJobAsyncImpl(jobId, bhMgr, cancellationToken);

            CloudJob openedJob = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            return openedJob;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="jobId">The id of the job to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>A <see cref="CloudJob"/> containing information about the specified Azure Batch job.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetJobAsync"/>.</remarks>
        public CloudJob GetJob(string jobId, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<CloudJob> asyncTask = GetJobAsync(jobId, detailLevel, additionalBehaviors);
            CloudJob newJob = asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);

            return newJob;
        }

        internal async Task<TaskCountsResult> GetJobTaskCountsAsyncImpl(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            AzureOperationResponse<Models.TaskCountsResult, Models.JobGetTaskCountsHeaders> response = await ParentBatchClient.ProtocolLayer.GetJobTaskCounts(
                jobId,
                bhMgr,
                cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
            Models.TaskCountsResult protoTaskCounts = response.Body;
            TaskCountsResult result = new TaskCountsResult(protoTaskCounts);

            return result;
        }

        /// <summary>
        /// Gets the task counts for the specified job.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <remarks>The get job task counts operation runs asynchronously.</remarks>
        /// <returns>A <see cref="TaskCounts"/> object containing the task counts for the job.</returns>
        public async Task<TaskCountsResult> GetJobTaskCountsAsync(
            string jobId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors, detailLevel: null);
            TaskCountsResult counts = await GetJobTaskCountsAsyncImpl(jobId, bhMgr, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            return counts;
        }

        /// <summary>
        /// Gets the task counts for the specified job.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="TaskCounts"/> object containing the task counts for the job.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetJobTaskCountsAsync"/>.</remarks>
        public TaskCountsResult GetJobTaskCounts(string jobId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            TaskCountsResult result = GetJobTaskCountsAsync(jobId, additionalBehaviors).WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
            return result;
        }

        /// <summary>
        /// Enables the specified job, allowing new tasks to run.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The enable operation runs asynchronously.</remarks>
        public async Task EnableJobAsync(string jobId, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task asyncTask = ParentBatchClient.ProtocolLayer.EnableJob(jobId, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Enables the specified job, allowing new tasks to run.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableJobAsync"/>.</remarks>
        public void EnableJob(string jobId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = EnableJobAsync(jobId, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Disables the specified job.  Disabled jobs do not run new tasks, but may be re-enabled later.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="disableJobOption">Specifies what to do with active tasks associated with the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The disable operation runs asynchronously.</remarks>
        public async Task DisableJobAsync(
            string jobId,
            Common.DisableJobOption disableJobOption,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task asyncTask = ParentBatchClient.ProtocolLayer.DisableJob(jobId, disableJobOption, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Disables the specified job.  Disabled jobs do not run new tasks, but may be re-enabled later.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="disableJobOption">Specifies what to do with active tasks associated with the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableJobAsync"/>.</remarks>
        public void DisableJob(string jobId, Common.DisableJobOption disableJobOption, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DisableJobAsync(jobId, disableJobOption, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Terminates the specified job, marking it as completed.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="terminateReason">The text you want to appear as the job's <see cref="JobExecutionInformation.TerminateReason"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>The terminate operation runs asynchronously.</remarks>
        public async Task TerminateJobAsync(
            string jobId,
            string terminateReason = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task asyncTask = ParentBatchClient.ProtocolLayer.TerminateJob(jobId, terminateReason, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Terminates the specified job, marking it as completed.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="terminateReason">The text you want to appear as the job's <see cref="JobExecutionInformation.TerminateReason"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="TerminateJobAsync"/>.</remarks>
        public void TerminateJob(string jobId, string terminateReason = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = TerminateJobAsync(jobId, terminateReason, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Deletes the specified job.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the job be deleted.  The request puts the job in the <see cref="Common.JobState.Deleting"/> state.
        /// The Batch service will stop any running tasks and perform the actual job deletion without any further client action.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        public async Task DeleteJobAsync(string jobId, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task asyncTask = ParentBatchClient.ProtocolLayer.DeleteJob(jobId, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes the specified job.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The delete operation requests that the job be deleted.  The request puts the job in the <see cref="Common.JobState.Deleting"/> state.
        /// The Batch service will stop any running tasks and perform the actual job deletion without any further client action.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteJobAsync"/>.</para>
        /// </remarks>
        public void DeleteJob(string jobId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteJobAsync(jobId, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        internal IPagedEnumerable<CloudTask> ListTasksImpl(string jobId, BehaviorManager bhMgr, DetailLevel detailLevel)
        {
            PagedEnumerable<CloudTask> enumerable = new PagedEnumerable<CloudTask>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListTasksEnumerator typedEnumerator = new AsyncListTasksEnumerator(this, jobId, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<CloudTask> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }


        /// <summary>
        /// Enumerates the <see cref="CloudTask">tasks</see> of the specified job.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{CloudTask}"/> that can be used to enumerate tasks asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the tasks are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; tasks are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<CloudTask> ListTasks(
                                                        string jobId,
                                                        DetailLevel detailLevel = null,
                                                        IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            // get the enumerable
            IPagedEnumerable<CloudTask> enumerable = ListTasksImpl(jobId, bhMgr, detailLevel);

            return enumerable;
        }

        internal async Task<CloudTask> GetTaskAsyncImpl(
                                                                    string jobId,
                                                                    string taskId,
                                                                    BehaviorManager bhMgr,
                                                                    CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<Models.CloudTask, Models.TaskGetHeaders>> asyncTask =
                ParentBatchClient.ProtocolLayer.GetTask(
                    jobId,
                    taskId,
                    bhMgr,
                    cancellationToken);

            AzureOperationResponse<Models.CloudTask, Models.TaskGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // extract protocol task
            Models.CloudTask protoTask = response.Body;

            // bind CloudTask to protocol task
            CloudTask newTask = new CloudTask(ParentBatchClient, jobId, protoTask, bhMgr.BaseBehaviors);

            return newTask;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="jobId">The id of the job from which to get the task.</param>
        /// <param name="taskId">The id of the task to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="CloudTask"/> containing information about the specified Azure Batch task.</returns>
        /// <remarks>The get task operation runs asynchronously.</remarks>
        public Task<CloudTask> GetTaskAsync(
            string jobId,
            string taskId,
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors, detailLevel);

            Task<CloudTask> asyncTask = GetTaskAsyncImpl(jobId, taskId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="jobId">The id of the job from which to get the task.</param>
        /// <param name="taskId">The id of the task to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>A <see cref="CloudTask"/> containing information about the specified Azure Batch task.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetTaskAsync"/>.</remarks>
        public CloudTask GetTask(string jobId, string taskId, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<CloudTask> asyncTask = GetTaskAsync(jobId, taskId, detailLevel, additionalBehaviors);
            CloudTask newTask = asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);

            return newTask;
        }

        /// <summary>
        /// Enumerates the <see cref="SubtaskInformation">subtask information</see> of the specified task.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="taskId">The id of the task to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{SubtaskInformation}"/> that can be used to enumerate subtasks asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the tasks are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; tasks are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<SubtaskInformation> ListSubtasks(string jobId,
                                                        string taskId,
                                                        DetailLevel detailLevel = null,
                                                        IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            // get the enumerable
            IPagedEnumerable<SubtaskInformation> enumerable = ListSubtasksImpl(jobId, taskId, bhMgr, detailLevel);

            return enumerable;
        }

        internal async Task AddTaskAsyncImpl(
            string jobId,
            CloudTask taskToAdd,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken,
            ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts = null)
        {
            // only our implementation can be used to GetProtocolObject.
            CloudTask implTask = taskToAdd;

            if (null == implTask)
            {
                throw new ArgumentOutOfRangeException("taskToAdd");
            }

            // ensure we have artifacts
            if (null == allFileStagingArtifacts)
            {
                allFileStagingArtifacts = new ConcurrentDictionary<Type, IFileStagingArtifact>();
            }

            // start file staging
            Task stagingTask = implTask.StageFilesAsync(allFileStagingArtifacts);

            // wait for the files to be staged
            await stagingTask.ConfigureAwait(continueOnCapturedContext: false);

            // get the CloudTask to convert itself to a protocol object
            Models.TaskAddParameter protoTask = implTask.GetTransportObject();
            implTask.Freeze(); //Mark the underlying task readonly

            // start the AddTask request
            Task asyncTask = ParentBatchClient.ProtocolLayer.AddTask(jobId, protoTask, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Adds a single task to a job.  To add multiple tasks,
        /// use <see cref="AddTaskAsync(string,IEnumerable{CloudTask},BatchClientParallelOptions,ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}},TimeSpan?,IEnumerable{BatchClientBehavior})">JobOperations.AddTaskAsync</see>.
        /// </summary>
        /// <param name="jobId">The id of the job to which to add the task.</param>
        /// <param name="taskToAdd">The <see cref="CloudTask"/> to add.</param>
        /// <param name="allFileStagingArtifacts">An optional collection to customize and receive information about the file staging process (see <see cref="CloudTask.FilesToStage"/>).
        /// For more information see <see cref="IFileStagingArtifact"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>Each call to this method incurs a request to the Batch service. Therefore, using this method to add
        /// multiple tasks is less efficient than using a bulk add method, and can incur HTTP connection restrictions.
        /// If you are performing many of these operations in parallel and are seeing client side timeouts, please see 
        /// http://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit%28v=vs.110%29.aspx
        /// or use the multiple-task overload of AddTaskAsync.</para>
        /// <para>The add task operation runs asynchronously.</para>
        /// </remarks>
        public Task AddTaskAsync(
            string jobId,
            CloudTask taskToAdd,
            ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task asyncTask = AddTaskAsyncImpl(jobId, taskToAdd, bhMgr, cancellationToken, allFileStagingArtifacts);

            return asyncTask;
        }

        /// <summary>
        /// Adds a single task to a job.  To add multiple tasks,
        /// use <see cref="AddTask(string,IEnumerable{CloudTask},BatchClientParallelOptions,ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}},TimeSpan?,IEnumerable{BatchClientBehavior})">JobOperations.AddTaskAsync</see>.
        /// </summary>
        /// <param name="jobId">The id of the job to which to add the task.</param>
        /// <param name="taskToAdd">The <see cref="CloudTask"/> to add.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A collection of information about the file staging process (see <see cref="CloudTask.FilesToStage"/>).
        /// For more information see <see cref="IFileStagingArtifact"/>.</returns>
        /// <remarks>
        /// <para>Each call to this method incurs a request to the Batch service. Therefore, using this method to add
        /// multiple tasks is less efficient than using a bulk add method, and can incur HTTP connection restrictions.
        /// If you are performing many of these operations in parallel and are seeing client side timeouts, please see 
        /// http://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit%28v=vs.110%29.aspx
        /// or use the multiple-task overload of AddTask.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="AddTaskAsync(string, CloudTask, ConcurrentDictionary{Type, IFileStagingArtifact}, IEnumerable{BatchClientBehavior}, CancellationToken)"/>.</para>
        /// </remarks>
        public ConcurrentDictionary<Type, IFileStagingArtifact> AddTask(string jobId, CloudTask taskToAdd, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            ConcurrentDictionary<Type, IFileStagingArtifact> artifacts = new ConcurrentDictionary<Type, IFileStagingArtifact>();

            Task asyncTask = AddTaskAsync(jobId, taskToAdd, artifacts, additionalBehaviors);

            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);

            return artifacts;
        }

        internal IPagedEnumerable<NodeFile> ListNodeFilesImpl(
                                                        string jobId,
                                                        string taskId,
                                                        bool? recursive,
                                                        BehaviorManager bhMgr,
                                                        DetailLevel detailLevel)
        {
            PagedEnumerable<NodeFile> enumerable = new PagedEnumerable<NodeFile>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListNodeFilesByTaskEnumerator typedEnumerator = new AsyncListNodeFilesByTaskEnumerator(this, jobId, taskId, recursive, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<NodeFile> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        internal IPagedEnumerable<SubtaskInformation> ListSubtasksImpl(
                                                        string jobId,
                                                        string taskId,
                                                        BehaviorManager bhMgr,
                                                        DetailLevel detailLevel)
        {
            PagedEnumerable<SubtaskInformation> enumerable = new PagedEnumerable<SubtaskInformation>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListSubtasksEnumerator typedEnumerator = new AsyncListSubtasksEnumerator(this, jobId, taskId, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<SubtaskInformation> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Enumerates the <see cref="NodeFile">NodeFiles</see> in the specified task's directory on its compute node.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="recursive">If true, performs a recursive list of all files of the task. If false, returns only the files in the root task directory.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{NodeFile}"/> that can be used to enumerate files asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the file data is retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; file data is retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<NodeFile> ListNodeFiles(
                                                        string jobId,
                                                        string taskId,
                                                        bool? recursive = null,
                                                        DetailLevel detailLevel = null,
                                                        IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            // get the enumerable
            IPagedEnumerable<NodeFile> enumerable = ListNodeFilesImpl(jobId, taskId, recursive, bhMgr, detailLevel);

            return enumerable;
        }

        /// <summary>
        /// Terminates the specified task.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The terminate operation runs asynchronously.</remarks>
        public Task TerminateTaskAsync(
            string jobId,
            string taskId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task asyncTask = ParentBatchClient.ProtocolLayer.TerminateTask(jobId, taskId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Terminates the specified task.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>This is a blocking operation.  For a non-blocking equivalent, see <see cref="TerminateTaskAsync"/>.</remarks>
        public void TerminateTask(
            string jobId,
            string taskId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = TerminateTaskAsync(jobId, taskId, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);

        }

        /// <summary>
        /// Deletes the specified task.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The delete operation runs asynchronously.</remarks>
        public Task DeleteTaskAsync(
            string jobId,
            string taskId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task asyncTask = ParentBatchClient.ProtocolLayer.DeleteTask(jobId, taskId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Deletes the specified task.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation.  For a non-blocking equivalent, see <see cref="DeleteTaskAsync"/>.</remarks>
        public void DeleteTask(
            string jobId,
            string taskId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteTaskAsync(jobId, taskId, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Reactivates a task, allowing it to run again even if its retry count has been exhausted.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// Reactivation makes a task eligible to be retried again up to its maximum retry count.
        /// </para> 
        /// <para>
        /// Additionally, this will fail if the job is in the <see cref="JobState.Completed"/> or <see cref="JobState.Terminating"/> or <see cref="JobState.Deleting"/> state.
        /// This is a blocking operation. For a non-blocking equivalent, see <see cref="ReactivateTaskAsync"/>.
        /// </para>
        /// <para>
        /// The reactivate operation runs asynchronously.
        /// </para>
        /// </remarks>
        public Task ReactivateTaskAsync(
            string jobId,
            string taskId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task asyncTask = ParentBatchClient.ProtocolLayer.ReactivateTask(jobId, taskId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Reactivates a task, allowing it to run again even if its retry count has been exhausted.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>
        /// Reactivation makes a task eligible to be retried again up to its maximum retry count.
        /// </para> 
        /// <para>
        /// This operation will fail for tasks that are not completed or that previously completed successfully (with an exit code of 0).
        /// </para>
        /// <para>
        /// Additionally, this will fail if the job is in the <see cref="JobState.Completed"/> or <see cref="JobState.Terminating"/> or <see cref="JobState.Deleting"/> state.
        /// This is a blocking operation. For a non-blocking equivalent, see <see cref="ReactivateTaskAsync"/>.
        /// </para>
        /// </remarks>
        public void ReactivateTask(
            string jobId,
            string taskId,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = ReactivateTaskAsync(jobId, taskId, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        internal async Task<NodeFile> GetNodeFileAsyncImpl(
            string jobId,
            string taskId,
            string filePath,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var getNodeFilePropertiesTask = await ParentBatchClient.ProtocolLayer.GetNodeFilePropertiesByTask(
                jobId,
                taskId,
                filePath,
                bhMgr,
                cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            Models.NodeFile file = getNodeFilePropertiesTask.Body;

            // wrap protocol object
            NodeFile wrapped = new TaskFile(this, jobId, taskId, file, bhMgr.BaseBehaviors);

            return wrapped;
        }

        /// <summary>
        /// Gets the specified <see cref="NodeFile"/> from the specified task's directory on its compute node.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="NodeFile"/> representing the specified file.</returns>
        /// <remarks>The get file operation runs asynchronously.</remarks>
        public Task<NodeFile> GetNodeFileAsync(
            string jobId,
            string taskId,
            string filePath,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            Task<NodeFile> asyncTask = GetNodeFileAsyncImpl(jobId, taskId, filePath, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets the specified <see cref="NodeFile"/> from the specified task's directory on its compute node.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="NodeFile"/> representing the specified file.</returns>
        /// <remarks>This is a blocking operation.  For a non-blocking equivalent, see <see cref="GetNodeFileAsync"/>.</remarks>
        public NodeFile GetNodeFile(
            string jobId,
            string taskId,
            string filePath,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<NodeFile> asyncTask = GetNodeFileAsync(jobId, taskId, filePath, additionalBehaviors);
            NodeFile file = asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
            return file;
        }

        internal async Task CopyNodeFileContentToStreamAsyncImpl(
            string jobId,
            string taskId,
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            await ParentBatchClient.ProtocolLayer.GetNodeFileByTask(
                jobId,
                taskId,
                filePath,
                stream,
                byteRange,
                bhMgr,
                cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Copies the contents of a file from the specified task's directory on its compute node to the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="stream">The stream to copy the file contents to.</param>
        /// <param name="byteRange">A byte range defining what section of the file to copy. If omitted, the entire file is downloaded.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <remarks>The get file operation runs asynchronously.</remarks>
        public Task CopyNodeFileContentToStreamAsync(
            string jobId,
            string taskId,
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);
            return CopyNodeFileContentToStreamAsyncImpl(jobId, taskId, filePath, stream, byteRange, bhMgr, cancellationToken);
        }

        /// <summary>
        /// Copies the contents of a file from the specified task's directory on its compute node to the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="stream">The stream to copy the file contents to.</param>
        /// <param name="byteRange">A byte range defining what section of the file to copy. If omitted, the entire file is downloaded.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation.  For a non-blocking equivalent, see <see cref="CopyNodeFileContentToStreamAsync"/>.</remarks>
        public void CopyNodeFileContentToStream(
            string jobId,
            string taskId,
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = CopyNodeFileContentToStreamAsync(jobId, taskId, filePath, stream, byteRange, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        internal Task<string> CopyNodeFileContentToStringAsyncImpl(
            string jobId,
            string taskId,
            string filePath,
            Encoding encoding,
            GetFileRequestByteRange byteRange,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            return UtilitiesInternal.ReadNodeFileAsStringAsync(
                // Note that behaviors is purposefully dropped in the below call since it's already managed by the bhMgr
                (stream, bRange, behaviors, ct) => CopyNodeFileContentToStreamAsyncImpl(jobId, taskId, filePath, stream, bRange, bhMgr, ct),
                encoding,
                byteRange,
                additionalBehaviors: null,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Reads the contents of a file from the specified task's directory on its compute node into a string.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="encoding">The encoding to use. If no value or null is specified, UTF8 is used.</param>
        /// <param name="byteRange">A byte range defining what section of the file to copy. If omitted, the entire file is downloaded.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>The contents of the file, as a string</returns>
        public Task<string> CopyNodeFileContentToStringAsync(
            string jobId,
            string taskId,
            string filePath,
            Encoding encoding = null,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);
            return CopyNodeFileContentToStringAsyncImpl(jobId, taskId, filePath, encoding, byteRange, bhMgr, cancellationToken);
        }

        /// <summary>
        /// Reads the contents of a file from the specified task's directory on its compute node into a string.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="encoding">The encoding to use. If no value or null is specified, UTF8 is used.</param>
        /// <param name="byteRange">A byte range defining what section of the file to copy. If omitted, the entire file is downloaded.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>The contents of the file, as a string</returns>
        public string CopyNodeFileContentToString(
            string jobId,
            string taskId,
            string filePath,
            Encoding encoding = null,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<string> asyncTask = CopyNodeFileContentToStringAsync(jobId, taskId, filePath, encoding, byteRange, additionalBehaviors);
            return asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Deletes the specified file from the task's directory on its compute node.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="filePath">The path of the file to delete.</param>
        /// <param name="recursive">
        /// If the file-path parameter represents a directory instead of a file, you can set the optional 
        /// recursive parameter to true to delete the directory and all of the files and subdirectories in it. If recursive is false 
        /// then the directory must be empty or deletion will fail.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The delete operation runs asynchronously.</remarks>
        public async Task DeleteNodeFileAsync(
            string jobId,
            string taskId,
            string filePath,
            bool? recursive = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            var asyncTask = ParentBatchClient.ProtocolLayer.DeleteNodeFileByTask(
                jobId,
                taskId,
                filePath,
                recursive,
                bhMgr,
                cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes the specified file from the task's directory on its compute node.
        /// </summary>
        /// <param name="jobId">The id of the job containing the task.</param>
        /// <param name="taskId">The id of the task.</param>
        /// <param name="filePath">The path of the file to delete.</param>
        /// <param name="recursive">
        /// If the file-path parameter represents a directory instead of a file, you can set the optional 
        /// recursive parameter to true to delete the directory and all of the files and subdirectories in it. If recursive is false 
        /// then the directory must be empty or deletion will fail.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>This is a blocking operation.  For a non-blocking equivalent, see <see cref="DeleteNodeFileAsync"/>.</remarks>
        public void DeleteNodeFile(
            string jobId,
            string taskId,
            string filePath,
            bool? recursive = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteNodeFileAsync(jobId, taskId, filePath, recursive, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        internal Task AddTaskAsyncImpl(
            string jobId,
            IEnumerable<CloudTask> tasksToAdd,
            BatchClientParallelOptions parallelOptions,
            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> fileStagingArtifacts,
            TimeSpan? timeout,
            BehaviorManager behaviorManager)
        {
            AddTasksWorkflowManager addTasksWorkflowManager = new AddTasksWorkflowManager(
                this,
                jobId,
                parallelOptions,
                fileStagingArtifacts,
                behaviorManager);

            return addTasksWorkflowManager.AddTasksAsync(tasksToAdd, timeout);
        }

        /// <summary>
        /// Adds tasks to a job.
        /// </summary>
        /// <param name="jobId">The id of the job to which to add the tasks.</param>
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
        /// the parallelOptions) and are seeing client side timeouts, please see 
        /// http://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit%28v=vs.110%29.aspx .</para>
        /// <para>The progress of the operation in the face of errors is determined by <see cref="AddTaskCollectionResultHandler"/> behavior.
        /// You do not normally need to specify this behavior, as the Batch client uses a default which works in normal circumstances.
        /// If you do want to customize this behavior, specify an AddTaskCollectionResultHandler in the <see cref="CustomBehaviors"/>
        /// or <paramref name="additionalBehaviors"/> collections.</para>
        /// </remarks>
        /// <exception cref="ParallelOperationsException">Thrown if one or more requests to the Batch service fail.</exception>
        public async Task AddTaskAsync(
            string jobId,
            IEnumerable<CloudTask> tasksToAdd,
            BatchClientParallelOptions parallelOptions = null,
            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> fileStagingArtifacts = null,
            TimeSpan? timeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            await AddTaskAsyncImpl(
                jobId,
                tasksToAdd,
                parallelOptions,
                fileStagingArtifacts,
                timeout,
                bhMgr).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Adds tasks to a job.
        /// </summary>
        /// <param name="jobId">The id of the job to which to add the tasks.</param>
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
        /// <para>This is a blocking operation; for a non-blocking equivalent, see <see cref="AddTaskAsync(string, IEnumerable{CloudTask}, BatchClientParallelOptions, ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}}, TimeSpan?, IEnumerable{BatchClientBehavior})"/>.</para>
        /// <para>This method is not atomic; that is, it is possible for the method to start adding tasks and
        /// then fail. The collection of tasks to add is broken down into chunks of size at most <see cref="Constants.MaxTasksInSingleAddTaskCollectionRequest"/>,
        /// and an AddTaskCollection request is issued for each chunk.  Requests may be issued in parallel according to
        /// the <paramref name="parallelOptions"/>.</para>
        /// <para>Issuing a large number of simultaneous requests to the Batch service can incur HTTP connection restrictions.
        /// If you are performing many of these operations in parallel (or have specified a large MaxDegreeOfParallelism in
        /// the parallelOptions) and are seeing client side timeouts, please see 
        /// http://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit%28v=vs.110%29.aspx .</para>
        /// <para>The progress of the operation in the face of errors is determined by <see cref="AddTaskCollectionResultHandler"/> behavior.
        /// You do not normally need to specify this behavior, as the Batch client uses a default which works in normal circumstances.
        /// If you do want to customize this behavior, specify an AddTaskCollectionResultHandler in the <see cref="CustomBehaviors"/>
        /// or <paramref name="additionalBehaviors"/> collections.</para>
        /// </remarks>
        /// <exception cref="ParallelOperationsException">Thrown if one or more requests to the Batch service fail.</exception>
        public void AddTask(
            string jobId,
            IEnumerable<CloudTask> tasksToAdd,
            BatchClientParallelOptions parallelOptions = null,
            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> fileStagingArtifacts = null,
            TimeSpan? timeout = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = AddTaskAsync(
                jobId,
                tasksToAdd,
                parallelOptions,
                fileStagingArtifacts,
                timeout,
                additionalBehaviors);

            asyncTask.WaitAndUnaggregateException(CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Enumerates the status of <see cref="CloudJob.JobPreparationTask"/> and <see cref="CloudJob.JobReleaseTask"/> tasks for the specified job.
        /// </summary>
        /// <param name="jobId">The id of the job.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{JobPreparationAndReleaseTaskExecutionInformation}"/> that can be used to enumerate statuses asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the statuses are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; statuses are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<JobPreparationAndReleaseTaskExecutionInformation> ListJobPreparationAndReleaseTaskStatus(string jobId, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(CustomBehaviors, additionalBehaviors);

            PagedEnumerable<JobPreparationAndReleaseTaskExecutionInformation> enumerable = new PagedEnumerable<JobPreparationAndReleaseTaskExecutionInformation>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListJobPrepReleaseTaskStatusEnumerator typedEnumerator = new AsyncListJobPrepReleaseTaskStatusEnumerator(this, jobId, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<JobPreparationAndReleaseTaskExecutionInformation> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        #endregion // JobOperations

        #region // internal/private

        internal BatchClient ParentBatchClient { get; set; }

        #endregion // internal/private
    }
}
