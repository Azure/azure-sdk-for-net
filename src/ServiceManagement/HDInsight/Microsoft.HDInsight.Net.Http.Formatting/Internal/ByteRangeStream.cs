// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Internal
{
    using System;
    using System.IO;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Stream which only exposes a read-only only range view of an 
    /// inner stream.
    /// </summary>
    internal class ByteRangeStream : DelegatingStream
    {
        // The offset stream position at which the range starts.
        private readonly long _lowerbounds;

        // The total number of bytes within the range. 
        private readonly long _totalCount;

        // The current number of bytes read into the range
        private long _currentCount;

        public ByteRangeStream(Stream innerStream, RangeItemHeaderValue range)
            : base(innerStream)
        {
            if (range == null)
            {
                throw Error.ArgumentNull("range");
            }
            if (!innerStream.CanSeek)
            {
                throw Error.Argument("innerStream", Resources.ByteRangeStreamNotSeekable, typeof(ByteRangeStream).Name);
            }
            if (innerStream.Length < 1)
            {
                throw Error.ArgumentOutOfRange("innerStream", innerStream.Length, Resources.ByteRangeStreamEmpty, typeof(ByteRangeStream).Name);
            }
            if (range.From.HasValue && range.From.Value > innerStream.Length)
            {
                throw Error.ArgumentOutOfRange("range", range.From, Resources.ByteRangeStreamInvalidFrom, innerStream.Length);
            }

            // Ranges are inclusive so 0-9 means the first 10 bytes
            long maxLength = innerStream.Length - 1;
            long upperbounds;
            if (range.To.HasValue)
            {
                if (range.From.HasValue)
                {
                    // e.g bytes=0-499 (the first 500 bytes offsets 0-499)
                    upperbounds = Math.Min(range.To.Value, maxLength);
                    this._lowerbounds = range.From.Value;
                }
                else
                {
                    // e.g bytes=-500 (the final 500 bytes)
                    upperbounds = maxLength;
                    this._lowerbounds = Math.Max(innerStream.Length - range.To.Value, 0);
                }
            }
            else
            {
                if (range.From.HasValue)
                {
                    // e.g bytes=500- (from byte offset 500 and up)
                    upperbounds = maxLength;
                    this._lowerbounds = range.From.Value;
                }
                else
                {
                    // e.g. bytes=- (invalid so will never get here)
                    upperbounds = maxLength;
                    this._lowerbounds = 0;
                }
            }

            this._totalCount = upperbounds - this._lowerbounds + 1;
            this.ContentRange = new ContentRangeHeaderValue(this._lowerbounds, upperbounds, innerStream.Length);
        }

        public ContentRangeHeaderValue ContentRange { get; private set; }

        public override long Length
        {
            get { return this._totalCount; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return base.BeginRead(buffer, offset, this.PrepareStreamForRangeRead(count), callback, state);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return base.Read(buffer, offset, this.PrepareStreamForRangeRead(count));
        }

        public override int ReadByte()
        {
            int effectiveCount = this.PrepareStreamForRangeRead(1);
            if (effectiveCount <= 0)
            {
                return -1;
            }
            return base.ReadByte();
        }

        public override void SetLength(long value)
        {
            throw Error.NotSupported(Resources.ByteRangeStreamReadOnly);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw Error.NotSupported(Resources.ByteRangeStreamReadOnly);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            throw Error.NotSupported(Resources.ByteRangeStreamReadOnly);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            throw Error.NotSupported(Resources.ByteRangeStreamReadOnly);
        }

        public override void WriteByte(byte value)
        {
            throw Error.NotSupported(Resources.ByteRangeStreamReadOnly);
        }

        /// <summary>
        /// Gets the 
        /// </summary>
        /// <param name="count">The count requested to be read by the caller.</param>
        /// <returns>The remaining bytes to read within the range defined for this stream.</returns>
        private int PrepareStreamForRangeRead(int count)
        {
            long effectiveCount = Math.Min(count, this._totalCount - this._currentCount);
            if (effectiveCount > 0)
            {
                // Check if we should update the stream position
                long position = this.InnerStream.Position;
                if (this._lowerbounds + this._currentCount != position)
                {
                    this.InnerStream.Position = this._lowerbounds + this._currentCount;
                }

                // Update current number of bytes read
                this._currentCount += effectiveCount;
            }

            // Effective count can never be bigger than int
            return (int)effectiveCount;
        }
    }
}
