//-----------------------------------------------------------------------
// <copyright file="TimeoutHelper.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
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
        internal static Exception GenerateTimeoutError(TimeSpan timeout)
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

            throw GenerateTimeoutError(timeout);
        }
    }
}
