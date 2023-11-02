// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using System.Net.ClientModel.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.ClientModel.Core
{
    // I wish we could have the name MessageContent, but there is already
    // Azure.Messaging.MessageContent.
    public abstract class RequestBody : IDisposable
    {
        // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
        private static BinaryData EmptyBinaryData = new(Array.Empty<byte>());
        internal static RequestBody Empty = Create(EmptyBinaryData);

        /// <summary>
        /// Creates an instance of <see cref="RequestBody"/> that wraps a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to use.</param>
        /// <returns>An instance of <see cref="RequestBody"/> that wraps a <see cref="Stream"/>.</returns>
        public static RequestBody Create(Stream stream) => new StreamMessageBody(stream);

        /// <summary>
        /// Creates an instance of <see cref="RequestBody"/> that wraps a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="value">The <see cref="BinaryData"/> to use.</param>
        /// <returns>An instance of <see cref="RequestBody"/> that wraps a <see cref="BinaryData"/>.</returns>
        public static RequestBody Create(BinaryData value) => new BinaryDataMessageBody(value.ToMemory());

        /// <summary>
        /// Creates an instance of <see cref="RequestBody"/> that wraps a <see cref="IModel{T}"/>.
        /// </summary>
        /// <param name="model">The <see cref="IModel{T}"/> to write.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>An instance of <see cref="RequestBody"/> that wraps a <see cref="IModel{T}"/>.</returns>
        public static RequestBody Create(IModel<object> model, ModelReaderWriterOptions? options = default)
            => new ModelMessageBody(model, options ?? ModelReaderWriterOptions.DefaultWireOptions);

        /// <summary>
        /// Creates an instance of <see cref="RequestBody"/> that wraps a <see cref="IJsonModel{T}"/>.
        /// </summary>
        /// <param name="model">The <see cref="IJsonModel{T}"/> to write.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>An instance of <see cref="RequestBody"/> that wraps a <see cref="IJsonModel{T}"/>.</returns>
        public static RequestBody Create(IJsonModel<object> model, ModelReaderWriterOptions? options = default)
            => new JsonModelMessageBody(model, options ?? ModelReaderWriterOptions.DefaultWireOptions);

        /// <summary>
        /// Attempts to compute the length of the underlying body content, if available.
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

        public static explicit operator BinaryData(RequestBody body)
            => body.ToBinaryData();

        public static explicit operator Stream(RequestBody body)
            => body.ToStream();

        internal virtual bool IsBuffered { get; }

        // This is virtual so we don't break the contract by adding an abstract method
        // but the default implementation can be optimized, so inheriting types should
        // override this if they can provide a better implementation.
        protected virtual BinaryData ToBinaryData(CancellationToken cancellationToken = default)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            => ToBinaryDataSyncOrAsync(cancellationToken, async: false).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

        private async Task<BinaryData> ToBinaryDataSyncOrAsync(CancellationToken cancellationToken, bool async)
        {
            MemoryStream stream;

            if (TryComputeLength(out long length))
            {
                if (length >= int.MaxValue)
                {
                    throw new InvalidOperationException("Cannot create BinaryData from body with length > int.MaxLength.");
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

            if (async)
            {
                await WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                WriteTo(stream, cancellationToken);
            }

            stream.Position = 0;

            return BinaryData.FromStream(stream);
        }

        protected virtual Stream ToStream(CancellationToken cancellationToken = default)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            => ToStreamSyncOrAsync(cancellationToken, async: false).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

        private async Task<Stream> ToStreamSyncOrAsync(CancellationToken cancellationToken, bool async)
        {
            MemoryStream stream;

            if (TryComputeLength(out long length))
            {
                if (length >= int.MaxValue)
                {
                    throw new InvalidOperationException("Cannot create MemoryStream from body with length > int.MaxLength.");
                }

                stream = new MemoryStream((int)length);
            }
            else
            {
                stream = new MemoryStream();
            }

            if (async)
            {
                await WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                WriteTo(stream, cancellationToken);
            }

            stream.Position = 0;

            return stream;
        }

        private sealed class JsonModelMessageBody : RequestBody
        {
            private readonly IJsonModel<object> _model;
            private readonly ModelReaderWriterOptions _options;

            public JsonModelMessageBody(IJsonModel<object> model, ModelReaderWriterOptions options)
            {
                _model = model;
                _options = options;
            }

            private ModelWriter? _writer;
            private ModelWriter Writer => _writer ??= new ModelWriter(_model, _options);

            public override void Dispose() => _writer?.Dispose();

            public override void WriteTo(Stream stream, CancellationToken cancellation) => Writer.CopyTo(stream, cancellation);

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellation) => await Writer.CopyToAsync(stream, cancellation).ConfigureAwait(false);

            public override bool TryComputeLength(out long length) => Writer.TryComputeLength(out length);
        }

        private sealed class ModelMessageBody : RequestBody
        {
            private readonly IModel<object> _model;
            private readonly ModelReaderWriterOptions _options;

            public ModelMessageBody(IModel<object> model, ModelReaderWriterOptions options)
            {
                _model = model;
                _options = options;
            }

            public override void Dispose() { }

            private BinaryData? _data;
            private BinaryData Data => _data ??= _model.Write(_options);

#if NETFRAMEWORK || NETSTANDARD2_0
            private byte[]? _bytes;
            private byte[] Bytes => _bytes ??= Data.ToArray();

            public override void WriteTo(Stream stream, CancellationToken cancellation) => stream.Write(Bytes, 0, Bytes.Length);
#else
            public override void WriteTo(Stream stream, CancellationToken cancellation) => stream.Write(Data.ToMemory().Span);
#endif

            public override bool TryComputeLength(out long length)
            {
                length = Data.ToMemory().Length;
                return true;
            }

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellation) => await stream.WriteAsync(Data.ToMemory(), cancellation).ConfigureAwait(false);
        }

        private sealed class StreamMessageBody : RequestBody
        {
            private const int CopyToBufferSize = 81920;
            private readonly Stream _stream;

            public StreamMessageBody(Stream stream)
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
                        {
                            break;
                        }

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
                => await _stream.CopyToAsync(stream, CopyToBufferSize, cancellation).ConfigureAwait(false);

            protected override Stream ToStream(CancellationToken cancellationToken = default)
                => _stream;

            public override void Dispose()
            {
                var stream = _stream;
                stream?.Dispose();
            }
        }

        // BinaryData holds ReadOnlyMemory<byte> so this is the type that works
        // with BinaryData in an optimized way.
        private sealed class BinaryDataMessageBody : RequestBody
        {
            private readonly ReadOnlyMemory<byte> _bytes;

            public BinaryDataMessageBody(ReadOnlyMemory<byte> bytes)
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

            public override void Dispose() { }
        }

        /// <inheritdoc/>
        public abstract void Dispose();
    }
}