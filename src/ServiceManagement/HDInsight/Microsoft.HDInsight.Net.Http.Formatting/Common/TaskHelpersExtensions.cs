// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    internal static class TaskHelpersExtensions
    {
        /// <summary>
        /// Cast Task to Task of object
        /// </summary>
        internal static async Task<object> CastToObject(this Task task)
        {
            await task;
            return null;
        }

        /// <summary>
        /// Cast Task of T to Task of object
        /// </summary>
        internal static async Task<object> CastToObject<T>(this Task<T> task)
        {
            return (object)await task;
        }

        /// <summary>
        /// Throws the first faulting exception for a task which is faulted. It preserves the original stack trace when
        /// throwing the exception. Note: It is the caller's responsibility not to pass incomplete tasks to this
        /// method, because it does degenerate into a call to the equivalent of .Wait() on the task when it hasn't yet
        /// completed.
        /// </summary>
        internal static void ThrowIfFaulted(this Task task)
        {
            task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Attempts to get the result value for the given task. If the task ran to completion, then
        /// it will return true and set the result value; otherwise, it will return false.
        /// </summary>
        [SuppressMessage("Microsoft.Web.FxCop", "MW1201:DoNotCallProblematicMethodsOnTask", Justification = "The usages here are deemed safe, and provide the implementations that this rule relies upon.")]
        internal static bool TryGetResult<TResult>(this Task<TResult> task, out TResult result)
        {
            if (task.Status == TaskStatus.RanToCompletion)
            {
                result = task.Result;
                return true;
            }

            result = default(TResult);
            return false;
        }
    }
}
