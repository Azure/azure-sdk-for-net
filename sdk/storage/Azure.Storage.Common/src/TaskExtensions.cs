// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Extensions to execute async Tasks synchronously.
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
            Debug.Assert(task.IsCompleted);
            return task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Ensure the Task has finished executing.
        /// </summary>
        /// <param name="task">The task.</param>
        public static void EnsureCompleted(this Task task)
        {
            Debug.Assert(task.IsCompleted);
            task.GetAwaiter().GetResult();
        }
    }
}
