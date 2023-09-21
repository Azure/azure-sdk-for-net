﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using System.ServiceModel.Rest.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core
{
    /// <summary>
    /// TBD
    /// </summary>
    public abstract class RequestBody : IDisposable
    {
        /// <summary>
        /// Creates an instance of <see cref="RequestBody"/> that wraps a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to use.</param>
        /// <returns>An instance of <see cref="RequestBody"/> that wraps a <see cref="Stream"/>.</returns>
        public static RequestBody CreateFromStream(Stream stream) => new StreamBody(stream);

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
        private sealed class StreamBody : RequestBody
        {
            private const int CopyToBufferSize = 81920;

            private readonly Stream _stream;

            private readonly long _origin;

            public StreamBody(Stream stream)
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
    }
}
