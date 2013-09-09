// -----------------------------------------------------------------------------------------
// <copyright file="AsyncSemaphore.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>
    /// This class provides asynchronous semaphore functionality (based on Stephen Toub's blog).
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed - Stephen Toub is a proper noun.")]
    internal partial class AsyncSemaphore
    {
        private readonly static Task<bool> CompletedTask = Task.FromResult(true);

        private readonly Queue<TaskCompletionSource<bool>> pendingWaits =
            new Queue<TaskCompletionSource<bool>>();

        public Task<bool> WaitAsync()
        {
            lock (this.pendingWaits)
            {
                if (this.count > 0)
                {
                    this.count--;
                    return AsyncSemaphore.CompletedTask;
                }
                else
                {
                    TaskCompletionSource<bool> waiter = new TaskCompletionSource<bool>();
                    this.pendingWaits.Enqueue(waiter);
                    return waiter.Task;
                }
            }
        }

        public void Release()
        {
            TaskCompletionSource<bool> waiter = null;
            lock (this.pendingWaits)
            {
                if (this.pendingWaits.Count > 0)
                {
                    waiter = this.pendingWaits.Dequeue();
                }
                else
                {
                    this.count++;
                }
            }

            if (waiter != null)
            {
                waiter.SetResult(false);
            }
        }
    }
}
