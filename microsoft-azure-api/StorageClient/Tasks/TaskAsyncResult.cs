//-----------------------------------------------------------------------
// <copyright file="TaskAsyncResult.cs" company="Microsoft">
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
//    Contains code for the TaskAsyncResult[T] class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// An implementation of IAsyncResult that encapsulates a task.
    /// </summary>
    /// <typeparam name="T">The type of the resulting value.</typeparam>
    /// <remarks>Refer to http://csdweb/sites/oslo/engsys/DesignGuidelines/Wiki%20Pages/IAsyncResult.aspx and 
    /// http://www.bluebytesoftware.com/blog/2006/05/31/ImplementingAHighperfIAsyncResultLockfreeLazyAllocation.aspx for IAsyncResult details</remarks>
    internal class TaskAsyncResult<T> : IAsyncResult, IDisposable
    {
        /// <summary>
        /// The underlying task for the async operation.
        /// </summary>
        private Task<T> realTask;

        /// <summary>
        /// The callback provided by the user.
        /// </summary>
        private AsyncCallback userCallback;

        /// <summary>
        /// The state for the callback.
        /// </summary>
        private object userState;

        /// <summary>
        /// Indicates whether a task is completed.
        /// </summary>
        private volatile bool isCompleted;

        /// <summary>
        /// Indicates whether task completed synchronously.
        /// </summary>
        private bool completedSynchronously;

        /// <summary>
        /// The event for blocking on this task's completion.
        /// </summary>
        private ManualResetEvent asyncWaitEvent;

        /// <summary>
        /// Initializes a new instance of the TaskAsyncResult class.
        /// </summary>
        /// <param name="async">The task to be executed.</param>
        /// <param name="callback">The callback method to be used on completion.</param>
        /// <param name="state">The state for the callback.</param>
        [DebuggerNonUserCode]
        public TaskAsyncResult(Task<T> async, AsyncCallback callback, object state)
        {
            this.realTask = async;
            this.userCallback = callback;
            this.userState = state;

            // We don't need finalization, we just implement IDisposable to let users close the event
            GC.SuppressFinalize(this);

            this.realTask.ExecuteStep(this.OnComplete);
        }
        
        /// <summary>
        /// Gets A user-defined object that contains information about the asynchronous operation.
        /// </summary>
        [DebuggerNonUserCode]
        object IAsyncResult.AsyncState
        {
            get { return this.userState; }
        }

        /// <summary>
        ///  Gets a System.Threading.WaitHandle that is used to wait for an asynchronous operation to complete.
        /// </summary>
        [DebuggerNonUserCode]
        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { return this.LazyCreateWaitHandle(); }
        }

        /// <summary>
        /// Gets a value indicating whether the asynchronous operation completed synchronously.
        /// </summary>
        [DebuggerNonUserCode]
        bool IAsyncResult.CompletedSynchronously
        {
            get { return this.completedSynchronously; }
        }

        /// <summary>
        /// Gets a value indicating whether the asynchronous operation has completed.
        /// </summary>
        [DebuggerNonUserCode]
        bool IAsyncResult.IsCompleted
        {
            get { return this.isCompleted; }
        }
        
        /// <summary>
        /// Provides a convenient function for waiting for completion and getting the result.
        /// </summary>
        /// <returns>The result of the operation.</returns>
        public T EndInvoke()
        {
            // We haven't completed yet, so we should wait. (Only single thread may call this)
            if (!this.isCompleted)
            {
                // If the operation isn't done, wait for it
                ((IAsyncResult)this).AsyncWaitHandle.WaitOne();
                ((IAsyncResult)this).AsyncWaitHandle.Close();
                this.asyncWaitEvent = null;
            }

            // Get the results - which will invoke any exceptions
            return this.realTask.Result;
        }

        /// <summary>
        /// We implement the dispose only to allow the explicit closing of the event.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">Set to <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.asyncWaitEvent != null)
                {
                    this.asyncWaitEvent.Close();
                    this.asyncWaitEvent = null;
                }
            }
        }

        /// <summary>
        /// Provides the lazy initialization of the WaitHandle (based on Joe Duffy's blog).
        /// </summary>
        /// <returns>The WaitHandle to use for waiting on completion.</returns>
        private WaitHandle LazyCreateWaitHandle()
        {
            if (this.asyncWaitEvent != null)
            {
                return this.asyncWaitEvent;
            }

            ManualResetEvent newHandle = new ManualResetEvent(false);
            if (Interlocked.CompareExchange(ref this.asyncWaitEvent, newHandle, null) != null)
            {
                // We lost the race. Release the handle we created, it's garbage.
                newHandle.Close();
            }

            if (this.isCompleted)
            {
                // If the result has already completed, we must ensure we return the
                // handle in a signaled state. The read of this.isCompleted must never move
                // before the read of m_waitHandle earlier; the use of an interlocked
                // compare-exchange just above ensures that. And there's a race that could
                // lead to multiple threads setting the event; that's no problem.
                this.asyncWaitEvent.Set();
            }

            return this.asyncWaitEvent;
        }

        /// <summary>
        /// Called on completion of the async operation to notify the user
        /// (Based on Joe Duffy's lockless design).
        /// </summary>
        [DebuggerNonUserCode]
        private void OnComplete()
        {
            // First mark completion
            this.completedSynchronously = this.realTask.CompletedSynchronously;
            this.isCompleted = true;

            // And then, if the wait handle was created, we need to signal it. Note the
            // use of a memory barrier. This is required to ensure the read of m_waitHandle
            // never moves before the store of m_isCompleted; otherwise we might encounter a
            // race that leads us to not signal the handle, leading to a deadlock. We can't
            // just do a volatile read of m_waitHandle, because it is possible for an acquire
            // load to move before a store release.
            Thread.MemoryBarrier();
            if (this.asyncWaitEvent != null)
            {
                this.asyncWaitEvent.Set();
            }

            if (this.userCallback != null)
            {
                this.userCallback(this);
            }
        }
    }
}
