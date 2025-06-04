// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Buffers;
using Azure.Core.Serialization;
using Azure.Core.Pipeline;
using System.ClientModel.Primitives;
using System.Globalization;

namespace Azure.Core
{
    /// <summary>
    /// Represents the content sent as part of the <see cref="Request"/>.
    /// </summary>
    public abstract class RequestContent : IDisposable
    {
        internal const string SerializationRequiresUnreferencedCode = "This method uses reflection-based serialization which is incompatible with trimming. Try using one of the 'Create' overloads that doesn't wrap a serialized version of an object.";
        private static readonly Encoding s_UTF8NoBomEncoding = new UTF8Encoding(false);

        /// <summary>
        /// The content type of the binary content.
        /// </summary>
        public virtual string? ContentType { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a <see cref="Stream"/>.</returns>
        public static RequestContent Create(Stream stream) => new StreamContent(stream);

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
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, BinaryData content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            return new MultipartFormDataPartRequestContent(name, new MemoryContent(content.ToMemory()));
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, string content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            return new MultipartFormDataPartRequestContent(name, Create(s_UTF8NoBomEncoding.GetBytes(content)));
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, int content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            string value = content.ToString("G", CultureInfo.InvariantCulture);
            return CreateMultipartFormDataPart(name, value);
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, long content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            string value = content.ToString("G", CultureInfo.InvariantCulture);
            return CreateMultipartFormDataPart(name, value);
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, float content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            string value = content.ToString("G", CultureInfo.InvariantCulture);
            return CreateMultipartFormDataPart(name, value);
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, double content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            string value = content.ToString("G", CultureInfo.InvariantCulture);
            return CreateMultipartFormDataPart(name, value);
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, decimal content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            string value = content.ToString("G", CultureInfo.InvariantCulture);
            return CreateMultipartFormDataPart(name, value);
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, bool content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            string value = content ? "true" : "false";
            return CreateMultipartFormDataPart(name, value);
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, byte[] content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            return new MultipartFormDataPartRequestContent(name, new ArrayContent(content, 0, content.Length));
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="name">The name of the part.</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataPart(string name, FileRequestContent content)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            return new MultipartFormDataPartRequestContent(name, content);
        }
        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that contains the
        /// the provided <see cref="RequestContent"/> as multi-part form data.
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataContent(IEnumerable<RequestContent> parts)
        {
            Argument.AssertNotNull(parts, nameof(parts));

            return new MultiPartFormDataRequestContent(parts);
        }

        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that contains the
        /// the provided <see cref="RequestContent"/> as multi-part form data.
        /// </summary>
        /// <param name="boundary"></param>
        /// <param name="parts"></param>
        /// <returns></returns>
        public static RequestContent CreateMultipartFormDataContent(string boundary, IEnumerable<RequestContent> parts)
        {
            Argument.AssertNotNullOrEmpty(boundary, nameof(boundary));
            Argument.AssertNotNull(parts, nameof(parts));

            return new MultiPartFormDataRequestContent(boundary, parts);
        }

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

        /// <summary>
        /// Frees resources held by the <see cref="RequestContent"/> object.
        /// </summary>
        public abstract void Dispose();

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
        private sealed class MultiPartFormDataRequestContent : RequestContent
        {
            private readonly MultipartFormDataContent _multipartContent;

            private const int BoundaryLength = 70;
            private const string BoundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz";

            public MultiPartFormDataRequestContent(IEnumerable<RequestContent> parts)
                : this(CreateBoundary(), parts) { }

            public MultiPartFormDataRequestContent(string boundary, IEnumerable<RequestContent> parts)
            {
                Argument.AssertNotNullOrEmpty(boundary, nameof(boundary));
                Argument.AssertNotNull(parts, nameof(parts));

                _multipartContent = new MultipartFormDataContent(boundary);

                foreach (RequestContent part in parts)
                {
                    if (part is not MultipartFormDataPartRequestContent partRequestContent)
                    {
                        throw new InvalidOperationException($"The type is not a valid part: '{part.GetType()}'.");
                    }
                    Add(partRequestContent);
                }
            }

            public override string? ContentType
            {
                get
                {
                    Debug.Assert(_multipartContent.Headers.ContentType is not null);

                    return _multipartContent.Headers.ContentType!.ToString();
                }
            }

            public void Add(MultipartFormDataPartRequestContent content)
            {
                Argument.AssertNotNull(content, nameof(content));
                Argument.AssertNotNull(content.Name, nameof(content.Name));

                HttpContent httpContent = new HttpContentAdapter(content);
                if (content.ContentType is not null)
                {
                    httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse(content.ContentType);
                }

                string? filename = content.Content is FileRequestContent fileContent ? fileContent.Filename : null;
                Add(httpContent, content.Name, filename);
            }

            private void Add(HttpContent content, string name, string? fileName = default)
            {
                Argument.AssertNotNull(content, nameof(content));
                Argument.AssertNotNull(name, nameof(name));

                if (fileName is not null)
                {
                    _multipartContent.Add(content, name, fileName);
                }
                else
                {
                    _multipartContent.Add(content, name);
                }
            }

#if NET6_0_OR_GREATER
    private static string CreateBoundary() =>
        string.Create(BoundaryLength, 0, (chars, _) =>
        {
            Span<byte> random = stackalloc byte[BoundaryLength];
            Random.Shared.NextBytes(random);

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = BoundaryValues[random[i] % BoundaryValues.Length];
            }
        });
#else
            private static readonly Random _random = new();

            private static string CreateBoundary()
            {
                Span<char> chars = stackalloc char[BoundaryLength];

                byte[] random = new byte[BoundaryLength];
                lock (_random)
                {
                    _random.NextBytes(random);
                }
                const int Mask = 255 >> 2;
                Debug.Assert(BoundaryValues.Length - 1 == Mask);

                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i] = BoundaryValues[random[i] & Mask];
                }

                return chars.ToString();
            }
#endif

            public override bool TryComputeLength(out long length)
            {
                if (_multipartContent.Headers.ContentLength is long contentLength)
                {
                    length = contentLength;
                    return true;
                }

                length = 0;
                return false;
            }

            public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
            {
#if NET5_0_OR_GREATER
                _multipartContent.CopyTo(stream, default, cancellationToken);
#else
#pragma warning disable AZC0107 // DO NOT call public asynchronous method in synchronous scope.
                _multipartContent.CopyToAsync(stream, default).EnsureCompleted();
#pragma warning restore AZC0107 // DO NOT call public asynchronous method in synchronous scope.
#endif
            }

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
            {
#if NET5_0_OR_GREATER
                await _multipartContent.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
#else
                await _multipartContent.CopyToAsync(stream).ConfigureAwait(false);
#endif
            }

            public override void Dispose()
            {
                _multipartContent.Dispose();
            }

            private sealed class HttpContentAdapter : HttpContent
            {
                private readonly RequestContent _content;

                public HttpContentAdapter(RequestContent content)
                {
                    Argument.AssertNotNull(content, nameof(content));

                    _content = content;
                }

                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
                    => await _content.WriteToAsync(stream, CancellationToken.None).ConfigureAwait(false);

                protected override bool TryComputeLength(out long length)
                    => _content.TryComputeLength(out length);

#if NET6_0_OR_GREATER
                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                    => await _content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);

                protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                    => _content.WriteTo(stream, cancellationToken);
#endif
                protected override void Dispose(bool disposing)
                {
                    base.Dispose(disposing);
                    if (disposing)
                    {
                        _content.Dispose();
                    }
                }
            }
        }

        private sealed class MultipartFormDataPartRequestContent : RequestContent
        {
            private readonly RequestContent _content;

            public MultipartFormDataPartRequestContent(string name, RequestContent content)
            {
                Argument.AssertNotNullOrEmpty(name, nameof(name));
                Argument.AssertNotNull(content, nameof(content));

                _content = content;
                Name = name;
            }

            public override string? ContentType
            {
                get
                {
                    return _content.ContentType;
                }
            }

            internal string Name { get; }
            internal RequestContent Content => _content;

            public override void Dispose()
            {
                _content.Dispose();
                GC.SuppressFinalize(this);
            }

            public override bool TryComputeLength(out long length)
                => _content.TryComputeLength(out length);

            public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
                => _content.WriteTo(stream, cancellationToken);
            public override Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
                => _content.WriteToAsync(stream, cancellationToken);
        }
    }
}
