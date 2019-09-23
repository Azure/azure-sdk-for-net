// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A read-only stream. Wraps a <see cref="Stream"/> with an upper limit on how many bytes can be read.
    /// </summary>
    internal class LengthLimitingStream : Stream
    {
        private readonly Stream _wrappedStream;
        private long? _maxLength;
        private long _bytesRead = 0;

        public LengthLimitingStream(Stream wrappedStream, long? length = default)
        {
            this._wrappedStream = wrappedStream;
            this._maxLength = length;
        }

        public override bool CanRead => this._wrappedStream.CanRead;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => this._maxLength.HasValue ? this._maxLength.Value : this._wrappedStream.Length;

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush() => this._wrappedStream.Flush();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override int Read(byte[] buffer, int offset, int count)
        {
            count = this.Clamp(count);

            var result = this._wrappedStream.Read(buffer, offset, count);
            this._bytesRead += result;
            return result;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken token)
        {
            count = this.Clamp(count);

            var result = await _wrappedStream.ReadAsync(buffer, offset, count, token).ConfigureAwait(false);
            this._bytesRead += result;
            return result;
        }

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            _wrappedStream.Dispose();
        }

        private int Clamp(int count)
        {
            if (this._maxLength.HasValue)
            {
                return (int)Math.Min(count, this._maxLength.Value - this._bytesRead);
            }

            return count;
        }
    }
}
