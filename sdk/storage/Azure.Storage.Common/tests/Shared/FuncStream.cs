// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Tests
{
    /// <summary>
    /// Stream that executes a function on any operation.
    /// </summary>
    public class FuncStream : Stream
    {
        private Stream _innerStream;
        public Func<Task> _action;

        public FuncStream(Stream inner, Func<Task> action)
        {
            _innerStream = inner;
            _action = action;
        }

        public override bool CanRead => _innerStream.CanRead;
        public override bool CanSeek => _innerStream.CanSeek;
        public override bool CanWrite => _innerStream.CanWrite;
        public override long Length => _innerStream.Length;

        public override long Position
        {
            get => _innerStream.Position;
            set => _innerStream.Position = value;
        }

        public override long Seek(long offset, SeekOrigin origin) =>
            _innerStream.Seek(offset, origin);

        public override void SetLength(long value) =>
            _innerStream.SetLength(value);

        public override void Flush()
        {
            _action().GetAwaiter().GetResult();
            _innerStream.Flush();
        }

        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            await _action();
            await _innerStream.FlushAsync(cancellationToken);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            _action().GetAwaiter().GetResult();
            return _innerStream.Read(buffer, offset, count);
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await _action();
            return await _innerStream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _action().GetAwaiter().GetResult();
            _innerStream.Write(buffer, offset, count);
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await _action();
            await _innerStream.WriteAsync(buffer, offset, count);
        }

        public override async Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            await _action();
            await _innerStream.CopyToAsync(destination, bufferSize, cancellationToken);
        }
    }
}
