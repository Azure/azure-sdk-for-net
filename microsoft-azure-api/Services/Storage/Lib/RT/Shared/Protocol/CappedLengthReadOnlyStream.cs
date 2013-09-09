// -----------------------------------------------------------------------------------------
// <copyright file="CappedLengthReadOnlyStream.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Shared.Protocol
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    internal class CappedLengthReadOnlyStream : Stream
    {
        private readonly Stream wrappedStream;
        private long cappedLength;

        public CappedLengthReadOnlyStream(Stream wrappedStream, long cappedLength)
        {
            if (!wrappedStream.CanSeek || !wrappedStream.CanRead)
            {
                throw new NotSupportedException();
            }
            
            this.wrappedStream = wrappedStream;
            this.cappedLength = Math.Min(cappedLength, this.wrappedStream.Length);
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
                return false;
            }
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override long Length
        {
            get
            {
                return this.cappedLength;
            }
        }

        public override long Position
        {
            get
            {               
                return this.wrappedStream.Position;
            }

            set
            {
                this.wrappedStream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {        
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            long remainingBytes = this.cappedLength > this.Position ? this.cappedLength - this.Position : 0;
            if (count > remainingBytes)
            {
                count = (int)remainingBytes;
            }

            return this.wrappedStream.Read(buffer, offset, count);
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            long remainingBytes = this.cappedLength > this.Position ? this.cappedLength - this.Position : 0;
            if (count > remainingBytes)
            {
                count = (int)remainingBytes;
            }
            
            return this.wrappedStream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.wrappedStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            if (value < 0 || value > this.Length)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            
            this.cappedLength = value;
        }
    }
}