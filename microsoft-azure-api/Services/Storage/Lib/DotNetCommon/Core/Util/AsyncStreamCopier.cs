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
    using System;
    using System.IO;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using System.Threading;

    // Class to copy streams with potentially overlapping read / writes. This uses no waithandle, extra threads, but does contain a single lock
    internal class AsyncStreamCopier<T>
    {
        #region Ctors + Locals
        // Note two buffers to do overlapped read and write. Once ReadBuffer is full it will be swapped over to writeBuffer and a write issued.
        private byte[] currentReadBuff = null;
        private byte[] currentWriteBuff = null;
        private int lastReadCount = -1;
        private int currentWriteCount = -1;
        private OperationContext operationContext = null;

        private DateTime? maxCopyTime = null;
        private long? maxLength = null;
        private Stream src = null;
        private Stream dest = null;
        private Action<ExecutionState<T>> completedDel;

        // these locals enforce a lock
        private IAsyncResult readRes;
        private IAsyncResult writeRes;
        private object lockerObj = new object();

        // Used for cooperative cancellation
        private bool cancelRequested = false;
        private bool readBufferFull = false;
        private ExecutionState<T> state = null;
        private Action previousCancellationDelegate = null;

        /// <summary>
        /// Flag to store completion status, 0 = non complete, 1 = complete
        /// </summary>
        private int completed = 0;

        /// <summary>
        /// Stores the native timer used to trigger after the specified delay.
        /// </summary>
        private Timer timer;

        public AsyncStreamCopier(Stream src, Stream dest, ExecutionState<T> state, int buffSize, bool calculateMd5, OperationContext operationContext)
        {
            this.src = src;
            this.dest = dest;
            this.state = state;
            this.currentReadBuff = new byte[buffSize];
            this.currentWriteBuff = new byte[buffSize];

            this.operationContext = operationContext;

            if (operationContext.StreamCopyState == null)
            {
                operationContext.StreamCopyState = new StreamDescriptor();
                operationContext.StreamCopyState.Md5HashRef = calculateMd5 ? new MD5Wrapper() : null;
            }
        }
        #endregion

        #region Publics
        public void StartCopyStream(Action<ExecutionState<T>> completedDel, long? maxLength, DateTime? maxCopyTime)
        {
            this.completedDel = completedDel;
            this.maxCopyTime = maxCopyTime;
            this.maxLength = maxLength;

            // If there is a max time specified start timeout timer.
            if (maxCopyTime.HasValue)
            {
                this.timer = new Timer((t) => this.ForceAbort());
                this.timer.Change(maxCopyTime.Value - DateTime.Now, TimeSpan.FromMilliseconds(-1));
            }

            lock (this.state.CancellationLockerObject)
            {
                this.previousCancellationDelegate = this.state.CancelDelegate;
                this.state.CancelDelegate = this.Abort;
            }

            // Start first read
            this.EndOpWithCatch(null);
        }

        public void Abort()
        {
            this.state.ExceptionRef = Exceptions.GenerateCancellationException(this.state.OperationContext.CurrentResult, null);
            this.cancelRequested = true;
        }
        #endregion

        #region Privates
        private void EndOpWithCatch(IAsyncResult res)
        {
            // If the last op complete synchronously then ignore this callback as its caller will process next op
            if (res != null && res.CompletedSynchronously)
            {
                return;
            }

            try
            {
                this.EndOperation(res);
            }
            catch (Exception ex)
            {
                this.state.ExceptionRef = ex;
                lock (this.lockerObj)
                {
                    this.SignalCompletion();
                }
            }
        }

        // True means read, false means write
        private void EndOperation(IAsyncResult res)
        {
            // true is read, false is write
            bool readWriteFlag = res == null ? true : (bool)res.AsyncState;

            lock (this.lockerObj)
            {
                if (readWriteFlag)
                {
                    this.readRes = null;

                    // Update length & count if this isn't the first run (res == null)
                    if (res != null)
                    {
                        this.ProcessEndRead(res);

                        // oustanding write, so we will simply end read and return, write will schedule next write
                        if (this.writeRes != null)
                        {
                            return;
                        }
                    }

                    while (this.lastReadCount != 0 && this.readRes == null && this.writeRes == null)
                    {
                        if (!this.ShouldDispatchNextOperation())
                        {
                            this.SignalCompletion();
                            return;
                        }

                        // No outstanding reads & writes, schedule write current and read next
                        if (this.writeRes == null)
                        {
                            if (this.readBufferFull)
                            {
                                // will swap buffers, set currentWriteCount
                                this.ConsumeReadBuffer();

                                this.writeRes = this.dest.BeginWrite(this.currentWriteBuff, 0, this.currentWriteCount, this.EndOpWithCatch, false /* write */);

                                // if this completes synchronously, then it doesnt matter, the next reads callback will init the next write and we are about to kick off the next read.
                                if (this.writeRes.CompletedSynchronously)
                                {
                                    this.ProcessEndWrite(this.writeRes, this.currentWriteBuff, 0, this.currentWriteCount);
                                }
                            }

                            this.readRes = this.src.BeginRead(this.currentReadBuff, 0, this.currentReadBuff.Length, this.EndOpWithCatch, true /* read */);

                            if (this.readRes.CompletedSynchronously)
                            {
                                this.ProcessEndRead(this.readRes);
                            }
                        }
                        else
                        {
                            // write outstanding, read buffer is full && write buffer is in use. Wait for its callback to get data  
                            break;
                        }
                    }
                }
                else
                {
                    this.ProcessEndWrite(this.writeRes, this.currentWriteBuff, 0, this.currentWriteCount);

                    // If reads are finished then do completion
                    if (this.IsCopyComplete() || !this.ShouldDispatchNextOperation())
                    {
                        if (this.readRes == null)
                        {
                            this.SignalCompletion();
                        }

                        return;
                    }

                    // read is done, check to see if we need to dispatch write
                    if (this.readBufferFull)
                    {
                        // Schedule write if data is available
                        this.ConsumeReadBuffer();

                        this.writeRes = this.dest.BeginWrite(this.currentWriteBuff, 0, this.currentWriteCount, this.EndOpWithCatch, false /* write */);

                        if (this.writeRes.CompletedSynchronously)
                        {
                            this.ProcessEndWrite(this.writeRes, this.currentWriteBuff, 0, this.currentWriteCount);

                            // kick off next op
                            this.EndOpWithCatch(null);
                        }
                    }
                    else if (this.readRes == null)
                    {
                        // Schedule Next Read if buffer is free and no outstanding reads
                        this.readRes = this.src.BeginRead(this.currentReadBuff, 0, this.currentReadBuff.Length, this.EndOpWithCatch, true);

                        // EndOpWithCatch with null will dispatch next op
                        if (this.readRes.CompletedSynchronously)
                        {
                            this.ProcessEndRead(this.readRes);
                            this.EndOpWithCatch(null);
                        }
                    }
                }

                if (this.IsCopyComplete())
                {
                    if (this.writeRes == null)
                    {
                        this.SignalCompletion();
                    }
                }
            }
        }

        // Used when timer timeout fires to force completion
        private void ForceAbort()
        {
            // Enter Force completed state
            if (Interlocked.CompareExchange(ref this.completed, 1, 0) == 0)
            {
                this.cancelRequested = true;

                try
                {
                    this.state.Req.Abort();
                }
                catch (Exception)
                {
                    // no op
                }

                this.state.ExceptionRef = Exceptions.GenerateTimeoutException(this.state.OperationContext.CurrentResult, null);
                this.ProcessCompletion();
            }
        }

        private void SignalCompletion()
        {
            // If already completed return
            if (Interlocked.CompareExchange(ref this.completed, 1, 0) != 0)
            {
                return;
            }

            this.ProcessCompletion();
        }

        // only called by SignalCompletion & ForceAbort
        private void ProcessCompletion()
        {
            // Re hookup cancellation delegate
            this.state.CancelDelegate = this.previousCancellationDelegate;

            // clear references
            this.src = null;
            this.dest = null;
            this.currentReadBuff = null;
            this.currentWriteBuff = null;

            try
            {
                if (this.timer != null)
                {
                    this.timer.Dispose();
                    this.timer = null;
                }
            }
            catch (Exception)
            {
                // no op
            }

            if (this.state.ExceptionRef == null &&
                this.operationContext.StreamCopyState != null &&
                this.operationContext.StreamCopyState.Md5HashRef != null)
            {
                try
                {
                    this.operationContext.StreamCopyState.Md5 = this.operationContext.StreamCopyState.Md5HashRef.ComputeHash();
                }
                catch (Exception)
                {
                    // no op
                }
                finally
                {
                    this.operationContext.StreamCopyState.Md5HashRef = null;
                }
            }

            if (this.completedDel != null)
            {
                try
                {
                    this.completedDel(this.state);
                }
                catch (Exception ex)
                {
                    this.state.ExceptionRef = ex;
                }
            }
        }

        private bool ShouldDispatchNextOperation()
        {
            if (this.maxLength.HasValue && this.state.OperationContext.StreamCopyState.Length > this.maxLength.Value)
            {
                this.state.ExceptionRef = new ArgumentOutOfRangeException("stream");
            }
            else if (this.maxCopyTime.HasValue && DateTime.Now >= this.maxCopyTime.Value)
            {
                this.state.ExceptionRef = Exceptions.GenerateTimeoutException(this.state.OperationContext.CurrentResult, null);
            }
            else if (this.state.CancelRequested)
            {
                this.state.ExceptionRef = Exceptions.GenerateCancellationException(this.state.OperationContext.CurrentResult, null);
            }

            // note cancellation will new up a exception and store it, so this will be not null;
            // continue if no exceptions so far
            return !this.cancelRequested && this.state.ExceptionRef == null;
        }

        private void ProcessEndRead(IAsyncResult res)
        {
            this.readRes = null;
            this.lastReadCount = this.src.EndRead(res);

            this.state.CompletedSynchronously = this.state.CompletedSynchronously && res.CompletedSynchronously;

            if (this.lastReadCount > 0)
            {
                this.readBufferFull = true;
            }
        }

        private void ProcessEndWrite(IAsyncResult res, byte[] buffer, int offset, int count)
        {
            this.writeRes = null;
            this.dest.EndWrite(res);

            this.state.CompletedSynchronously = this.state.CompletedSynchronously && res.CompletedSynchronously;

            if (this.operationContext.StreamCopyState != null)
            {
                this.operationContext.StreamCopyState.Length += count;

                if (this.operationContext.StreamCopyState.Md5HashRef != null)
                {
                    this.operationContext.StreamCopyState.Md5HashRef.UpdateHash(buffer, offset, count);
                }
            }
        }

        private void ConsumeReadBuffer()
        {
            this.readBufferFull = false;

            // The buffer swap saves us a memcopy of the data in readBuff.
            byte[] tempBuff = null;
            tempBuff = this.currentReadBuff;
            this.currentReadBuff = this.currentWriteBuff;
            this.currentWriteBuff = tempBuff;

            this.currentWriteCount = this.lastReadCount;
        }

        private bool IsCopyComplete()
        {
            return this.lastReadCount == 0 && !this.readBufferFull;
        }
        #endregion
    }
}
