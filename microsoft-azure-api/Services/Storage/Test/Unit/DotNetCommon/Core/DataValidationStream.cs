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
        private int delayInMs;
        private int currentOffset;

        internal Exception LastException { get; private set; }
        internal int ReadCallCount { get; private set; }
        internal int WriteCallCount { get; private set; }

        public DataValidationStream(byte[] streamContents, bool completeSynchronously, int delayInMs)
        {
            this.streamContents = streamContents;
            this.completeSynchronously = completeSynchronously;
            this.delayInMs = delayInMs;
            this.currentOffset = 0;
            this.LastException = null;
            this.ReadCallCount = 0;
            this.WriteCallCount = 0;
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
                return true;
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
                return this.streamContents.Length;
            }
        }

        public override long Position
        {
            get
            {
                return this.currentOffset;
            }
            set
            {
                this.currentOffset = (int)value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            this.ReadCallCount++;
            Thread.Sleep(this.delayInMs);
            
            count = Math.Min(count, this.streamContents.Length - this.currentOffset);
            Buffer.BlockCopy(this.streamContents, this.currentOffset, buffer, offset, count);
            
            this.currentOffset += count;
            return count;
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            ChainedAsyncResult<int> result = new ChainedAsyncResult<int>(callback, state);

            if (this.completeSynchronously)
            {
                result.UpdateCompletedSynchronously(this.completeSynchronously);
                result.Result = this.Read(buffer, offset, count);
                result.OnComplete();
            }
            else
            {
                ThreadPool.QueueUserWorkItem(_ =>
                    {
                        result.UpdateCompletedSynchronously(this.completeSynchronously);
                        result.Result = this.Read(buffer, offset, count);
                        result.OnComplete();
                    },
                    null);
            }

            return result;
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            ChainedAsyncResult<int> result = (ChainedAsyncResult<int>)asyncResult;
            result.End();
            return result.Result;
        }

        public override long Seek(long offset, SeekOrigin origin)
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
                    CommonUtils.ArgumentOutOfRange("origin", origin);
                    throw new ArgumentOutOfRangeException();
            }

            CommonUtils.AssertInBounds("offset", newOffset, 0, this.Length);

            this.currentOffset = (int)newOffset;

            return this.currentOffset;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
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
            ChainedAsyncResult<NullType> result = new ChainedAsyncResult<NullType>(callback, state);

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
            ChainedAsyncResult<NullType> result = (ChainedAsyncResult<NullType>)asyncResult;
            result.End();
        }
    }
}
