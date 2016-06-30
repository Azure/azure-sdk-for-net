namespace Microsoft.Azure.Batch
{
    using System;

    public partial class AddTaskResult
    {
        private readonly CloudTask task;
        private readonly int retryCount;

        internal AddTaskResult(CloudTask task, int retryCount, Protocol.Models.TaskAddResult addTaskResult) : this(addTaskResult)
        {
            this.task = task;
            this.retryCount = retryCount;
        }

        /// <summary>
        /// Gets details of the task.
        /// </summary>
        public CloudTask Task
        {
            get { return this.task; }
        }

        /// <summary>
        /// Gets the number of times the Add Task operation was retried for this task.
        /// </summary>
        public int RetryCount
        {
            get { return this.retryCount; }
        }

    };
    
    /// <summary>
    /// Used by <see cref="AddTaskCollectionResultHandler"/> to classify an <see cref="AddTaskResult"/> as successful or
    /// requiring a retry.
    /// </summary>
    /// <remarks>AddTaskResultStatus is not used to report non-retryable failure; a result handler should throw
    /// <see cref="AddTaskCollectionTerminatedException"/> for that.</remarks>
    public enum AddTaskResultStatus
    {
        /// <summary>
        /// Classifies the result as a success.
        /// </summary>
        Success,

        /// <summary>
        /// Classifies the result as requiring a retry.
        /// </summary>
        Retry
    }
}
