// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    }

    internal static partial class StreamExtensions
    {
        public static Stream WithNoDispose(this Stream stream) => stream is NonDisposingStream ? stream : new NonDisposingStream(stream);
    }
}
