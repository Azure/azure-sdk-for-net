// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Azure;
using static Azure.Core.HttpHeader;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Manages the workflow for adding tasks to a job in parallel.
    /// </summary>
    internal class TasksWorkflowManager
    {
        private readonly BatchClient _batchClient;
        private readonly string _jobId;
        private DateTime _timeToTimeoutAt;
        private readonly CreateTasksOptions _parallelOptions;
        private readonly ConcurrentQueue<TrackedBatchTask> _remainingTasksToAdd;
        private readonly List<Task> _pendingAsyncOperations;
        private readonly TaskResultHandler _bulkTaskCollectionResultHandler;
        private int _hasRun; //Have to use an int because CompareExchange doesn't support bool
        private int _maxTasks;
        private TimeSpan _timeBetweenCalls;
        private int _timeIncrementInSeconds = 5;
        private int _maxTimeBetweenCallsInSeconds = 30;
        private const int HasNotRun = 0;
        private const int HasRun = 1;
        private bool _returnBatchTaskAddResults = false;
        private readonly ConcurrentBag<BatchTaskCreateResult> _taskAddResults;
        private readonly object _createTasksResultLock = new object();
        private CreateTasksResult _createTasksResult;
        private CancellationToken _cancellationToken;

        internal void increaseCreateTasksResultPass()
        {
            lock (_createTasksResultLock)
            {
                _createTasksResult.PassCount++;
            }
        }

        internal void increaseCreateTasksResultFail()
        {
            lock (_createTasksResultLock)
            {
                _createTasksResult.FailCount++;
            }
        }

        /// <summary>
        /// Creates the AddTasks workflow manager with the specified arguments.
        /// </summary>
        /// <param name="batchClient"></param>
        /// <param name="jobId"></param>
        /// <param name="createTasksOptions">The parallel options associated with this operation.  If this is null, the default is used.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal TasksWorkflowManager(
            BatchClient batchClient,
            string jobId,
            CreateTasksOptions createTasksOptions = null,
            CancellationToken cancellationToken = default(CancellationToken)
            )
        {
            //
            // Setup some defaults for the parameters if they were null
            //
            if (createTasksOptions == null)
            {
                createTasksOptions = new CreateTasksOptions();
            }

            if (createTasksOptions.CreateTaskResultHandler == null)
            {
                createTasksOptions.CreateTaskResultHandler = new DefaultCreateTaskResultHandler();
            }

            _batchClient = batchClient;
            _jobId = jobId;
            _cancellationToken = cancellationToken;
            _remainingTasksToAdd = new ConcurrentQueue<TrackedBatchTask>();
            _taskAddResults = new ConcurrentBag<BatchTaskCreateResult>();
            _createTasksResult = new CreateTasksResult(new List<BatchTaskCreateResult>());
            _hasRun = HasNotRun;
            _maxTasks = 100;
            _returnBatchTaskAddResults = createTasksOptions.ReturnBatchTaskCreateResults;
            _pendingAsyncOperations = new List<Task>();
            _parallelOptions = createTasksOptions;
            _timeBetweenCalls = TimeSpan.FromMilliseconds(100);
            _bulkTaskCollectionResultHandler = createTasksOptions.CreateTaskResultHandler;
            _maxTimeBetweenCallsInSeconds = createTasksOptions.MaxTimeBetweenCallsInSeconds;
        }

        /// <summary>
        /// Adds a set of tasks to the job in parallel.
        /// </summary>
        /// <param name="tasksToAdd"></param>
        /// <param name="jobId"></param>
        /// <param name="timeOutInSeconds"></param>
        /// <exception cref="RunOnceException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal CreateTasksResult AddTasks(IEnumerable<BatchTaskCreateOptions> tasksToAdd, string jobId, TimeSpan? timeOutInSeconds = null)
        {
#pragma warning disable AZC0106 // Non-public asynchronous method needs 'async' parameter.
            Task<CreateTasksResult> task = AddTasksAsync(tasksToAdd, jobId, timeOutInSeconds);

            task.Wait();
            return task.Result;
#pragma warning restore AZC0106 // Non-public asynchronous method needs 'async' parameter.
        }
        /// <summary>
        /// Adds a set of tasks to the job in parallel.
        /// </summary>
        /// <param name="tasksToAdd"></param>
        /// <param name="timeOutInSeconds"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        /// <exception cref="RunOnceException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal async System.Threading.Tasks.Task<CreateTasksResult> AddTasksAsync(IEnumerable<BatchTaskCreateOptions> tasksToAdd, string jobId, TimeSpan? timeOutInSeconds = null)
        {
            //Ensure that this object has not already been used
            int original = Interlocked.CompareExchange(ref this._hasRun, HasRun, HasNotRun);

            if (original != HasNotRun)
            {
                throw new RunOnceException(string.Format(CultureInfo.InvariantCulture, BatchErrorCode.CanOnlyBeRunOnceFailure.ToString(), this.GetType().Name));
            }

            if (tasksToAdd == null)
            {
                throw new ArgumentNullException(nameof(tasksToAdd));
            }
            if (timeOutInSeconds.HasValue)
            {
                _timeToTimeoutAt = DateTime.UtcNow.Add(timeOutInSeconds.Value);
            }
            else
            {
                //TODO: We set this to max value -- maybe in the future we can be a bit more friendly to customers and not run forever
                this._timeToTimeoutAt = DateTime.MaxValue;
            }

            foreach (var task in tasksToAdd)
            {
                _remainingTasksToAdd.Enqueue(new TrackedBatchTask(jobId, task));
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
                Dictionary<string, TrackedBatchTask> nameToTaskMapping = new Dictionary<string, TrackedBatchTask>();

                //Attempt to take some items from the set of tasks remaining to be added and prepare it to be added
                int tmpMaxTasks = this._maxTasks;
                while (nameToTaskMapping.Count < tmpMaxTasks && this._remainingTasksToAdd.TryDequeue(out TrackedBatchTask taskToAdd))
                {
                    nameToTaskMapping.Add(taskToAdd.Task.Id, taskToAdd);
                }

                if (nameToTaskMapping.Count > 0)
                {
                    //Start the async operation to stage the files (if required) and issue the protocol add task request
                    Task asyncTask = this.AddTasks(
                        nameToTaskMapping,
                        jobId);

                    //Add the request to the operation tracker
                    this._pendingAsyncOperations.Add(asyncTask);
                }
                //If we reach here, we have succeeded - yay!
            }

            // Wait for all pending operations to complete
            await Task.WhenAll(this._pendingAsyncOperations).ConfigureAwait(continueOnCapturedContext: false);

            _createTasksResult.BatchTaskCreateResults.AddRange(_taskAddResults.ToList());
            return _createTasksResult;
        }

        /// <summary>
        /// Performs file staging and also issues the AddTaskCollection request for the set of tasks to add.
        /// </summary>
        /// <param name="tasksToAdd">The set of tasks to add.</param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        internal async Task AddTasks(
            Dictionary<string, TrackedBatchTask> tasksToAdd,
            string jobId)
        {
            BatchTaskGroup taskGroup = new BatchTaskGroup(tasksToAdd.Values.Select(t => t.Task));

            this.CheckForCancellationOrTimeoutAndThrow();

            try
            {
                await Task.Delay(_timeBetweenCalls).ConfigureAwait(continueOnCapturedContext: false); // Wait for the time length of _timeBetweenCalls

                var asyncTask = this._batchClient.CreateTaskCollectionAsync(
                    jobId: jobId,
                    taskCollection: taskGroup,
                    cancellationToken: _cancellationToken);

                BatchCreateTaskCollectionResult response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
                //
                // Process the results of the add task collection request
                //
                this.ProcessAddTaskResults(response, tasksToAdd);
            }
            catch (RequestFailedException e)
            {
                int currLength = tasksToAdd.Count;
                if (e.ErrorCode == BatchErrorCode.RequestBodyTooLarge && currLength != 1)
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
                            foreach (TrackedBatchTask trackedTask in tasksToAdd.Values)
                            {
                                this._remainingTasksToAdd.Enqueue(trackedTask);
                            }
                            return;
                        }
                    }
                else if (e.ErrorCode == BatchErrorCode.TooManyRequests)
                    {
                        _timeBetweenCalls = TimeSpan.FromSeconds(Math.Min(_timeBetweenCalls.TotalSeconds + _timeIncrementInSeconds, _maxTimeBetweenCallsInSeconds));
                        foreach (TrackedBatchTask trackedTask in tasksToAdd.Values)
                        {
                            this._remainingTasksToAdd.Enqueue(trackedTask);
                        }
                        return;
                    }
            }
        }

        /// <summary>
        /// Processes a set AddTaskResults from the protocol and groups them according to the results of the AddTaskResultHandler
        /// </summary>
        /// <param name="addTaskResults"></param>
        /// <param name="taskMap">Dictionary of task name to task object instance for the specific protocol response.</param>
        internal void ProcessAddTaskResults(
            BatchCreateTaskCollectionResult addTaskResults,
            IReadOnlyDictionary<string, TrackedBatchTask> taskMap)
        {
            foreach (BatchTaskCreateResult protoAddTaskResult in addTaskResults.Values)
            {
                string taskId = protoAddTaskResult.TaskId;
                TrackedBatchTask trackedTask = taskMap[taskId];

                CreateTaskResult omResult = new CreateTaskResult(trackedTask.Task, trackedTask.RetryCount, protoAddTaskResult);

                //We know that there must be at least one AddTaskResultHandler so the below ForEach will always be called
                //at least once.
                CreateTaskResultStatus status = CreateTaskResultStatus.Success; //The default is success to avoid infinite retry

                status = _bulkTaskCollectionResultHandler.CreateTaskResultHandler(omResult, _cancellationToken);

                if (status == CreateTaskResultStatus.Retry)
                {
                    //Increment retry count
                    trackedTask.IncrementRetryCount();

                    //TODO: There is nothing stopping the user from marking all tasks as Retry and never exiting this work flow...
                    //TODO: In that case maybe we should forcibly abort them after some # of attempts?
                    this._remainingTasksToAdd.Enqueue(trackedTask);
                }
                else if (status == CreateTaskResultStatus.Success)
                {
                    increaseCreateTasksResultPass();
                    //If the status is not retry, then we are done with this task
                    if (_returnBatchTaskAddResults)
                    {
                        _taskAddResults.Add(protoAddTaskResult);
                    }
                }
                else // passing
                {
                    //If the status is failure, then we are done with this task
                    increaseCreateTasksResultFail();
                    if (_returnBatchTaskAddResults)
                    {
                        _taskAddResults.Add(protoAddTaskResult);
                    }
                }
            }
        }

        /// <summary>
        /// Checks for operation cancellation or timeout, and throws the corresponding exception.
        /// </summary>
        internal void CheckForCancellationOrTimeoutAndThrow()
        {
            //We always throw when cancellation is requested
            _cancellationToken.ThrowIfCancellationRequested();

            DateTime currentTime = DateTime.UtcNow;

            if (currentTime > this._timeToTimeoutAt)
            {
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// Waits for a pending operation to complete and throws if the operation failed.
        /// </summary>
        /// <returns></returns>
        internal async Task ProcessPendingOperationResults()
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

        /// <summary>
        /// Helper method
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        /// <exception cref="ParallelOperationsException"></exception>
        internal static async Task WaitForTasksAndThrowParallelOperationsExceptionAsync(List<Task> tasks)
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
                throw new ParallelOperationsException(BatchErrorCode.MultipleParallelRequestsHitUnexpectedErrors.ToString(), exceptions);
            }
        }

        /// <summary>
        /// Determines if the workflow has finished or not.
        /// </summary>
        /// <returns>True if the workflow has successfully completed, false if it has not.</returns>
        internal bool IsWorkflowDone()
        {
            return !(!this._remainingTasksToAdd.IsEmpty || this._pendingAsyncOperations.Count > 0);
        }

        #region Private classes

        /// <summary>
        /// Internal task wrapper which tracks a tasks retry count and holds a reference to the BatchTaskCreateOptions object.
        /// </summary>
        internal class TrackedBatchTask
        {
            public string JobId { get; private set; }
            public BatchTaskCreateOptions Task { get; private set; }
            public int RetryCount { get; private set; }

            internal TrackedBatchTask(
                string jobId,
                BatchTaskCreateOptions batchTaskCreateOptions)
            {
                this.Task = batchTaskCreateOptions;
                this.JobId = jobId;
               this.RetryCount = 0;
            }

            public void IncrementRetryCount()
            {
                this.RetryCount++;
            }
        }

        #endregion
    }
}
