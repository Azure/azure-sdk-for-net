//-----------------------------------------------------------------------
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System.Collections.Generic;

    /// <summary>
    /// This class provides asynchronous semaphore functionality (based on Stephen Toub's blog).
    /// </summary>
    internal partial class AsyncSemaphore
    {
        public delegate void AsyncSemaphoreCallback(bool calledSynchronously);

        private readonly Queue<AsyncSemaphoreCallback> pendingWaits =
            new Queue<AsyncSemaphoreCallback>();

        public bool WaitAsync(AsyncSemaphoreCallback callback)
        {
            CommonUtils.AssertNotNull("callback", callback);

            lock (this.pendingWaits)
            {
                if (this.count > 0)
                {
                    this.count--;
                }
                else
                {
                    this.pendingWaits.Enqueue(callback);
                    callback = null;
                }
            }

            if (callback != null)
            {
                callback(true);
                return true;
            }

            return false;
        }

        public void Release()
        {
            AsyncSemaphoreCallback callback = null;
            lock (this.pendingWaits)
            {
                if (this.pendingWaits.Count > 0)
                {
                    callback = this.pendingWaits.Dequeue();
                }
                else
                {
                    this.count++;
                }
            }

            if (callback != null)
            {
                callback(false);
            }
        }
    }
}
