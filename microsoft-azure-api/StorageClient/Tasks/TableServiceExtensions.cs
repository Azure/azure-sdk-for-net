//-----------------------------------------------------------------------
// <copyright file="TableServiceExtensions.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
//    Contains code for the TableServiceExtensions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Diagnostics;
    using TaskSequence = System.Collections.Generic.IEnumerable<ITask>;

    /// <summary>
    /// A set of extension methods for table service classes.
    /// </summary>
    internal static class TableServiceExtensions
    {
        /// <summary>
        /// Converts a DataServiceQuery execution into an APMTask.
        /// </summary>
        /// <typeparam name="T">The result type of the query.</typeparam>
        /// <param name="query">The query to convert.</param>
        /// <returns>The wrapped task.</returns>
        [DebuggerNonUserCode]
        public static Task<IEnumerable<T>> ExecuteAsync<T>(this DataServiceQuery<T> query)
        {
            var queryTask = new APMTask<IEnumerable<T>>(query.BeginExecute, query.EndExecute);
#if false
            return queryTask;
#else
            return GetUnexpectedInternalClientErrorWrappedTask(Protocol.Constants.TableWorkaroundTimeout, queryTask);
#endif
        }

        /// <summary>
        /// Converts the SaveChanges method into an APMTask.
        /// </summary>
        /// <param name="context">The target context.</param>
        /// <returns>The wrapped task.</returns>
        [DebuggerNonUserCode]
        public static Task<DataServiceResponse> SaveChangesAsync(this TableServiceContext context)
        {
            return context.SaveChangesAsync(SaveChangesOptions.None);
        }

        /// <summary>
        /// Converts the SaveChanges method to an APMTask.
        /// </summary>
        /// <param name="context">The target context.</param>
        /// <param name="options">The options to pass to SaveChanges.</param>
        /// <returns>A task that saves changes asynchronously.</returns>
        [DebuggerNonUserCode]
        public static Task<DataServiceResponse> SaveChangesAsync(this TableServiceContext context, SaveChangesOptions options)
        {
            var task = new APMTask<DataServiceResponse>(
                (callback, state) => context.BeginSaveChanges(options, callback, state),
                (asyncResult) => context.EndSaveChanges(asyncResult));
#if false
            return task;
#else
            return GetUnexpectedInternalClientErrorWrappedTask(Protocol.Constants.TableWorkaroundTimeout, task);
#endif
        }

        /// <summary>
        /// Gets the unexpected internal client error wrapped task.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="timeout">The timeout.</param>
        /// <param name="originalTask">The original task.</param>
        /// <returns>The wrapped task.</returns>
        internal static Task<T> GetUnexpectedInternalClientErrorWrappedTask<T>(TimeSpan? timeout, Task<T> originalTask)
        {
            TraceHelper.WriteLine("Creating timeout wrapped task " + timeout);

            if (timeout.HasValue)
            {
                Task<T> wrappedTimeoutTask = new InvokeTaskSequenceTask<T>((setResult) =>
                    GetUnexpectedInternalClientErrorTaskSequence(timeout.Value, setResult));
                return new RaceTask<T>(wrappedTimeoutTask, originalTask);
            }
            else
            {
                return originalTask;
            }
        }

        /// <summary>
        /// Gets the unexpected internal client error task sequence.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="timeout">The timeout.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> for the unexpected error.</returns>
        private static TaskSequence GetUnexpectedInternalClientErrorTaskSequence<T>(TimeSpan timeout, Action<T> setResult)
        {
            // this fires to signal the the detection of a known astoria 1.0 bug.
            TraceHelper.WriteLine("Creating unexpected internal client error task sequence " + timeout);
            NullTaskReturn scratch;

            using (DelayTask timeoutTask = new DelayTask(timeout))
            {
                yield return timeoutTask;
                scratch = timeoutTask.Result;
            }

            TraceHelper.WriteLine("Unexpected internal storage client error.");

            throw new StorageClientException(
                StorageErrorCode.None,
                "The operation has exceeded the default maximum time allowed for Windows Azure Table service operations.", 
                System.Net.HttpStatusCode.Unused,
                null,
                null)
            {
                HelpLink = "http://go.microsoft.com/fwlink/?LinkID=182765"
            };
        }
    }
}
