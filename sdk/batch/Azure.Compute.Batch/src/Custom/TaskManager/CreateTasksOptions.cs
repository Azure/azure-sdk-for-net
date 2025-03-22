// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Stores options that configure the operation of methods on Batch client parallel operations.
    /// </summary>
    public class CreateTasksOptions
    {
        private int _maxDegreeOfParallelism;
        private int _maxTimeBetweenCallsInSeconds;
        private TaskResultHandler _createTaskResultHandler;
        private bool _returnBatchTaskAddResults;

        /// <summary>
        /// The handler which processes the results of the AddTaskCollection request.  If this is null, the default is used.
        /// </summary>
        public TaskResultHandler CreateTaskResultHandler
        {
            get { return this._createTaskResultHandler; }
            set { this._createTaskResultHandler = value; }
        }

        /// <summary>
        /// Gets or sets the maximum number of concurrent tasks enabled by this <see cref="CreateTasksOptions"/> instance.
        /// The default value is 1.
        /// </summary>
        public int MaxDegreeOfParallelism
        {
            get { return this._maxDegreeOfParallelism; }
            set
            {
                if (value > 0)
                {
                    this._maxDegreeOfParallelism = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum time between calls in seconds. This can
        /// be used to throttle the number of calls made to the Batch service.
        /// </summary>
        public int MaxTimeBetweenCallsInSeconds
        {
            get { return this._maxTimeBetweenCallsInSeconds; }
            set
            {
                if (value >= 0)
                {
                    this._maxTimeBetweenCallsInSeconds = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to return the list of
        /// BatchTaskAddResult from the CreateTasks and CreateTasksAsync methods.
        /// Default is false.
        /// </summary>
        public bool ReturnBatchTaskCreateResults
        {
            get { return this._returnBatchTaskAddResults; }
            set { this._returnBatchTaskAddResults = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTasksOptions"/> class.
        /// </summary>
        public CreateTasksOptions(int maxDegreeOfParallelism = 1,
            int maxTimeBetweenCallsInSeconds = 30,
            TaskResultHandler createTaskResultHandler = null,
            bool returnBatchTaskAddResults = false)
        {
            this.MaxDegreeOfParallelism = maxDegreeOfParallelism;
            this.MaxTimeBetweenCallsInSeconds = maxTimeBetweenCallsInSeconds;
            if (createTaskResultHandler != null)
            {
                this.CreateTaskResultHandler = createTaskResultHandler;
            }
            else
            {
                this.CreateTaskResultHandler = new DefaultCreateTaskResultHandler();
            }
            this.ReturnBatchTaskCreateResults = returnBatchTaskAddResults;
        }
    }
}
