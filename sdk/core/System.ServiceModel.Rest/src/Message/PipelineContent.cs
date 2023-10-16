// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using System.ServiceModel.Rest.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core
{
    // I wish we could have the name MessageContent, but there is already
    // Azure.Messaging.MessageContent.
    public abstract class PipelineContent : IDisposable
    {
        // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
        private static BinaryData EmptyBinaryData = new(Array.Empty<byte>());
        internal static PipelineContent Empty = CreateContent(EmptyBinaryData);

        /// <summary>
        /// Creates an instance of <see cref="PipelineContent"/> that wraps a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to use.</param>
        /// <returns>An instance of <see cref="PipelineContent"/> that wraps a <see cref="Stream"/>.</returns>
        public static PipelineContent CreateContent(Stream stream) => new StreamPipelineContent(stream);

        /// <summary>
        /// Creates an instance of <see cref="PipelineContent"/> that wraps a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="content">The <see cref="BinaryData"/> to use.</param>
        /// <returns>An instance of <see cref="PipelineContent"/> that wraps a <see cref="BinaryData"/>.</returns>
        public static PipelineContent CreateContent(BinaryData content) => new MemoryPipelineContent(content.ToMemory());

        /// <summary>
        /// Attempts to compute the length of the underlying content, if available.
        /// </summary>
        /// <param name="length">The length of the underlying data.</param>
        public abstract bool TryComputeLength(out long length);

        /// <summary>
        /// Writes contents of this object to an instance of <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cancellationToken">To cancellation token to use.</param>
        public abstract Task WriteToAsync(Stream stream, CancellationToken cancellationToken);

        /// <summary>
        /// Writes contents of this object to an instance of <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cancellationToken">To cancellation token to use.</param>
        public abstract void WriteTo(Stream stream, CancellationToken cancellationToken);

        public static implicit operator BinaryData(PipelineContent content)
            => content.ToBinaryData();

        // This one is needed to allow JsonDocument.Parse(PipelineContent) to succeed
        // without a cast through BinaryData.
        public static implicit operator ReadOnlyMemory<byte>(PipelineContent content)
            => content.ToBinaryData();

        public static explicit operator Stream(PipelineContent content)
            => content.ToStream();

        internal virtual bool IsBuffered { get; }

        // This is virtual so we don't break the contract by adding an abstract method
        // but the default implementation can be optimized, so inheriting types should
        // override this if they can provide a better implementation.
        protected virtual BinaryData ToBinaryData(CancellationToken cancellationToken = default)
        {
            MemoryStream stream;

            if (TryComputeLength(out long length))
            {
                if (length >= int.MaxValue)
                {
                    throw new InvalidOperationException("Cannot create BinaryData from content with length > int.MaxLength.");
                }

                if (length == 0)
                {
                    return EmptyBinaryData;
                }

                stream = new MemoryStream((int)length);
            }
            else
            {
                stream = new MemoryStream();
            }

            WriteTo(stream, cancellationToken);
            stream.Position = 0;

            return BinaryData.FromStream(stream);
        }

        // TODO: cleanup - don't duplicate logic across sync and async and/or Stream/BinaryData
        protected virtual async Task<BinaryData> ToBinaryDataAsync(CancellationToken cancellationToken = default)
        {
            MemoryStream stream;

            if (TryComputeLength(out long length))
            {
                if (length >= int.MaxValue)
                {
                    throw new InvalidOperationException("Cannot create BinaryData from content with length > int.MaxLength.");
                }

                if (length == 0)
                {
                    return EmptyBinaryData;
                }

                stream = new MemoryStream((int)length);
            }
            else
            {
                stream = new MemoryStream();
            }

            await WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
            stream.Position = 0;

            return BinaryData.FromStream(stream);
        }

        protected virtual Stream ToStream(CancellationToken cancellationToken = default)
        {
            MemoryStream stream;

            if (TryComputeLength(out long length))
            {
                if (length >= int.MaxValue)
                {
                    throw new InvalidOperationException("Cannot create MemoryStream from content with length > int.MaxLength.");
                }

                stream = new MemoryStream((int)length);
            }
            else
            {
                stream = new MemoryStream();
            }

            WriteTo(stream, cancellationToken);
            stream.Position = 0;

            return stream;
        }

        protected virtual async Task<Stream> ToStreamAsync(CancellationToken cancellationToken = default)
        {
            MemoryStream stream;

            if (TryComputeLength(out long length))
            {
                if (length >= int.MaxValue)
                {
                    throw new InvalidOperationException("Cannot create MemoryStream from content with length > int.MaxLength.");
                }

                stream = new MemoryStream((int)length);
            }
            else
            {
                stream = new MemoryStream();
            }

            await WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
            stream.Position = 0;

            return stream;
        }

        /// <inheritdoc/>
        public abstract void Dispose();

        // TODO: Note, this is copied from RequestContent.  When we can remove the corresponding
        // shared source file, we should make sure there is only one copy of this moving forward.
        private sealed class StreamPipelineContent : PipelineContent
        {
            private const int CopyToBufferSize = 81920;

            private readonly Stream _stream;

            // TODO: why did we need origin?
            // It may be that we need to split out ResponseStreamContent from
            // RequestStreamContent as part of the unification - that's ok :)

            public StreamPipelineContent(Stream stream)
            {
                _stream = stream;
            }

            internal override bool IsBuffered => _stream is MemoryStream;

            public override bool TryComputeLength(out long length)
            {
                if (_stream.CanSeek)
                {
                    length = _stream.Length;
                    return true;
                }

                length = default;
                return false;
            }

            public override void WriteTo(Stream stream, CancellationToken cancellationToken)
            {
                // This is not using CopyTo so that we can honor cancellations.
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

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
            {
                await _stream.CopyToAsync(stream, CopyToBufferSize, cancellation).ConfigureAwait(false);
            }

            protected override Stream ToStream(CancellationToken cancellationToken = default)
                => _stream;

            protected override Task<Stream> ToStreamAsync(CancellationToken cancellationToken = default)
                => Task.FromResult(_stream);

            public override void Dispose()
            {
                var stream = _stream;
                stream?.Dispose();
            }
        }

        // BinaryData holds ReadOnlyMemory<byte> so this is the type that works
        // with BinaryData in an optimized way.
        private sealed class MemoryPipelineContent : PipelineContent
        {
            private readonly ReadOnlyMemory<byte> _bytes;

            public MemoryPipelineContent(ReadOnlyMemory<byte> bytes)
            {
                _bytes = bytes;
            }

            internal override bool IsBuffered => true;

            public override bool TryComputeLength(out long length)
            {
                length = _bytes.Length;
                return true;
            }
            public override void WriteTo(Stream stream, CancellationToken cancellation)
            {
                byte[] buffer = _bytes.ToArray();
                stream.Write(buffer, 0, buffer.Length);
            }

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
                => await stream.WriteAsync(_bytes, cancellation).ConfigureAwait(false);

            protected override BinaryData ToBinaryData(CancellationToken cancellationToken = default)
                => BinaryData.FromBytes(_bytes);

            protected override Task<BinaryData> ToBinaryDataAsync(CancellationToken cancellationToken = default)
                => Task.FromResult(BinaryData.FromBytes(_bytes));

            public override void Dispose() { }
        }
    }
}