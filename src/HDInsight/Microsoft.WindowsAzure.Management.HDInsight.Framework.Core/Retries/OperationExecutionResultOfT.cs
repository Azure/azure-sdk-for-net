namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;

    /// <summary>
    /// Provides the result of the operation that was executed.
    /// </summary>
    /// <typeparam name="T">The type of the result from the execution.</typeparam>
    public class OperationExecutionResult<T> : OperationExecutionResult
    {
        private T executionOutput;

        /// <summary>
        /// Initializes a new instance of the OperationExecutionResult class.
        /// </summary>
        /// <param name="executionOutput">The execution output.</param>
        /// <param name="totalTime">The total time spent on the execution.</param>
        /// <param name="attempts">The number of attempts.</param>
        public OperationExecutionResult(T executionOutput, TimeSpan totalTime, int attempts)
            : base(totalTime, attempts)
        {
            if (executionOutput == null && !executionOutput.GetType().IsValueType)
            {
                throw new ArgumentNullException("executionOutput");
            }

            this.executionOutput = executionOutput;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationExecutionResult{T}"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="totalTime">The total time.</param>
        /// <param name="attempts">The number of attempts.</param>
        public OperationExecutionResult(Exception exception, TimeSpan totalTime, int attempts)
            : base(exception, totalTime, attempts)
        {
            this.executionOutput = default(T);
        }

        /// <summary>
        /// Gets the execution output.
        /// </summary>
        /// <value>
        /// The execution output.
        /// </value>
        public T ExecutionOutput
        {
            get
            {
                if (!IsSuccessful)
                {
                    ExceptionDispatchInfo.Capture(ExceptionIfAny).Throw();
                }
                return this.executionOutput;
            }
        }
    }
}
