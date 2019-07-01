// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Extensions to ensure async Tasks execute synchronously.
    /// </summary>
    internal static class TaskExtensions
    {
        /// <summary>
        /// Ensure the Task has finished executing.
        /// </summary>
        /// <typeparam name="T">Task's return type.</typeparam>
        /// <param name="task">The task.</param>
        /// <param name="syncOverAsync">
        /// A flag indicating whether synchronously we're making a call we know
        /// is async.  This is a temporary measure until we have a fully
        /// synchronous transport layer.
        /// </param>
        /// <returns>The result of executing the task.</returns>
        public static T EnsureCompleted<T>(this Task<T> task, bool syncOverAsync = false)
        {
            VerifyTaskCompleted(task);
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Ensure the Task has finished executing.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="syncOverAsync">
        /// A flag indicating whether synchronously we're making a call we know
        /// is async.  This is a temporary measure until we have a fully
        /// synchronous transport layer.
        /// </param>
        public static void EnsureCompleted(this Task task, bool syncOverAsync = false)
        {
            VerifyTaskCompleted(task);
            task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Verify if a task has completed and throw an
        /// <see cref="InvalidOperationException"/> (only while debugging) if
        /// it hasn't.
        /// </summary>
        /// <param name="task">The task to check for completion.</param>
        [Conditional("DEBUG")]
        private static void VerifyTaskCompleted(Task task)
        {
            if (!task.IsCompleted)
            {
                // Throw an InvalidOperationException instead of using
                // Debug.Assert because that brings down nUnit immediately
                throw new InvalidOperationException("Task is not completed");
            }
        }
    }
}
