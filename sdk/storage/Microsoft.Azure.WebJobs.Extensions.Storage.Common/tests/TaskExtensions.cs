// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public static class TaskExtensions
    {
        public static void WaitUntilCompleted(this Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            CreateCompletionTask(task).Wait();
        }

        public static bool WaitUntilCompleted(this Task task, int millisecondsTimeout)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            return CreateCompletionTask(task).Wait(millisecondsTimeout);
        }

        private static Task CreateCompletionTask(Task task)
        {
#pragma warning disable CA2008 // Do not create tasks without passing a TaskScheduler
            return task.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    // Observe the exception in the faulted case to avoid an unobserved exception leaking and killing
                    // the thread finalizer (depending on unobserved task exceptions settings).
                    var observed = t.Exception;
                }
            }, TaskContinuationOptions.ExecuteSynchronously);
#pragma warning restore CA2008 // Do not create tasks without passing a TaskScheduler
        }
    }
}
