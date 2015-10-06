namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;

    /// <summary>
    /// Provides the result of the operation that was executed.
    /// </summary>
    public class OperationExecutionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationExecutionResult" /> class.
        /// </summary>
        /// <param name="totalTime">The total time.</param>
        /// <param name="attempts">The number of attempts.</param>
        public OperationExecutionResult(TimeSpan totalTime, int attempts)
        {
            this.Attempts = attempts;
            this.TotalTime = totalTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationExecutionResult"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="totalTime">The total time.</param>
        /// <param name="attempts">The number of attempts.</param>
        public OperationExecutionResult(Exception exception, TimeSpan totalTime, int attempts)
        {
            this.Attempts = attempts;
            this.TotalTime = totalTime;
            this.ExceptionIfAny = exception;
        }

        /// <summary>
        /// Gets the total time spent on the execution.
        /// </summary>
        public TimeSpan TotalTime { get; private set; }

        /// <summary>
        /// Gets the number of attempts.
        /// </summary>
        public int Attempts { get; private set; }

        /// <summary>
        /// Gets the exception if any.
        /// </summary>
        /// <value>
        /// The exception if any.
        /// </value>
        public Exception ExceptionIfAny { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the operation was successful.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is successful; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccessful
        {
            get
            {
                return this.ExceptionIfAny == null;
            }
        }
    }
}