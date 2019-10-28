// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <returns>The result of executing the task.</returns>
        public static T EnsureCompleted<T>(this Task<T> task)
        {
            VerifyTaskCompleted(task);
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Ensure the Task has finished executing.
        /// </summary>
        /// <param name="task">The task.</param>
        public static void EnsureCompleted(this Task task)
        {
            VerifyTaskCompleted(task);
            task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Ensure the Task has finished executing.
        /// </summary>
        /// <typeparam name="T">Task's return type.</typeparam>
        /// <param name="task">The task.</param>
        /// <returns>The result of executing the task.</returns>
        public static T EnsureCompleted<T>(this ValueTask<T> task)
        {
            VerifyTaskCompleted(task);
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Ensure the Task has finished executing.
        /// </summary>
        /// <param name="task">The task.</param>
        public static void EnsureCompleted(this ValueTask task)
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
        private static void VerifyTaskCompleted<T>(ValueTask<T> task)
        {
            if (!task.IsCompleted)
            {
                // Throw an InvalidOperationException instead of using
                // Debug.Assert because that brings down nUnit immediately
                throw Errors.TaskIncomplete();
            }
        }

        /// <summary>
        /// Verify if a task has completed and throw an
        /// <see cref="InvalidOperationException"/> (only while debugging) if
        /// it hasn't.
        /// </summary>
        /// <param name="task">The task to check for completion.</param>
        [Conditional("DEBUG")]
        private static void VerifyTaskCompleted(ValueTask task)
        {
            if (!task.IsCompleted)
            {
                // Throw an InvalidOperationException instead of using
                // Debug.Assert because that brings down nUnit immediately
                throw Errors.TaskIncomplete();
            }
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
                throw Errors.TaskIncomplete();
            }
        }
    }
}
