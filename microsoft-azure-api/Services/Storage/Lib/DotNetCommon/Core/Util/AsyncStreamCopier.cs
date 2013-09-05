//-----------------------------------------------------------------------
// <copyright file="AsyncStreamCopier.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading;

    // Class to copy streams with potentially overlapping read / writes. This uses no waithandle, extra threads, but does contain a single lock
    internal class AsyncStreamCopier<T> : IDisposable
    {
        #region Ctors + Locals
        // Note two buffers to do overlapped read and write. Once ReadBuffer is full it will be swapped over to writeBuffer and a write issued.
        private byte[] currentReadBuff = null;
        private byte[] currentWriteBuff = null;
        private volatile int lastReadCount = -1;
        private volatile int currentWriteCount = -1;
        private StreamDescriptor streamCopyState = null;

        // This variable keeps track of bytes that have already been read from the source stream.
        // It should only be modified using Interlocked.Add and read with Interlocked.Read.
        private long currentBytesReadFromSource = 0;

        private long? copyLen = null;
        private long? maximumLen = null;

        private Stream src = null;
        private Stream dest = null;
        private Action<ExecutionState<T>> completedDel;

        // these locals enforce a lock
        private volatile IAsyncResult readRes;
        private volatile IAsyncResult writeRes;
        private object lockerObj = new object();

        // Used for cooperative cancellation
        private volatile bool cancelRequested = false;
        private ExecutionState<T> state = null;
        private Action previousCancellationDelegate = null;

        // Used to signal copy completion
        private RegisteredWaitHandle waitHandle = null;
        private ManualResetEvent completedEvent = new ManualResetEvent(false);
        private int completionProcessed = 0;

        /// <summary>
        /// Creates and initializes a new asynchronous copy operation.
        /// </summary>
        /// <param name="src">The source stream.</param>
        /// <param name="dest">The destination stream.</param>
        /// <param name="state">An ExecutionState used to coordinate copy operation.</param>
        /// <param name="buffSize">Size of read and write buffers used to move data.</param>
        /// <param name="calculateMd5">Boolean value indicating whether the MD-5 should be calculated.</param>
        /// <param name="streamCopyState">An object that represents the state for the current operation.</param>
        public AsyncStreamCopier(Stream src, Stream dest, ExecutionState<T> state, int buffSize, bool calculateMd5, StreamDescriptor streamCopyState)
        {
            this.src = src;
            this.dest = dest;
            this.state = state;
            this.currentReadBuff = new byte[buffSize];
            this.currentWriteBuff = new byte[buffSize];

            this.streamCopyState = streamCopyState;

            if (streamCopyState != null && calculateMd5 && streamCopyState.Md5HashRef == null)
            {
                streamCopyState.Md5HashRef = new MD5Wrapper();
            }
        }
        #endregion

        #region Publics

        /// <summary>
        /// Begins a stream copy operation.
        /// </summary>
        /// <param name="completedDelegate">Callback delegate</param>
        /// <param name="copyLength">Number of bytes to copy from source stream to destination stream. Cannot be passed with a value for maxLength.</param>
        /// <param name="maxLength">Maximum length of the source stream. Cannot be passed with a value for copyLength.</param>
        public void StartCopyStream(Action<ExecutionState<T>> completedDelegate, long? copyLength, long? maxLength)
        {
            if (copyLength.HasValue && maxLength.HasValue)
            {
                throw new ArgumentException(SR.StreamLengthMismatch);
            }

            if (this.src.CanSeek && maxLength.HasValue && this.src.Length - this.src.Position > maxLength)
            {
                throw new InvalidOperationException(SR.StreamLengthError);
            }

            if (this.src.CanSeek && copyLength.HasValue && this.src.Length - this.src.Position < copyLength)
            {
                throw new ArgumentOutOfRangeException("copyLength", SR.StreamLengthShortError);
            }

            this.copyLen = copyLength;
            this.maximumLen = maxLength;
            this.completedDel = completedDelegate;

            // If there is a max time specified start timeout timer.
            if (this.state.OperationExpiryTime.HasValue)
            {
                this.waitHandle = ThreadPool.RegisterWaitForSingleObject(
                    this.completedEvent,
                    AsyncStreamCopier<T>.MaximumCopyTimeCallback,
                    this.state,
                    this.state.RemainingTimeout,
                    true);
            }

            lock (this.state.CancellationLockerObject)
            {
                this.previousCancellationDelegate = this.state.CancelDelegate;
                this.state.CancelDelegate = this.Abort;
            }

            // Start first read
            this.EndOpWithCatch(null);
        }

        /// <summary>
        /// Aborts an ongoing copy operation.
        /// </summary>
        public void Abort()
        {
            this.cancelRequested = true;
            AsyncStreamCopier<T>.ForceAbort(this.state, false);
        }

        /// <summary>
        /// Cleans up references. To end a copy operation, use Abort().
        /// </summary>
        public void Dispose()
        {
            if (this.waitHandle != null)
            {
                this.waitHandle.Unregister(null);
                this.waitHandle = null;
            }

            if (this.completedEvent != null)
            {
                this.completedEvent.Close();
                this.completedEvent = null;
            }

            this.state = null;
        }
        #endregion

        #region Privates
        /// <summary>
        /// Synchronizes Read and Write operations, and handles exceptions.
        /// </summary>
        /// <param name="res">Read/Write operation or null if first run.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool thread.")]
        private void EndOpWithCatch(IAsyncResult res)
        {
            // If the last op complete synchronously then ignore this callback as its caller will process next op
            if (res != null && res.CompletedSynchronously)
            {
                return;
            }

            // Begins the next operation and stores any exceptions which occur
            lock (this.lockerObj)
            {
                try
                {
                    this.EndOperation(res);
                }
                catch (Exception ex)
                {
                    if (this.state.ReqTimedOut)
                    {
                        this.state.ExceptionRef = Exceptions.GenerateTimeoutException(this.state.Cmd != null ? this.state.Cmd.CurrentResult : null, ex);
                    }
                    else if (this.cancelRequested)
                    {
                        this.state.ExceptionRef = Exceptions.GenerateCancellationException(this.state.Cmd != null ? this.state.Cmd.CurrentResult : null, ex);
                    }
                    else
                    {
                        this.state.ExceptionRef = ex;
                    }

                    // if there is an outstanding read/write let it signal completion since we populated the exception. 
                    if (this.readRes == null && this.writeRes == null)
                    {
                        this.SignalCompletion();
                    }
                }
            }
        }

        /// <summary>
        /// Helper method for EndOpWithCatch(IAsyncResult). Begins/Ends Read and Write Stream operations.
        /// Should only be called by EndOpWithCatch(IAsyncResult) since it assumes we are inside the lock.
        /// </summary>
        /// <param name="res">Read/Write operation or null if first run.</param>
        private void EndOperation(IAsyncResult res)
        {
            // Check who made this callback
            if (res != null)
            {
                // true is read, false is write              
                if ((bool)res.AsyncState)
                {
                    // Read callback
                    this.ProcessEndRead();
                }
                else
                {
                    // Write callback
                    this.ProcessEndWrite();
                } 
            }

            // While data is remaining and there are no scheduled operations, schedule next write and read
            while (!this.ReachedEndOfSrc() && this.readRes == null && this.writeRes == null)
            {
                // Check if copying should halt
                if (!this.ShouldDispatchNextOperation())
                {
                    this.SignalCompletion();
                    return;
                }

                // If read buffer contains unwritten data, swap buffers and set currentWriteCount
                if (this.ConsumeReadBuffer() > 0)
                {
                    // Schedule write operation from the last read
                    this.writeRes = this.dest.BeginWrite(this.currentWriteBuff, 0, this.currentWriteCount, this.EndOpWithCatch, false /* write */);
                    
                    // If this write completes synchronously, end it here to avoid stack overflow.
                    if (this.writeRes.CompletedSynchronously)
                    {
                        this.ProcessEndWrite();
                    }
                }

                // If data needs to be read.
                int readCount = this.NextReadLength();
                if (readCount != 0)
                {
                    // Schedule read operation
                    this.readRes = this.src.BeginRead(this.currentReadBuff, 0, readCount, this.EndOpWithCatch, true /* read */);

                    // If this read completes synchronously, end it here to avoid stack overflow.
                    if (this.readRes.CompletedSynchronously)
                    {
                        this.ProcessEndRead();
                    }
                }
                else
                {
                    // User requested read end here. Signal end of source.
                    this.lastReadCount = 0;
                }
            }

            // If nothing more needs to be read and no write operation is scheduled, we are finished.
            if (this.ReachedEndOfSrc() && this.writeRes == null)
            {
                if (this.state.ExceptionRef == null && this.copyLen.HasValue && this.NextReadLength() != 0)
                {
                    this.state.ExceptionRef = new ArgumentOutOfRangeException("copyLength", SR.StreamLengthShortError);
                }

                this.SignalCompletion();
            }
        }

        /// <summary>
        /// Callback for timeout timer. Aborts the AsyncStreamCopier operation if a timeout occurs.
        /// </summary>
        /// <param name="state">Callback state.</param>
        /// <param name="timedOut">True if the timer has timed out, false otherwise.</param>
        private static void MaximumCopyTimeCallback(object state, bool timedOut)
        {
            if (timedOut)
            {
                ExecutionState<T> executionState = (ExecutionState<T>)state;
                AsyncStreamCopier<T>.ForceAbort(executionState, true);
            }
        }

        /// <summary>
        /// Aborts the AsyncStreamCopier operation.
        /// </summary>
        /// <param name="executionState">An object that stores state of the operation.</param>
        /// <param name="timedOut">True if aborted due to a time out, or false for a general cancellation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Reviewed.")]
        private static void ForceAbort(ExecutionState<T> executionState, bool timedOut)
        {
            if (executionState.Req != null)
            {
                try
                {
                    executionState.ReqTimedOut = timedOut;
                    executionState.Req.Abort();
                }
                catch (Exception)
                {
                    // no op
                }
            }

            executionState.ExceptionRef = timedOut ?
                Exceptions.GenerateTimeoutException(executionState.Cmd != null ? executionState.Cmd.CurrentResult : null, null) :
                Exceptions.GenerateCancellationException(executionState.Cmd != null ? executionState.Cmd.CurrentResult : null, null);
        }

        /// <summary>
        /// Terminates and cleans up the AsyncStreamCopier.
        /// </summary>
        private void SignalCompletion()
        {
            // If already completed return
            if (Interlocked.CompareExchange(ref this.completionProcessed, 1, 0) == 0)
            {
                this.completedEvent.Set();
                this.ProcessCompletion();
            }
        }

        /// <summary>
        /// Helper method for this.SignalCompletion()
        /// Should only be called by this.SignalCompletion()
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Reviewed.")]
        private void ProcessCompletion()
        {
            // Re hookup cancellation delegate
            this.state.CancelDelegate = this.previousCancellationDelegate;

            // clear references
            this.src = null;
            this.dest = null;
            this.currentReadBuff = null;
            this.currentWriteBuff = null;

            if (this.state.ExceptionRef == null &&
                this.streamCopyState != null &&
                this.streamCopyState.Md5HashRef != null)
            {
                try
                {
                    this.streamCopyState.Md5 = this.streamCopyState.Md5HashRef.ComputeHash();
                }
                catch (Exception)
                {
                    // no op
                }
                finally
                {
                    this.streamCopyState.Md5HashRef = null;
                }
            }

            // invoke the caller's callback
            Action<ExecutionState<T>> callback = this.completedDel;
            this.completedDel = null;
            if (callback != null)
            {
                try
                {
                    callback(this.state);
                }
                catch (Exception ex)
                {
                    this.state.ExceptionRef = ex;
                }
            }

            // and finally clear the reference to the state
            this.Dispose();
        }

        /// <summary>
        /// Determines whether the next operation should begin or halt due to an exception or cancellation.
        /// </summary>
        /// <returns>True to continue, false to halt.</returns>
        private bool ShouldDispatchNextOperation()
        {
            if (this.maximumLen.HasValue && Interlocked.Read(ref this.currentBytesReadFromSource) > this.maximumLen)
            {
                this.state.ExceptionRef = new InvalidOperationException(SR.StreamLengthError);
            }
            else if (this.state.OperationExpiryTime.HasValue && DateTime.Now >= this.state.OperationExpiryTime.Value)
            {
                this.state.ExceptionRef = Exceptions.GenerateTimeoutException(this.state.Cmd != null ? this.state.Cmd.CurrentResult : null, null);
            }
            else if (this.state.CancelRequested)
            {
                this.state.ExceptionRef = Exceptions.GenerateCancellationException(this.state.Cmd != null ? this.state.Cmd.CurrentResult : null, null);
            }

            // note cancellation will new up a exception and store it, so this will be not null;
            // continue if no exceptions so far
            return !this.cancelRequested && this.state.ExceptionRef == null;
        }

        /// <summary>
        /// Waits for a read operation to end and updates the AsyncStreamCopier state.
        /// </summary>
        private void ProcessEndRead()
        {
            IAsyncResult lastReadRes = this.readRes;
            this.readRes = null;
            this.lastReadCount = this.src.EndRead(lastReadRes);
            Interlocked.Add(ref this.currentBytesReadFromSource, this.lastReadCount);
            this.state.UpdateCompletedSynchronously(lastReadRes.CompletedSynchronously);
        }

        /// <summary>
        /// Waits for a write operation to end and updates the AsyncStreamCopier state.
        /// </summary>
        private void ProcessEndWrite()
        {
            IAsyncResult lastWriteRes = this.writeRes;
            this.writeRes = null;
            this.dest.EndWrite(lastWriteRes);
            
            this.state.UpdateCompletedSynchronously(lastWriteRes.CompletedSynchronously);

            if (this.streamCopyState != null)
            {
                this.streamCopyState.Length += this.currentWriteCount;

                if (this.streamCopyState.Md5HashRef != null)
                {
                    this.streamCopyState.Md5HashRef.UpdateHash(this.currentWriteBuff, 0, this.currentWriteCount);
                }
            }
        }

        /// <summary>
        /// If a read operation has completed with data, swaps the read/write buffers and resets their corresponding counts.
        /// This must be called inside a lock as it could lead to undefined behavior if multiple unsynchronized callers simultaneously called in.
        /// </summary>
        /// <returns>Number of bytes to write, or negative if no read operation has completed.</returns>
        private int ConsumeReadBuffer()
        {
            if (!this.ReadBufferFull())
            {
                return this.lastReadCount;
            }

            this.currentWriteCount = this.lastReadCount;
            this.lastReadCount = -1;

            // The buffer swap sa ves us a memcopy of the data in readBuff.
            byte[] tempBuff = null;
            tempBuff = this.currentReadBuff;
            this.currentReadBuff = this.currentWriteBuff;
            this.currentWriteBuff = tempBuff;

            return this.currentWriteCount;
        }

        /// <summary>
        /// Determines the number of bytes that should be read from the source in the next BeginRead operation.
        /// Should only be called when no outstanding read operations exist.
        /// </summary>
        /// <returns>Number of bytes to read.</returns>
        private int NextReadLength()
        {
            if (this.copyLen.HasValue)
            {
                long bytesRemaining = this.copyLen.Value - Interlocked.Read(ref this.currentBytesReadFromSource);
                return (int)Math.Min(bytesRemaining, this.currentReadBuff.Length);
            }
            
            return this.currentReadBuff.Length;
        }

        /// <summary>
        /// Determines whether no more data can be read from the source Stream.
        /// </summary>
        /// <returns>True if at the end, false otherwise.</returns>
        private bool ReachedEndOfSrc()
        {
            return this.lastReadCount == 0;
        }

        /// <summary>
        /// Determines whether the current read buffer contains data ready to be written.
        /// </summary>
        /// <returns>True if read buffer is full, false otherwise.</returns>
        private bool ReadBufferFull()
        {
            return this.lastReadCount > 0;
        }
        #endregion
    }
}
