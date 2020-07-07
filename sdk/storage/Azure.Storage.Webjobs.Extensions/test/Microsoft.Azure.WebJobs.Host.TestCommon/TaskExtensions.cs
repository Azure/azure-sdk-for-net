// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public static class TaskExtensions
    {
        public static void WaitUntilCompleted(this Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }

            CreateCompletionTask(task).Wait();
        }

        public static bool WaitUntilCompleted(this Task task, int millisecondsTimeout)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }

            return CreateCompletionTask(task).Wait(millisecondsTimeout);
        }

        private static Task CreateCompletionTask(Task task)
        {
            return task.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    // Observe the exception in the faulted case to avoid an unobserved exception leaking and killing
                    // the thread finalizer (depending on unobserved task exceptions settings).
                    var observed = t.Exception;
                }
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}
