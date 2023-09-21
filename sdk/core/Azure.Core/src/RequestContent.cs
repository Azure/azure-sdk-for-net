// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.ServiceModel.Rest.Core;
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
    public abstract class RequestContent : RequestBody
    {
        private static readonly Encoding s_UTF8NoBomEncoding = new UTF8Encoding(false);

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
        public static RequestContent Create(BinaryData content) => new MemoryContent(content.ToMemory());

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="DynamicData"/>.
        /// </summary>
        /// <param name="content">The <see cref="DynamicData"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="DynamicData"/>.</returns>
        public static RequestContent Create(DynamicData content) => new DynamicDataContent(content);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a serialized version of an object.
        /// </summary>
        /// <param name="serializable">The <see cref="object"/> to serialize.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a serialized version of the object.</returns>
        public static RequestContent Create(object serializable) => Create(serializable, JsonObjectSerializer.Default);

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a serialized version of an object.
        /// </summary>
        /// <param name="serializable">The <see cref="object"/> to serialize.</param>
        /// <param name="serializer">The <see cref="ObjectSerializer"/> to use to convert the object to bytes. If not provided, <see cref="JsonObjectSerializer"/> is used.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a serialized version of the object.</returns>
        public static RequestContent Create(object serializable, ObjectSerializer? serializer) => Create((serializer ?? JsonObjectSerializer.Default).Serialize(serializable));

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a serialized version of an object.
        /// </summary>
        /// <param name="serializable">The <see cref="object"/> to serialize.</param>
        /// <param name="propertyNameFormat">The format to use for property names in the serialized content.</param>
        /// <param name="dateTimeFormat">The format to use for DateTime and DateTimeOffset values in the serialized content.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a serialized version of the object.</returns>
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
    }
}
