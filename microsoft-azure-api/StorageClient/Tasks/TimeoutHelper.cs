//-----------------------------------------------------------------------
// <copyright file="TimeoutHelper.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the TimeoutHelper class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using TaskSequence = System.Collections.Generic.IEnumerable<ITask>;

    /// <summary>
    /// Encapsulates methods for wrapping tasks in timeouts.
    /// </summary>
    internal static class TimeoutHelper
    {
        /// <summary>
        /// Gets a timeout wrapped task.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="timeout">The timeout.</param>
        /// <param name="originalTask">The original task.</param>
        /// <returns>A <see cref="Task&lt;T&gt;"/> that has been wrapped with a timeout if specified.</returns>
        internal static Task<T> GetTimeoutWrappedTask<T>(TimeSpan? timeout, Task<T> originalTask)
        {
            TraceHelper.WriteLine("Creating timeout wrapped task " + timeout);
            
            if (timeout.HasValue)
            {
                Task<T> wrappedTimeoutTask = new InvokeTaskSequenceTask<T>((setResult) =>
                    GetTimeoutTaskSequence(timeout.Value, setResult));
                return new RaceTask<T>(wrappedTimeoutTask, originalTask);
            }
            else
            {
                return originalTask;
            }
        }

        /// <summary>
        /// Creates a localized timeout exception object.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>A localized <see cref="TimeoutException"/> object.</returns>
        internal static Exception ThrowTimeoutError(TimeSpan timeout)
        {
            TraceHelper.WriteLine("ThrowTimeoutError " + timeout);

            string errorMessage = string.Format(
                System.Globalization.CultureInfo.CurrentCulture,
                SR.ClientSideTimeoutError,
                timeout.RoundUpToSeconds());

            return new TimeoutException(errorMessage);
        }

        /// <summary>
        /// Gets a timeout task sequence.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="timeout">The timeout.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that has been wrapped with a timeout if specified.</returns>
        private static TaskSequence GetTimeoutTaskSequence<T>(TimeSpan timeout, Action<T> setResult)
        {
            TraceHelper.WriteLine("Creating timeout task sequence " + timeout);
            NullTaskReturn scratch;

            using (DelayTask timeoutTask = new DelayTask(timeout))
            {
                yield return timeoutTask;
                scratch = timeoutTask.Result;
            }

            throw ThrowTimeoutError(timeout);
        }
    }
}
