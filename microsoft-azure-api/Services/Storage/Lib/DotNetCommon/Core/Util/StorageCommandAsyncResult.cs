//-----------------------------------------------------------------------
// <copyright file="StorageCommandAsyncResult.cs" company="Microsoft">
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
    using System;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// Represents the async result returned by a storage command.
    /// </summary>
    internal class StorageCommandAsyncResult : CancellableOperationBase, ICancellableAsyncResult, IDisposable
    {
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
        private bool isCompleted = false;

        /// <summary>
        /// Indicates whether task completed synchronously.
        /// </summary>
        private bool completedSynchronously = true;

        /// <summary>
        /// The event for blocking on this task's completion.
        /// </summary>
        private ManualResetEvent asyncWaitEvent;

        [DebuggerNonUserCode]
        protected StorageCommandAsyncResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StorageCommandAsyncResult class.
        /// </summary>
        /// <param name="callback">The callback method to be used on completion.</param>
        /// <param name="state">The state for the callback.</param>
        [DebuggerNonUserCode]
        protected StorageCommandAsyncResult(AsyncCallback callback, object state)
        {
            this.userCallback = callback;
            this.userState = state;
        }

        /// <summary>
        /// Gets A user-defined object that contains information about the asynchronous operation.
        /// </summary>
        [DebuggerNonUserCode]
        public object AsyncState
        {
            get { return this.userState; }
        }

        /// <summary>
        ///  Gets a System.Threading.WaitHandle that is used to wait for an asynchronous operation to complete.
        /// </summary>
        [DebuggerNonUserCode]
        public WaitHandle AsyncWaitHandle
        {
            get { return this.LazyCreateWaitHandle(); }
        }

        /// <summary>
        /// Gets a value indicating whether the asynchronous operation completed synchronously.
        /// </summary>
        [DebuggerNonUserCode]
        public bool CompletedSynchronously
        {
            get { return this.completedSynchronously && this.isCompleted; }
        }

        /// <summary>
        /// Gets a value indicating whether the asynchronous operation has completed.
        /// </summary>
        [DebuggerNonUserCode]
        public bool IsCompleted
        {
            get { return this.isCompleted; }
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
                // Handle already created. Release the handle we created, it's garbage.
                newHandle.Close();
            }

            if (this.isCompleted)
            {
                // If the result has already completed, we must ensure we return the
                // handle in a signaled state. The read of this.isCompleted must never move
                // before the read of m_waitHandle earlier; the use of an interlocked
                // compare-exchange just above ensures that. And there's a scenario that could
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
        internal void OnComplete()
        {
            // If completed before, return immediately
            if (this.isCompleted)
            {
                return;
            }

            // First mark completion
            this.isCompleted = true;

            // And then, if the wait handle was created, we need to signal it. Note the
            // use of a memory barrier. This is required to ensure the read of m_waitHandle
            // never moves before the store of m_isCompleted; otherwise we might encounter a
            // scenario that leads us to not signal the handle, leading to a deadlock. We can't
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

        /// <summary>
        /// Blocks the calling thread until the async operation is completed.
        /// </summary>
        [DebuggerNonUserCode]
        internal virtual void End()
        {
            if (!this.isCompleted)
            {
                this.AsyncWaitHandle.WaitOne();
            }

            this.Dispose();
        }

        /// <summary>
        /// Updates the CompletedSynchronously flag with another asynchronous operation result.
        /// </summary>
        /// <param name="lastOperationCompletedSynchronously">Set to <c>true</c> if the last operation was completed synchronously; <c>false</c> if it was completed asynchronously.</param>
        [DebuggerNonUserCode]
        internal void UpdateCompletedSynchronously(bool lastOperationCompletedSynchronously)
        {
            this.completedSynchronously = this.completedSynchronously && lastOperationCompletedSynchronously;
        }
    }
}
