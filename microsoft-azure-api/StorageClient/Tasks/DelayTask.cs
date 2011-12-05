//-----------------------------------------------------------------------
// <copyright file="DelayTask.cs" company="Microsoft">
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
//    Contains code for the DelayTask class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Threading;

    /// <summary>
    /// A task class that implements a fixed delay.
    /// </summary>
    internal class DelayTask : Task<NullTaskReturn>, IDisposable
    {
        /// <summary>
        /// Indicates whether this object has been disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Stores the length of the delay.
        /// </summary>
        private TimeSpan delayInterval;

        /// <summary>
        /// ObjectUsed to lock disposing methods and timer callbacks.
        /// </summary>
        private object disposingLockObject = new object();

        /// <summary>
        /// Stores the native timer used to trigger after the specified delay.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelayTask"/> class.
        /// </summary>
        /// <param name="delayInterval">Should be between TimeSpan.Zero and TimeSpan.MaxValue.</param>
        public DelayTask(TimeSpan delayInterval)
        {
            CommonUtils.AssertInBounds<TimeSpan>("delayInterval", delayInterval, TimeSpan.Zero, TimeSpan.MaxValue);

            this.delayInterval = delayInterval;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">Set to <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    lock (this.disposingLockObject)
                    {
                        if (this.timer != null)
                        {
                            this.timer.Dispose();
                        }
                    }
                }

                // Indicate that the instance has been disposed.
                this.timer = null;
                this.disposed = true;
            }
        }

        /// <summary>
        /// The specific implementation of the task's step.
        /// </summary>
        protected override void ExecuteInternal()
        {
            TraceHelper.WriteLine("Executing DelayTask interval msec " + this.delayInterval);
            if (this.delayInterval == TimeSpan.Zero)
            {
                // Complete synchronously
                this.Complete(true);
            }
            else
            {
                this.BeginDelay();
            }
        }

        /// <summary>
        /// The task-specific abort that should be called.
        /// </summary>
        protected override void AbortInternal()
        {
            TraceHelper.WriteLine("Aborting delay " + this.delayInterval);

            this.timer.Change(Timeout.Infinite, Timeout.Infinite);

            this.Dispose();
        }

        /// <summary>
        /// Begins the delay.
        /// </summary>
        private void BeginDelay()
        {
            TraceHelper.WriteLine("Begin delay timer msec " + this.delayInterval);

            this.timer = new Timer((state) => this.EndDelay());

            this.timer.Change(this.delayInterval, TimeSpan.FromMilliseconds(-1));
        }

        /// <summary>
        /// Ends the delay.
        /// </summary>
        private void EndDelay()
        {
            try
            {
                TraceHelper.WriteLine("End delay msec " + this.delayInterval);

                lock (this.disposingLockObject)
                {
                    if (this.timer != null)
                    {
                        this.timer.Dispose();

                        this.timer = null;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Exception = ex;
            }

            this.Complete(false);
        }
    }
}
