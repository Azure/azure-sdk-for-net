// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage
{
    internal class NonDisposingStream : Stream
    {
        private readonly Stream _innerStream;

        public NonDisposingStream(Stream innerStream) => _innerStream = innerStream;

        public override bool CanRead => _innerStream.CanRead;

        public override bool CanSeek => _innerStream.CanSeek;

        public override bool CanWrite => _innerStream.CanWrite;

        public override bool CanTimeout => _innerStream.CanTimeout;

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken) => _innerStream.CopyToAsync(destination, bufferSize, cancellationToken);

        public override long Length => _innerStream.Length;

        public override long Position { get => _innerStream.Position; set => _innerStream.Position = value; }

        public override void Flush() => _innerStream.Flush();

        public override Task FlushAsync(CancellationToken cancellationToken) => _innerStream.FlushAsync(cancellationToken);

        public override int Read(byte[] buffer, int offset, int count) => _innerStream.Read(buffer, offset, count);

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => _innerStream.ReadAsync(buffer, offset, count, cancellationToken);

        public override long Seek(long offset, SeekOrigin origin) => _innerStream.Seek(offset, origin);

        public override void SetLength(long value) => _innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _innerStream.Write(buffer, offset, count);

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => _innerStream.WriteAsync(buffer, offset, count, cancellationToken);

        public override int ReadByte() => _innerStream.ReadByte();

        public override void WriteByte(byte value) => _innerStream.WriteByte(value);

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) => _innerStream.BeginRead(buffer, offset, count, callback, state);

        public override int EndRead(IAsyncResult asyncResult) => _innerStream.EndRead(asyncResult);

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) => _innerStream.BeginWrite(buffer, offset, count, callback, state);

        public override void EndWrite(IAsyncResult asyncResult) => _innerStream.EndWrite(asyncResult);

        public override int ReadTimeout { get => _innerStream.ReadTimeout; set => _innerStream.ReadTimeout = value; }

        public override int WriteTimeout { get => _innerStream.WriteTimeout; set => _innerStream.WriteTimeout = value; }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER

        public override void CopyTo(Stream destination, int bufferSize) => _innerStream.CopyTo(destination, bufferSize);

        public override int Read(Span<byte> buffer) => _innerStream.Read(buffer);

        public override void Write(ReadOnlySpan<byte> buffer) => _innerStream.Write(buffer);

        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default) => _innerStream.WriteAsync(buffer, cancellationToken);

        public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default) => _innerStream.ReadAsync(buffer, cancellationToken);

#endif
    }

    internal static partial class StreamExtensions
    {
        public static Stream WithNoDispose(this Stream stream) => stream is NonDisposingStream ? stream : new NonDisposingStream(stream);
    }
}
