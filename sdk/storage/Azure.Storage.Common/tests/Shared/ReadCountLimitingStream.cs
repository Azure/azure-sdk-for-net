// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Tests
{
    /// <summary>
    /// Checksums stream contents as the stream is progressed through.
    /// Limited seek support on read. No seek support on write.
    /// </summary>
    internal class ReadCountLimitingStream : Stream
    {
        /// <summary>
        /// Function to limit the given count parameter based on inputs to Read().
        /// </summary>
        /// <returns>A new value for count, no larger than the original.</returns>
        public delegate int LimitCount(byte[] buffer, int offset, int count);

        private readonly Stream _stream;
        private readonly LimitCount _limiter;

        public override bool CanRead => _stream.CanRead;

        public override bool CanWrite => _stream.CanWrite;

        public override bool CanSeek => _stream.CanSeek;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; set => _stream.Position = value; }

        public override bool CanTimeout => _stream.CanTimeout;

        public override int ReadTimeout { get => _stream.ReadTimeout; set => _stream.ReadTimeout = value; }

        public override int WriteTimeout { get => _stream.WriteTimeout; set => _stream.WriteTimeout = value; }

        private ReadCountLimitingStream(Stream stream, LimitCount limiter)
        {
            _stream = stream;
            _limiter = limiter;
        }

        public static Stream Create(Stream innerStream, int limit)
            => new ReadCountLimitingStream(innerStream, (buf, offset, count) => Math.Min(count, limit));

        public override int Read(byte[] buffer, int offset, int count)
        {
            int newCount = _limiter(buffer, offset, count);
            if (newCount > count)
            {
                throw new Exception("ReadCountLimitingStream limiter grew count parameter.");
            }
            return _stream.Read(buffer, offset, newCount);
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            int newCount = _limiter(buffer, offset, count);
            if (newCount > count)
            {
                throw new Exception("ReadCountLimitingStream limiter grew count parameter.");
            }
            return await _stream.ReadAsync(buffer, offset, newCount, cancellationToken);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await _stream.WriteAsync(buffer, offset, count, cancellationToken);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            await _stream.FlushAsync();
        }

        public override void Close()
        {
            _stream.Close();
        }
    }
}
