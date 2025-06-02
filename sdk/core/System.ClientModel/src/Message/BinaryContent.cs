// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;

namespace System.ClientModel;

/// <summary>
/// Represents binary content that can be sent to a cloud service as part of
/// a <see cref="PipelineRequest"/>.
/// </summary>
public abstract class BinaryContent : IDisposable
{
    private static readonly ModelReaderWriterOptions ModelWriteWireOptions = new ModelReaderWriterOptions("W");

    /// <summary>
    /// The content type of the binary content.
    /// </summary>
    public virtual string? ContentType { get; set; }

    //internal string? Name { get; set; }
    //internal virtual string? Filename { get; set; }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/> that contains the
    /// bytes held in the provided <see cref="BinaryData"/> instance.
    /// </summary>
    /// <param name="value">The <see cref="BinaryData"/> containing the bytes
    /// this <see cref="BinaryContent"/> will hold.</param>
    /// <returns>An an instance of <see cref="BinaryContent"/> that contains the
    /// bytes held in the provided <see cref="BinaryData"/> instance.</returns>
    public static BinaryContent Create(BinaryData value)
    {
        Argument.AssertNotNull(value, nameof(value));

        return new BinaryDataBinaryContent(value.ToMemory());
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/> that contains the
    /// bytes resulting from writing the value of the provided
    /// <see cref="IPersistableModel{T}"/>.
    /// </summary>
    /// <param name="model">The <see cref="IPersistableModel{T}"/> to write.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/>, if any,
    /// that indicates what format the <paramref name="model"/> will be written in.
    /// </param>
    /// <returns>An instance of <see cref="BinaryContent"/> that wraps a <see cref="IPersistableModel{T}"/>.</returns>
    public static BinaryContent Create<T>(T model, ModelReaderWriterOptions? options = default) where T : IPersistableModel<T>
    {
        Argument.AssertNotNull(model, nameof(model));

        return new ModelBinaryContent<T>(model, options ?? ModelWriteWireOptions);
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/> that contains the
    /// bytes held in the provided <see cref="Stream"/> instance.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> containing the bytes
    /// this <see cref="BinaryContent"/> will hold.</param>
    /// <returns>An an instance of <see cref="BinaryContent"/> that contains the
    /// bytes held in the provided <see cref="Stream"/> instance.</returns>
    public static BinaryContent Create(Stream stream)
    {
        Argument.AssertNotNull(stream, nameof(stream));

        return new StreamBinaryContent(stream);
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, Stream stream)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(stream, nameof(stream));

        return new MultipartFormDataPartBinaryContent(name, new StreamBinaryContent(stream));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, BinaryData content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        return new MultipartFormDataPartBinaryContent(name, new BinaryDataBinaryContent(content.ToMemory()));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, string content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        return CreateMultipartFormDataPart(name, BinaryData.FromString(content));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, int content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        return CreateMultipartFormDataPart(name, BinaryData.FromString(value));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, long content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        return CreateMultipartFormDataPart(name, BinaryData.FromString(value));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, float content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        return CreateMultipartFormDataPart(name, BinaryData.FromString(value));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, double content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        return CreateMultipartFormDataPart(name, BinaryData.FromString(value));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, decimal content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        return CreateMultipartFormDataPart(name, BinaryData.FromString(value));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, bool content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        string value = content ? "true" : "false";
        return CreateMultipartFormDataPart(name, BinaryData.FromString(value));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, byte[] content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        return CreateMultipartFormDataPart(name, BinaryData.FromBytes(content));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataPart(string name, FileBinaryContent content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));

        return new MultipartFormDataPartBinaryContent(name, content);
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/> that contains the
    /// bytes resulting from writing the value of the provided
    /// <see cref="IPersistableModel{T}"/>.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <param name="model">The <see cref="IPersistableModel{T}"/> to write.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/>, if any,
    /// that indicates what format the <paramref name="model"/> will be written in.
    /// </param>
    /// <returns>An instance of <see cref="BinaryContent"/> that wraps a <see cref="IPersistableModel{T}"/>.</returns>
    public static BinaryContent CreateMultipartFormDataPart<T>(
        string name,
        T model,
        ModelReaderWriterOptions? options = default) where T : IPersistableModel<T>
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(model, nameof(model));

        return new MultipartFormDataPartBinaryContent(name, new ModelBinaryContent<T>(model, options ?? ModelWriteWireOptions));
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/> that contains the
    /// the provided <see cref="BinaryContent"/> as multi-part form data.
    /// </summary>
    /// <param name="parts"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataContent(IEnumerable<BinaryContent> parts)
    {
        Argument.AssertNotNull(parts, nameof(parts));

        return new MultiPartFormDataBinaryContent(parts);
    }

    /// <summary>
    /// Creates an instance of <see cref="BinaryContent"/> that contains the
    /// the provided <see cref="BinaryContent"/> as multi-part form data.
    /// </summary>
    /// <param name="boundary"></param>
    /// <param name="parts"></param>
    /// <returns></returns>
    public static BinaryContent CreateMultipartFormDataContent(string boundary, IEnumerable<BinaryContent> parts)
    {
        Argument.AssertNotNullOrEmpty(boundary, nameof(boundary));
        Argument.AssertNotNull(parts, nameof(parts));

        return new MultiPartFormDataBinaryContent(boundary, parts);
    }

    /// <summary>
    /// Attempts to compute the length of the underlying body content, if available.
    /// </summary>
    /// <param name="length">The length of the underlying data.</param>
    public abstract bool TryComputeLength(out long length);

    /// <summary>
    /// Writes contents of this <see cref="BinaryContent"/> instance to the
    /// provided <see cref="Stream"/>.
    /// </summary>
    /// <param name="stream">The stream to write the binary content to.</param>
    /// <param name="cancellationToken">To <see cref="CancellationToken"/> to
    /// use for the write operation.</param>
    public abstract Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default);

    /// <summary>
    /// Writes contents of this <see cref="BinaryContent"/> instance to the
    /// provided <see cref="Stream"/>.
    /// </summary>
    /// <param name="stream">The stream to write the binary content to.</param>
    /// <param name="cancellationToken">To <see cref="CancellationToken"/> to
    /// use for the write operation.</param>
    public abstract void WriteTo(Stream stream, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public abstract void Dispose();

    private sealed class BinaryDataBinaryContent : BinaryContent
    {
        private readonly ReadOnlyMemory<byte> _bytes;

        public BinaryDataBinaryContent(ReadOnlyMemory<byte> bytes)
        {
            _bytes = bytes;
        }

        public override bool TryComputeLength(out long length)
        {
            length = _bytes.Length;
            return true;
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            byte[] buffer = _bytes.ToArray();
            stream.Write(buffer, 0, buffer.Length);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            await stream.WriteAsync(_bytes, cancellation).ConfigureAwait(false);
        }

        public override void Dispose() { }
    }

    private sealed class ModelBinaryContent<T> : BinaryContent where T : IPersistableModel<T>
    {
        private readonly T _model;
        private readonly ModelReaderWriterOptions _options;

        // Used when _model is an IJsonModel
        private UnsafeBufferSequence.Reader? _sequenceReader;

        // Used when _model is an IModel
        private BinaryData? _data;

        public ModelBinaryContent(T model, ModelReaderWriterOptions options)
        {
            _model = model;
            _options = options;
        }

        private UnsafeBufferSequence.Reader SequenceReader
        {
            get
            {
                if (_model is not IJsonModel<T> jsonModel)
                {
                    throw new InvalidOperationException("Cannot use Writer with non-IJsonModel model type.");
                }

                _sequenceReader ??= new ModelWriter<T>(jsonModel, _options).ExtractReader();
                return _sequenceReader;
            }
        }

        private BinaryData Data
        {
            get
            {
                if (ModelReaderWriter.ShouldWriteAsJson(_model, _options))
                {
                    throw new InvalidOperationException("Should use ModelWriter instead of _model.Write with IJsonModel.");
                }

                _data ??= _model.Write(_options);
                return _data;
            }
        }

        public override bool TryComputeLength(out long length)
        {
            length = ModelReaderWriter.ShouldWriteAsJson(_model, _options) ? SequenceReader.Length : Data.ToMemory().Length;

            return true;
        }

#if NETFRAMEWORK || NETSTANDARD2_0
        private byte[]? _bytes;
        private byte[] Bytes => _bytes ??= Data.ToArray();
#endif

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            if (ModelReaderWriter.ShouldWriteAsJson(_model, _options))
            {
                SequenceReader.CopyTo(stream, cancellation);
                return;
            }

#if NETFRAMEWORK || NETSTANDARD2_0
            stream.Write(Bytes, 0, Bytes.Length);
#else
            stream.Write(Data.ToMemory().Span);
#endif
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            if (ModelReaderWriter.ShouldWriteAsJson(_model, _options))
            {
                await SequenceReader.CopyToAsync(stream, cancellation).ConfigureAwait(false);
                return;
            }

            await stream.WriteAsync(Data.ToMemory(), cancellation).ConfigureAwait(false);
        }

        public override void Dispose()
        {
            var sequenceReader = _sequenceReader;
            if (sequenceReader != null)
            {
                _sequenceReader = null;
                sequenceReader.Dispose();
            }
        }
    }

    private sealed class StreamBinaryContent : BinaryContent
    {
        private readonly Stream _stream;
        private readonly long _origin;

        public StreamBinaryContent(Stream stream)
        {
            if (!stream.CanSeek)
            {
                throw new ArgumentException("Stream must be seekable.", nameof(stream));
            }

            _stream = stream;
            _origin = stream.Position;
        }

        public override bool TryComputeLength(out long length)
        {
            // CanSeek is validated in constructor - it will always be true.
            length = _stream.Length - _origin;
            return true;
        }

        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            _stream.Seek(_origin, SeekOrigin.Begin);
            _stream.CopyTo(stream, cancellationToken);
            _stream.Flush();
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            _stream.Seek(_origin, SeekOrigin.Begin);
            await _stream.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            await _stream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }

        public override void Dispose()
        {
            _stream.Dispose();
        }
    }

    private sealed class MultiPartFormDataBinaryContent : BinaryContent
    {
        private readonly MultipartFormDataContent _multipartContent;

        private const int BoundaryLength = 70;
        private const string BoundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz";

        public MultiPartFormDataBinaryContent(IEnumerable<BinaryContent> parts)
            : this(CreateBoundary(), parts) { }

        public MultiPartFormDataBinaryContent(string boundary, IEnumerable<BinaryContent> parts)
        {
            Argument.AssertNotNullOrEmpty(boundary, nameof(boundary));
            Argument.AssertNotNull(parts, nameof(parts));

            _multipartContent = new MultipartFormDataContent(boundary);

            foreach (BinaryContent part in parts)
            {
                if (part is not MultipartFormDataPartBinaryContent partBinaryContent)
                {
                    throw new InvalidOperationException($"The type is not a valid part: '{part.GetType()}'.");
                }
                Add(partBinaryContent);
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

        public void Add(MultipartFormDataPartBinaryContent content)
        {
            Argument.AssertNotNull(content, nameof(content));
            Argument.AssertNotNull(content.Name, nameof(content.Name));

            HttpContent httpContent = new HttpContentAdapter(content);
            if (content.ContentType is not null)
            {
                httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse(content.ContentType);
            }

            string? filename = content.Content is FileBinaryContent fileContent ? fileContent.Filename : null;
            Add(httpContent, content.Name!, filename);
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
        Internal.TaskExtensions.EnsureCompleted(_multipartContent.CopyToAsync(stream));
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
            private readonly BinaryContent _content;

            public HttpContentAdapter(BinaryContent content)
            {
                Argument.AssertNotNull(content, nameof(content));

                _content = content;
            }

            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
                => await _content.WriteToAsync(stream).ConfigureAwait(false);

            protected override bool TryComputeLength(out long length)
                => _content.TryComputeLength(out length);

#if NET6_0_OR_GREATER
            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                => await _content!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);

            protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                => _content.WriteTo(stream, cancellationToken);
#endif
        }
    }

    private sealed class MultipartFormDataPartBinaryContent : BinaryContent
    {
        private readonly BinaryContent _content;

        public MultipartFormDataPartBinaryContent(string name, BinaryContent content)
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

        internal string Name { get;  }
        internal BinaryContent Content => _content;

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
