// -----------------------------------------------------------------------------------------
// <copyright file="DataValidationStream.cs" company="Microsoft">
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

using System;
using System.IO;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    public class DataValidationStream : Stream
    {
        private byte[] streamContents;
        private bool completeSynchronously;
        private bool isSeekable;
        private int delayInMs;
        private int currentOffset;
        private int allowedSuccessfulRequests;

        internal Exception LastException { get; private set; }
        internal int ReadCallCount { get; private set; }
        internal int WriteCallCount { get; private set; }

        public DataValidationStream(byte[] streamContents, bool completeSynchronously, int delayInMs, int allowedSuccessfulRequests, bool seekable)
        {
            this.streamContents = streamContents;
            this.completeSynchronously = completeSynchronously;
            this.delayInMs = delayInMs;
            this.allowedSuccessfulRequests = allowedSuccessfulRequests;
            this.currentOffset = 0;
            this.LastException = null;
            this.ReadCallCount = 0;
            this.WriteCallCount = 0;
            this.isSeekable = seekable;
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return this.isSeekable;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override void Flush()
        {
        }

        public override long Length
        {
            get
            {
                if (!this.isSeekable)
                {
                    throw new NotSupportedException();
                }

                return this.streamContents.Length;
            }
        }

        public override long Position
        {
            get
            {
                if (!this.isSeekable)
                {
                    throw new NotSupportedException();
                }

                return this.currentOffset;
            }
            set
            {
                if (!this.isSeekable)
                {
                    throw new NotSupportedException();
                }

                this.currentOffset = (int)value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            this.FailRequestIfNeeded();

            this.ReadCallCount++;
            Thread.Sleep(this.delayInMs);
            
            count = Math.Min(count, this.streamContents.Length - this.currentOffset);
            Buffer.BlockCopy(this.streamContents, this.currentOffset, buffer, offset, count);
            
            this.currentOffset += count;
            return count;
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            StorageAsyncResult<int> result = new StorageAsyncResult<int>(callback, state);

            if (this.completeSynchronously)
            {
                result.UpdateCompletedSynchronously(this.completeSynchronously);
                try
                {
                    result.Result = this.Read(buffer, offset, count);
                    result.OnComplete();
                }
                catch (Exception e)
                {
                    result.OnComplete(e);
                }
            }
            else
            {
                ThreadPool.QueueUserWorkItem(_ =>
                    {
                        result.UpdateCompletedSynchronously(this.completeSynchronously);
                        try
                        {
                            result.Result = this.Read(buffer, offset, count);
                            result.OnComplete();
                        }
                        catch (Exception e)
                        {
                            result.OnComplete(e);
                        }
                    },
                    null);
            }

            return result;
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            StorageAsyncResult<int> result = (StorageAsyncResult<int>)asyncResult;
            result.End();
            return result.Result;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (!this.isSeekable)
            {
                throw new NotSupportedException();
            }

            return this.ForceSeek(offset, origin);
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.FailRequestIfNeeded();
            
            this.WriteCallCount++;
            Thread.Sleep(this.delayInMs);

            for (int i = 0; i < count; i++)
            {
                if (this.streamContents[this.currentOffset + i] != buffer[offset + i])
                {
                    this.LastException = new InvalidDataException(string.Format("MISMATCH: Offset: {0}   CompleteSync: {1}   DelayInMs: {2}",
                        this.currentOffset + i,
                        this.completeSynchronously,
                        this.delayInMs));

                    throw this.LastException;
                }
            }

            this.currentOffset += count;
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            StorageAsyncResult<NullType> result = new StorageAsyncResult<NullType>(callback, state);

            if (this.completeSynchronously)
            {
                result.UpdateCompletedSynchronously(this.completeSynchronously);
                try
                {
                    this.Write(buffer, offset, count);
                    result.OnComplete();
                }
                catch (Exception e)
                {
                    result.OnComplete(e);
                }
            }
            else
            {
                ThreadPool.QueueUserWorkItem(_ =>
                    {
                        result.UpdateCompletedSynchronously(this.completeSynchronously);
                        try
                        {
                            this.Write(buffer, offset, count);
                            result.OnComplete();
                        }
                        catch (Exception e)
                        {
                            result.OnComplete(e);
                        }
                    },
                    null);
            }

            return result;
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> result = (StorageAsyncResult<NullType>)asyncResult;
            result.End();
        }

        private void FailRequestIfNeeded()
        {
            if (this.allowedSuccessfulRequests == 0)
            {
                this.LastException = new IOException();
                throw this.LastException;
            }
            else if (this.allowedSuccessfulRequests > 0)
            {
                this.allowedSuccessfulRequests--;
            }
        }

        public long ForceSeek(long offset, SeekOrigin origin)
        {
            long newOffset;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newOffset = offset;
                    break;

                case SeekOrigin.Current:
                    newOffset = this.currentOffset + offset;
                    break;

                case SeekOrigin.End:
                    newOffset = this.Length + offset;
                    break;

                default:
                    CommonUtility.ArgumentOutOfRange("origin", origin);
                    throw new ArgumentOutOfRangeException();
            }

            CommonUtility.AssertInBounds("offset", newOffset, 0, this.Length);

            this.currentOffset = (int)newOffset;

            return this.currentOffset;
        }
    }
}
