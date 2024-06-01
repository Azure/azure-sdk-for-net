// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Buffers;
using Azure.Core.Serialization;

namespace Azure.Core
{
    /// <summary>
    /// Represents the content sent as part of the <see cref="Request"/>.
    /// </summary>
    public abstract class RequestContent : BinaryContent
    {
        internal const string SerializationRequiresUnreferencedCode = "This method uses reflection-based serialization which is incompatible with trimming. Try using one of the 'Create' overloads that doesn't wrap a serialized version of an object.";
        private static readonly Encoding s_UTF8NoBomEncoding = new UTF8Encoding(false);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="Stream"/>.</returns>
        public static new RequestContent Create(Stream stream) => new StreamContent(stream);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps an <see cref="Array"/>of <see cref="Byte"/>.
        /// </summary>
        /// <param name="bytes">The <see cref="Array"/>of <see cref="Byte"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps provided <see cref="Array"/>of <see cref="Byte"/>.</returns>
        public static RequestContent Create(byte[] bytes) => new ArrayContent(bytes, 0, bytes.Length);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps an <see cref="Array"/>of <see cref="Byte"/>.
        /// </summary>
        /// <param name="bytes">The <see cref="Array"/>of <see cref="Byte"/> to use.</param>
        /// <param name="index">The offset in <paramref name="bytes"/> to start from.</param>
        /// <param name="length">The length of the segment to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps provided <see cref="Array"/>of <see cref="Byte"/>.</returns>
        public static RequestContent Create(byte[] bytes, int index, int length) => new ArrayContent(bytes, index, length);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="Stream"/>.
        /// </summary>
        /// <param name="bytes">The <see cref="ReadOnlyMemory{T}"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="ReadOnlyMemory{T}"/>.</returns>
        public static RequestContent Create(ReadOnlyMemory<byte> bytes) => new MemoryContent(bytes);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="ReadOnlySequence{T}"/>.
        /// </summary>
        /// <param name="bytes">The <see cref="ReadOnlySequence{T}"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="ReadOnlySequence{T}"/>.</returns>
        public static RequestContent Create(ReadOnlySequence<byte> bytes) => new ReadOnlySequenceContent(bytes);

        /// <summary>
        /// Creates a RequestContent representing the UTF-8 Encoding of the given <see cref="string"/>/
        /// </summary>
        /// <param name="content">The <see cref="string"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="string"/>.</returns>
        /// <remarks>The returned content represents the UTF-8 Encoding of the given string.</remarks>
        public static RequestContent Create(string content) => Create(s_UTF8NoBomEncoding.GetBytes(content));

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="content">The <see cref="BinaryData"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="BinaryData"/>.</returns>
        public static new RequestContent Create(BinaryData content) => new MemoryContent(content.ToMemory());

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="DynamicData"/>.
        /// </summary>
        /// <param name="content">The <see cref="DynamicData"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="DynamicData"/>.</returns>
        public static RequestContent Create(DynamicData content) => new DynamicDataContent(content);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="IPersistableModel{T}"/>.
        /// </summary>
        /// <param name="model">The <see cref="IPersistableModel{T}"/> to write.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a a <see cref="IPersistableModel{T}"/>.</returns>
        public static new RequestContent Create<T>(T model, ModelReaderWriterOptions? options = default) where T : IPersistableModel<T>
            => new BinaryContentAdapter(BinaryContent.Create(model, options));

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a serialized version of an object.
        /// </summary>
        /// <param name="serializable">The <see cref="object"/> to serialize.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a serialized version of the object.</returns>
        [RequiresUnreferencedCode(SerializationRequiresUnreferencedCode)]
        [RequiresDynamicCode(SerializationRequiresUnreferencedCode)]
        public static RequestContent Create(object serializable) => Create(serializable, JsonObjectSerializer.Default);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a serialized version of an object.
        /// </summary>
        /// <param name="serializable">The <see cref="object"/> to serialize.</param>
        /// <param name="serializer">The <see cref="ObjectSerializer"/> to use to convert the object to bytes. If not provided, <see cref="JsonObjectSerializer"/> is used.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a serialized version of the object.</returns>
        [RequiresUnreferencedCode(SerializationRequiresUnreferencedCode)]
        [RequiresDynamicCode(SerializationRequiresUnreferencedCode)]
        public static RequestContent Create(object serializable, ObjectSerializer? serializer) => Create((serializer ?? JsonObjectSerializer.Default).Serialize(serializable));

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a serialized version of an object.
        /// </summary>
        /// <param name="serializable">The <see cref="object"/> to serialize.</param>
        /// <param name="propertyNameFormat">The format to use for property names in the serialized content.</param>
        /// <param name="dateTimeFormat">The format to use for DateTime and DateTimeOffset values in the serialized content.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a serialized version of the object.</returns>
        [RequiresUnreferencedCode(SerializationRequiresUnreferencedCode)]
        [RequiresDynamicCode(SerializationRequiresUnreferencedCode)]
        public static RequestContent Create(object serializable, JsonPropertyNames propertyNameFormat, string dateTimeFormat = DynamicData.RoundTripFormat)
        {
            DynamicDataOptions options = new()
            {
                PropertyNameFormat = propertyNameFormat,
                DateTimeFormat = dateTimeFormat
            };
            JsonSerializerOptions serializerOptions = DynamicDataOptions.ToSerializerOptions(options);
            ObjectSerializer serializer = new JsonObjectSerializer(serializerOptions);
            return Create(serializer.Serialize(serializable));
        }

        /// <summary>
        /// Creates a RequestContent representing the UTF-8 Encoding of the given <see cref="string"/>.
        /// </summary>
        /// <param name="content">The <see cref="string"/> to use.</param>
        public static implicit operator RequestContent(string content) => Create(content);

        /// <summary>
        /// Creates a RequestContent that wraps a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="content">The <see cref="BinaryData"/> to use.</param>
        public static implicit operator RequestContent(BinaryData content) => Create(content);

        /// <summary>
        /// Creates a RequestContent that wraps a <see cref="DynamicData"/>.
        /// </summary>
        /// <param name="content">The <see cref="DynamicData"/> to use.</param>
        public static implicit operator RequestContent(DynamicData content) => Create(content);

        private sealed class StreamContent : RequestContent
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
                        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                        var read = _stream.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                        { break; }
                        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
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

        private sealed class ArrayContent : RequestContent
        {
            private readonly byte[] _bytes;

            private readonly int _contentStart;

            private readonly int _contentLength;

            public ArrayContent(byte[] bytes, int index, int length)
            {
                _bytes = bytes;
                _contentStart = index;
                _contentLength = length;
            }

            public override void Dispose() { }

            public override void WriteTo(Stream stream, CancellationToken cancellation)
            {
                stream.Write(_bytes, _contentStart, _contentLength);
            }

            public override bool TryComputeLength(out long length)
            {
                length = _contentLength;
                return true;
            }

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
            {
#pragma warning disable CA1835 // WriteAsync(Memory<>) overload is not available in all targets
                await stream.WriteAsync(_bytes, _contentStart, _contentLength, cancellation).ConfigureAwait(false);
#pragma warning restore // WriteAsync(Memory<>) overload is not available in all targets
            }
        }

        private sealed class MemoryContent : RequestContent
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

        private sealed class ReadOnlySequenceContent : RequestContent
        {
            private readonly ReadOnlySequence<byte> _bytes;

            public ReadOnlySequenceContent(ReadOnlySequence<byte> bytes)
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

        private sealed class DynamicDataContent : RequestContent
        {
            private readonly DynamicData _data;

            public DynamicDataContent(DynamicData data) => _data = data;

            public override void Dispose()
            {
                _data.Dispose();
            }

            public override void WriteTo(Stream stream, CancellationToken cancellation)
            {
                _data.WriteTo(stream);
            }

            public override bool TryComputeLength(out long length)
            {
                length = default;
                return false;
            }

            public override Task WriteToAsync(Stream stream, CancellationToken cancellation)
            {
                _data.WriteTo(stream);
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// This adapter adapts the System.ClientModel BinaryContent type to
        /// the Azure.Core RequestContent interface, so that it can be used as
        /// though it were a RequestContent in Azure.Core.
        /// </summary>
        internal sealed class BinaryContentAdapter : RequestContent
        {
            private readonly BinaryContent _content;

            public BinaryContentAdapter(BinaryContent content)
            {
                _content = content;
            }

            public override void Dispose()
                => _content?.Dispose();

            public override bool TryComputeLength(out long length)
                => _content.TryComputeLength(out length);

            public override void WriteTo(Stream stream, CancellationToken cancellationToken)
                => _content.WriteTo(stream, cancellationToken);

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
                => await _content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
        }
    }
}
