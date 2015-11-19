namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// OperationExecutor class.
    /// </summary>
    public static class OperationExecutor
    {
        /// <summary>
        /// Executes the specified operation with the specified retry policy.
        /// </summary>
        /// <typeparam name="T">Returns an arbitrary type.</typeparam>
        /// <param name="function">The function to execute.</param>
        /// <param name="policy">The retry policy to apply to the function.</param>
        /// <param name="context">The abstraction context to use.</param>
        /// <param name="logger">An ILogger object to log retry attempts.</param>
        /// <returns>
        /// Returns the value received from the execution of the function.
        /// </returns>
        public static async Task<OperationExecutionResult<T>> ExecuteOperationWithRetry<T>(Func<Task<T>> function, IRetryPolicy policy, IAbstractionContext context, ILogger logger)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int attempt = 0; attempt < policy.MaxAttemptCount;)
            {
                try
                {
                    if (attempt > 0)
                    {
                        logger.LogMessage(string.Format(CultureInfo.InvariantCulture, "\r\nRetrying Operation because previous attempt resulted in error.  Current Retry attempt: {0}\r\n\r\n", attempt),
                                            Severity.Informational,
                                            Verbosity.Detailed);
                    }
                    context.CancellationToken.ThrowIfCancellationRequested();
                    T result = await function();
                    attempt++;
                    return new OperationExecutionResult<T>(result, stopwatch.Elapsed, attempt);
                }
                catch (Exception e)
                {
                    attempt++;
                    var retryParams = policy.GetRetryParameters(attempt, e);
                    //Log
                    if (retryParams.ShouldRetry)
                    {
                        context.CancellationToken.WaitForInterval(retryParams.WaitTime);
                    }
                    else
                    {
                        logger.LogMessage(string.Format(CultureInfo.InvariantCulture, "\r\nOperation attempt failed because of the following error:: {0}\r\n\r\n", e.Message),
                                            Severity.Informational,
                                            Verbosity.Detailed);
                        return new OperationExecutionResult<T>(e, stopwatch.Elapsed, attempt);
                    }
                }
            }
            throw new InvalidOperationException("Should not reach here. Bug in retry policy implementation");
        }
    }
}
