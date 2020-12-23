// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch.FileStaging;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// Manages the AddTasks workflow, performs multiple CloudTaskAdd requests, and handles retries/exception handling.
    /// </summary>
    internal class AddTasksWorkflowManager
    {
        private readonly JobOperations _jobOperations;
        private readonly string _jobId;
        private readonly ConcurrentQueue<TrackedCloudTask> _remainingTasksToAdd;
        private readonly List<Func<AddTaskResult, CancellationToken, AddTaskResultStatus>> _addTaskResultHandlerCollection;
        private readonly BatchClientParallelOptions _parallelOptions;
        private readonly List<Task> _pendingAsyncOperations;
        private readonly ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> _customerVisibleFileStagingArtifacts;
        private readonly BehaviorManager _behaviorManager;
        private DateTime _timeToTimeoutAt;
        private int _hasRun; //Have to use an int because CompareExchange doesn't support bool
        private int _maxTasks;

        private const int HasNotRun = 0;
        private const int HasRun = 1;

        /// <summary>
        /// Creates the AddTasks workflow manager with the specified arguments.
        /// </summary>
        /// <param name="jobOperations"></param>
        /// <param name="jobId"></param>
        /// <param name="parallelOptions">The parallel options associated with this operation.  If this is null, the default is used.</param>
        /// <param name="fileStagingArtifacts">File staging artifacts associated with this operation.  If the customer does not set this, it is unviewable by them.</param>
        /// <param name="bhMgr">The behavior manager.</param>
        internal AddTasksWorkflowManager(
            JobOperations jobOperations,
            string jobId,
            BatchClientParallelOptions parallelOptions,
            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> fileStagingArtifacts,
            BehaviorManager bhMgr)
        {
            //
            // Setup some defaults for the parameters if they were null
            //
            if (parallelOptions == null)
            {
                parallelOptions = new BatchClientParallelOptions();
            }

            //
            // Set up the data structures associated with this workflow
            //
            this._jobOperations = jobOperations;
            this._jobId = jobId;
            this._remainingTasksToAdd = new ConcurrentQueue<TrackedCloudTask>();
            this._addTaskResultHandlerCollection = new List<Func<AddTaskResult, CancellationToken, AddTaskResultStatus>>();
            this._parallelOptions = parallelOptions;
            this._pendingAsyncOperations = new List<Task>();
            this._customerVisibleFileStagingArtifacts = fileStagingArtifacts ?? new ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>>();
            this._behaviorManager = bhMgr;
            this._maxTasks = Constants.MaxTasksInSingleAddTaskCollectionRequest;
            this._hasRun = HasNotRun; //Has not run by default

            //Read the behavior manager and populate the collection
            List<AddTaskCollectionResultHandler> behaviorList = this._behaviorManager.GetBehaviors<AddTaskCollectionResultHandler>();
            foreach (AddTaskCollectionResultHandler handler in behaviorList)
            {
                this._addTaskResultHandlerCollection.Add(handler.ResultHandler);
            }

            //Validation that there is a handler for AddTaskResult
            if (this._addTaskResultHandlerCollection.Count == 0)
            {
                throw new BatchClientException(
                    string.Format(CultureInfo.InvariantCulture, BatchErrorMessages.GeneralBehaviorMissing, typeof(AddTaskCollectionResultHandler)));
            }
        }

#region Public methods

        public async System.Threading.Tasks.Task AddTasksAsync(IEnumerable<CloudTask> tasksToAdd, TimeSpan? timeout = null)
        {
            //Ensure that this object has not already been used
            int original = Interlocked.CompareExchange(ref this._hasRun, HasRun, HasNotRun);

            if (original != HasNotRun)
            {
                throw new RunOnceException(string.Format(CultureInfo.InvariantCulture, BatchErrorMessages.CanOnlyBeRunOnceFailure, this.GetType().Name));
            }

            //Determine what time to timeout at
            if (timeout != null)
            {
                this._timeToTimeoutAt = DateTime.UtcNow + timeout.Value;
            }
            else
            {
                //TODO: We set this to max value -- maybe in the future we can be a bit more friendly to customers and not run forever
                this._timeToTimeoutAt = DateTime.MaxValue;
            }

            //
            // Collect the tasks and add them to the pending queue
            //
            //TODO: There is a tension between allowing lazy enumeration of tasksToAdd and performing any validation on tasksToAdd early in the addition process
            //TODO: For now (since most customer implementations are not going to write their own lazy collection) we go ahead and perform
            //TODO: some input validation...

            //
            // Perform some basic input validation
            //
            //TODO: Check no duplicate task names?
            //TODO: Check the tasks are not children of some other object already

            //Enumerate the supplied collection asynchronously if required
            tasksToAdd = await UtilitiesInternal.EnumerateIfNeededAsync(tasksToAdd, this._parallelOptions.CancellationToken).ConfigureAwait(false);

            //TODO: For now perform a copy into a queue -- in the future consider honoring lazy loading and do this later
            foreach (CloudTask cloudTask in tasksToAdd)
            {
                if (cloudTask == null)
                {
                    throw new ArgumentNullException(nameof(tasksToAdd), BatchErrorMessages.CollectionMustNotContainNull);
                }

                if (cloudTask.BindingState == BindingState.Bound)
                {
                    throw UtilitiesInternal.OperationForbiddenOnBoundObjects;
                }

                this._remainingTasksToAdd.Enqueue(new TrackedCloudTask(this._jobId, this._jobOperations, cloudTask));
            }

            //
            // Fire the requests
            //
            while (!this.IsWorkflowDone())
            {
                //Wait for an open request "slot" (an existing request to complete) if:
                //1. We have no free request slots
                //2. We have no more tasks to add and there are ongoing pending operations which could result in task add retries (causing us to get more tasks to add)
                bool noFreeSlots = this._pendingAsyncOperations.Count >= this._parallelOptions.MaxDegreeOfParallelism;
                bool noTasksToAddButSomePendingLegsRemain = this._remainingTasksToAdd.IsEmpty && this._pendingAsyncOperations.Count > 0;
                if (noFreeSlots || noTasksToAddButSomePendingLegsRemain)
                {
                    await this.ProcessPendingOperationResults().ConfigureAwait(continueOnCapturedContext: false);
                }

                //If we get here, we are starting a single new leg.  Another iteration of this loop will get to any tasks which do not fit in this leg.

                //Add any tasks (up to max count in 1 request) which are remaining since we have an open parallel slot
                Dictionary<string, TrackedCloudTask> nameToTaskMapping = new Dictionary<string, TrackedCloudTask>();

                //Attempt to take some items from the set of tasks remaining to be added and prepare it to be added
                int tmpMaxTasks = this._maxTasks;
                while (nameToTaskMapping.Count < tmpMaxTasks && this._remainingTasksToAdd.TryDequeue(out TrackedCloudTask taskToAdd))
                {
                    nameToTaskMapping.Add(taskToAdd.Task.Id, taskToAdd);
                }

                if (nameToTaskMapping.Count > 0)
                {
                    //Start the async operation to stage the files (if required) and issue the protocol add task request
                    Task asyncTask = this.StageFilesAndAddTasks(
                        nameToTaskMapping,
                        null);

                    //Add the request to the operation tracker
                    this._pendingAsyncOperations.Add(asyncTask);
                }
            }

            //If we reach here, we have succeeded - yay!
        }

#endregion

#region Private methods

        /// <summary>
        /// Checks for operation cancelation or timeout, and throws the corresponding exception.
        /// </summary>
        private void CheckForCancellationOrTimeoutAndThrow()
        {
            //We always throw when cancelation is requested
            this._parallelOptions.CancellationToken.ThrowIfCancellationRequested();


            DateTime currentTime = DateTime.UtcNow;

            if (currentTime > this._timeToTimeoutAt)
            {
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// Determines if the workflow has finished or not.
        /// </summary>
        /// <returns>True if the workflow has successfully completed, false if it has not.</returns>
        private bool IsWorkflowDone()
        {
            return !(!this._remainingTasksToAdd.IsEmpty || this._pendingAsyncOperations.Count > 0);
        }

        /// <summary>
        /// Performs file staging and also issues the AddTaskCollection request for the set of tasks to add.
        /// </summary>
        /// <param name="tasksToAdd">The set of tasks to add.</param>
        /// <param name="namingFragment"></param>
        /// <returns></returns>
        private async Task StageFilesAndAddTasks(
            Dictionary<string, TrackedCloudTask> tasksToAdd,
            string namingFragment)
        {
            List<Models.TaskAddParameter> protoTasksToAdd = new List<Models.TaskAddParameter>();

            this.CheckForCancellationOrTimeoutAndThrow();

            //
            // Perform file staging
            //

            // list of all files to be staged across all Tasks
            List<IFileStagingProvider> allFiles = new List<IFileStagingProvider>();

            // collect all files to be staged
            foreach (TrackedCloudTask trackedCloudTask in tasksToAdd.Values)
            {
                if (trackedCloudTask.Task.FilesToStage != null)
                {
                    // add in the files for the current task
                    allFiles.AddRange(trackedCloudTask.Task.FilesToStage);
                }
            }

            //This dictonary is only for the purpose of this batch add
            ConcurrentDictionary<Type, IFileStagingArtifact> legStagingArtifacts = new ConcurrentDictionary<Type, IFileStagingArtifact>();

            //Add the file staging artifacts for this let to the overall bag so as to allow customers to track the file staging progress
            this._customerVisibleFileStagingArtifacts.Add(legStagingArtifacts);

            // now we have all files, send off to file staging machine
            System.Threading.Tasks.Task fileStagingTask = FileStagingUtils.StageFilesAsync(allFiles, legStagingArtifacts, namingFragment);

            // wait for file staging async task
            await fileStagingTask.ConfigureAwait(continueOnCapturedContext: false);

            // now update each non-finalized Task with its new ResourceFiles
            foreach (TrackedCloudTask taskToAdd in tasksToAdd.Values)
            {
                //Update the resource files if the task hasn't already been finalized
                if (taskToAdd.Task.FilesToStage != null)
                {
                    foreach (IFileStagingProvider curFile in taskToAdd.Task.FilesToStage)
                    {
                        IEnumerable<ResourceFile> curStagedFiles = curFile.StagedFiles;

                        if (null != curStagedFiles && !((IReadOnly)taskToAdd.Task).IsReadOnly)
                        {
                            //TODO: There is a threading issue here -- lock this property down somehow?
                            if (taskToAdd.Task.ResourceFiles == null)
                            {
                                taskToAdd.Task.ResourceFiles = new List<ResourceFile>();
                            }

                            foreach (ResourceFile curStagedFile in curStagedFiles)
                            {
                                taskToAdd.Task.ResourceFiles.Add(curStagedFile);
                            }
                        }
                    }

                    //Mark the file staging collection as read only just incase there's another reference to it
                    ConcurrentChangeTrackedList<IFileStagingProvider> filesToStageListImpl =
                        taskToAdd.Task.FilesToStage as ConcurrentChangeTrackedList<IFileStagingProvider>;

                    filesToStageListImpl.IsReadOnly = true; //Set read only
                }

                Models.TaskAddParameter protoTask = taskToAdd.GetProtocolTask();
                protoTasksToAdd.Add(protoTask);
            }

            this.CheckForCancellationOrTimeoutAndThrow();

            //
            // Fire the protocol add collection request
            //
            try
            {
                var asyncTask = this._jobOperations.ParentBatchClient.ProtocolLayer.AddTaskCollection(
                    this._jobId,
                    protoTasksToAdd,
                    this._behaviorManager,
                    this._parallelOptions.CancellationToken);

                var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
                //
                // Process the results of the add task collection request
                //
                this.ProcessProtocolAddTaskResults(response.Body.Value, tasksToAdd);
            }
            catch(Common.BatchException e)
            {
                if (e.InnerException is Models.BatchErrorException exception)
                {
                    Models.BatchError error = exception.Body;
                    int currLength = tasksToAdd.Count;
                    if (error.Code == Common.BatchErrorCodeStrings.RequestBodyTooLarge && currLength != 1)
                    {
                        // Our chunk sizes were too large to fit in a request, so universally reduce size
                        // This is an internal error due to us using greedy initial maximum chunk size,
                        //   so do not increment retry counter.
                        {
                            int newLength = currLength / 2;
                            int tmpMaxTasks = this._maxTasks;
                            while (newLength < tmpMaxTasks)
                            {
                                tmpMaxTasks = Interlocked.CompareExchange(ref this._maxTasks, newLength, tmpMaxTasks);
                            }
                            foreach (TrackedCloudTask trackedTask in tasksToAdd.Values)
                            {
                                this._remainingTasksToAdd.Enqueue(trackedTask);
                            }
                            return;
                        }
                    }
                }
                throw;
            }
        }

        /// <summary>
        /// Processes a set AddTaskResults from the protocol and groups them according to the results of the AddTaskResultHandler
        /// </summary>
        /// <param name="addTaskResults"></param>
        /// <param name="taskMap">Dictionary of task name to task object instance for the specific protocol response.</param>
        private void ProcessProtocolAddTaskResults(
            IEnumerable<Protocol.Models.TaskAddResult> addTaskResults,
            IReadOnlyDictionary<string, TrackedCloudTask> taskMap)
        {
            foreach (Protocol.Models.TaskAddResult protoAddTaskResult in addTaskResults)
            {
                string taskId = protoAddTaskResult.TaskId;
                TrackedCloudTask trackedTask = taskMap[taskId];

                AddTaskResult omResult = new AddTaskResult(trackedTask.Task, trackedTask.RetryCount, protoAddTaskResult);

                //We know that there must be at least one AddTaskResultHandler so the below ForEach will always be called
                //at least once.
                AddTaskResultStatus status = AddTaskResultStatus.Success; //The default is success to avoid infinite retry

                //Call the customer defined result handler
                foreach (var resultHandlerFunction in this._addTaskResultHandlerCollection)
                {
                    status = resultHandlerFunction(omResult, this._parallelOptions.CancellationToken);
                }

                if (status == AddTaskResultStatus.Retry)
                {
                    //Increment retry count
                    trackedTask.IncrementRetryCount();

                    //TODO: There is nothing stopping the user from marking all tasks as Retry and never exiting this work flow...
                    //TODO: In that case maybe we should forcibly abort them after some # of attempts?
                    this._remainingTasksToAdd.Enqueue(trackedTask);
                }
            }
        }

        /// <summary>
        /// Waits for a pending operation to complete and throws if the operation failed.
        /// </summary>
        /// <returns></returns>
        private async Task ProcessPendingOperationResults()
        {
            //Wait for any task to complete
            Task completedTask = await Task.WhenAny(this._pendingAsyncOperations).ConfigureAwait(continueOnCapturedContext: false);

            //Check for a task failure -- if there is one, we a-wait for all remaining tasks to complete (this will throw an exception since at least one of them failed).
            if (completedTask.IsFaulted)
            {
                await WaitForTasksAndThrowParallelOperationsExceptionAsync(this._pendingAsyncOperations).ConfigureAwait(continueOnCapturedContext: false);
            }
            else
            {
                await completedTask.ConfigureAwait(continueOnCapturedContext: false); //This await should finish immediately and will not fail since the task has not faulted

                //Remove the task which completed
                this._pendingAsyncOperations.Remove(completedTask);
            }
        }

        private static async Task WaitForTasksAndThrowParallelOperationsExceptionAsync(List<Task> tasks)
        {
            //We know that this will throw, but we want to catch the exception so that we can provide a better aggregate exception experience for users
            try
            {
                //NOTE: This try block should only do a WhenAll and nothing else, since the exception thrown in this try is discarded.
                await Task.WhenAll(tasks).ConfigureAwait(continueOnCapturedContext: false); //This will throw and terminate the workflow
            }
            catch (Exception)
            {
                //Swallow the exception and throw a new one

                IEnumerable<Exception> exceptions = tasks.Where(t => t.IsFaulted).SelectMany(t => t.Exception.InnerExceptions);
                throw new ParallelOperationsException(BatchErrorMessages.MultipleParallelRequestsHitUnexpectedErrors, exceptions);
            }
        }

#endregion

#region Private classes

        /// <summary>
        /// Internal task wrapper which tracks a tasks retry count and holds a reference to the protocol object and CloudTask.
        /// </summary>
        private class TrackedCloudTask
        {
            public string JobId { get; private set; }
            public CloudTask Task { get; private set; }
            public int RetryCount { get; private set; }
            public JobOperations JobOperations { get; private set; }

            private Models.TaskAddParameter ProtocolTask { get; set; }

            internal TrackedCloudTask(
                string jobId,
                JobOperations jobOperations,
                CloudTask cloudTask)
            {
                this.Task = cloudTask;
                this.JobId = jobId;
                this.JobOperations = jobOperations;  // matt-c: do we really need one of these in every instance?  Even when they were wiMgrs couldnt something outside keep a reference?
                this.RetryCount = 0;
            }

            public void IncrementRetryCount()
            {
                this.RetryCount++;
            }

            /// <summary>
            /// Gets the finalized version of this task.  Also internally updates this.Task to refer to a bound read-only copy of the original
            /// CloudTask.  Subsequent calls to this method will return a reference to the same object
            /// </summary>
            /// <returns></returns>
            public Models.TaskAddParameter GetProtocolTask()
            {
                if (this.ProtocolTask == null)
                {
                    this.ProtocolTask = this.Task.GetTransportObject();
                    this.Task.Freeze(); //Mark the underlying task readonly
                }

                return this.ProtocolTask;
            }
        }

#endregion

    }
}
