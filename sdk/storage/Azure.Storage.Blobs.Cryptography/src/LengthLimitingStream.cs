// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized
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
        private readonly long? _maxLength;
        private long _bytesRead = 0;

        public LengthLimitingStream(Stream wrappedStream, long? length = default)
        {
            _wrappedStream = wrappedStream;
            _maxLength = length;
        }

        public override bool CanRead => _wrappedStream.CanRead;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => _bytesRead;

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush() => _wrappedStream.Flush();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override int Read(byte[] buffer, int offset, int count)
        {
            count = Clamp(count);

            var result = _wrappedStream.Read(buffer, offset, count);
            _bytesRead += result;
            return result;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken token)
        {
            count = Clamp(count);

            var result = await _wrappedStream.ReadAsync(buffer, offset, count, token).ConfigureAwait(false);
            _bytesRead += result;
            return result;
        }

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            _wrappedStream.Dispose();
        }

        /// <summary>
        /// If this stream has a max length set, ensure that the number of bytes to read is never greated than the
        /// remaining bytes to read before max length is hit.
        /// </summary>
        /// <param name="count">Number of desired bytes to read.</param>
        /// <returns>The adjusted number of bytes to read.</returns>
        private int Clamp(int count)
        {
            if (_maxLength.HasValue)
            {
                return (int)Math.Min(count, _maxLength.Value - _bytesRead);
            }

            return count;
        }
    }
}
