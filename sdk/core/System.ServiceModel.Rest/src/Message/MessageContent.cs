// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using System.ServiceModel.Rest.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core
{
    public abstract class MessageContent : IDisposable
    {
        /// <summary>
        /// Creates an instance of <see cref="MessageContent"/> that wraps a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to use.</param>
        /// <returns>An instance of <see cref="MessageContent"/> that wraps a <see cref="Stream"/>.</returns>
        public static MessageContent CreateContent(Stream stream) => new StreamContent(stream);

        /// <summary>
        /// Creates an instance of <see cref="MessageContent"/> that wraps a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="content">The <see cref="BinaryData"/> to use.</param>
        /// <returns>An instance of <see cref="MessageContent"/> that wraps a <see cref="BinaryData"/>.</returns>
        public static MessageContent CreateContent(BinaryData content) => new MemoryContent(content.ToMemory());

        /// <summary>
        /// Writes contents of this object to an instance of <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cancellation">To cancellation token to use.</param>
        public abstract Task WriteToAsync(Stream stream, CancellationToken cancellation);

        /// <summary>
        /// Writes contents of this object to an instance of <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cancellation">To cancellation token to use.</param>
        public abstract void WriteTo(Stream stream, CancellationToken cancellation);

        /// <summary>
        /// Attempts to compute the length of the underlying content, if available.
        /// </summary>
        /// <param name="length">The length of the underlying data.</param>
        public abstract bool TryComputeLength(out long length);

        /// <inheritdoc/>
        public abstract void Dispose();

        // TODO: Note, this is copied from RequestContent.  When we can remove the corresponding
        // shared source file, we should make sure there is only one copy of this moving forward.
        private sealed class StreamContent : MessageContent
        {
            private const int CopyToBufferSize = 81920;

            private readonly Stream _stream;

            private readonly long _origin;

            public StreamContent(Stream stream)
            {
                if (!stream.CanSeek)
                    throw new ArgumentException("stream must be seekable", nameof(stream));
                _origin = stream.Position;
                _stream = stream;
            }

            public override void WriteTo(Stream stream, CancellationToken cancellationToken)
            {
                _stream.Seek(_origin, SeekOrigin.Begin);

                // this is not using CopyTo so that we can honor cancellations.
                byte[] buffer = ArrayPool<byte>.Shared.Rent(CopyToBufferSize);
                try
                {
                    while (true)
                    {
                        ClientUtilities.ThrowIfCancellationRequested(cancellationToken);
                        var read = _stream.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                        { break; }
                        ClientUtilities.ThrowIfCancellationRequested(cancellationToken);
                        stream.Write(buffer, 0, read);
                    }
                }
                finally
                {
                    stream.Flush();
                    ArrayPool<byte>.Shared.Return(buffer, true);
                }
            }

            public override bool TryComputeLength(out long length)
            {
                if (_stream.CanSeek)
                {
                    length = _stream.Length - _origin;
                    return true;
                }
                length = 0;
                return false;
            }

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
            {
                _stream.Seek(_origin, SeekOrigin.Begin);
                await _stream.CopyToAsync(stream, CopyToBufferSize, cancellation).ConfigureAwait(false);
            }

            public override void Dispose()
            {
                _stream.Dispose();
            }
        }

        private sealed class MemoryContent : MessageContent
        {
            private readonly ReadOnlyMemory<byte> _bytes;

            public MemoryContent(ReadOnlyMemory<byte> bytes)
                => _bytes = bytes;

            public override void Dispose() { }

            public override void WriteTo(Stream stream, CancellationToken cancellation)
            {
                byte[] buffer = _bytes.ToArray();
                stream.Write(buffer, 0, buffer.Length);
            }

            public override bool TryComputeLength(out long length)
            {
                length = _bytes.Length;
                return true;
            }

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
            {
                await stream.WriteAsync(_bytes, cancellation).ConfigureAwait(false);
            }
        }
    }
}