// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace System.ClientModel;

/// <summary>
/// Represents <c>multipart/form-data</c> content that can be sent to a cloud
/// service as part of a <see cref="PipelineRequest"/>.
/// </summary>
[Experimental("SCME0004")]
public sealed class MultiPartFormContent : BinaryContent
{
    private const string MediaTypeApplicationJson = "application/json";
    private const string MediaTypeTextPlain = "text/plain";
    private const string MediaTypeApplicationOctetStream = "application/octet-stream";
    private const int BoundaryLength = 70;
    private const int BoundaryAlphabetMask = 0x3F; // 64-char alphabet → 6-bit mask, unbiased.

    private static readonly ModelReaderWriterOptions _modelWriteWireOptions = new ModelReaderWriterOptions("W");
    private static readonly char[] _boundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz".ToCharArray();
#if !NET6_0_OR_GREATER
    private static readonly Random _random = new Random();
    private static readonly object _randomLock = new object();
#endif

    private readonly MultipartFormDataContent _multipartContent;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of <see cref="MultiPartFormContent"/> with a
    /// randomly generated boundary.
    /// </summary>
    public MultiPartFormContent() : this(CreateBoundary()) { }

    /// <summary>
    /// Initializes a new instance of <see cref="MultiPartFormContent"/> with the
    /// specified boundary.
    /// </summary>
    /// <param name="boundary">The boundary string used to separate parts in the
    /// <c>multipart/form-data</c> payload.</param>
    public MultiPartFormContent(string boundary)
    {
        Argument.AssertNotNullOrEmpty(boundary, nameof(boundary));

        _multipartContent = new MultipartFormDataContent(boundary);
        MediaType = _multipartContent.Headers.ContentType?.ToString();
    }

    /// <summary>
    /// Adds the provided <see cref="FileBinaryContent"/> as a part of this
    /// <see cref="MultiPartFormContent"/> and transfers ownership of
    /// <paramref name="fileContent"/> to this instance.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="fileContent">The <see cref="FileBinaryContent"/> to add as a part.</param>
#pragma warning disable SCME0004 // FileBinaryContent is experimental.
    public void Add(string name, FileBinaryContent fileContent)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(fileContent, nameof(fileContent));
        CheckDisposed();

        HttpContent content = new FileHttpContentAdapter(fileContent);

        Add(content, name, fileContent.MediaType, fileContent.Filename);
    }
#pragma warning restore SCME0004

    /// <summary>
    /// Adds the provided <see cref="IPersistableModel{T}"/> as a part of this
    /// <see cref="MultiPartFormContent"/>.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="model">The <see cref="IPersistableModel{T}"/> to add as a part.</param>
    /// <param name="context">The <see cref="ModelReaderWriterContext"/> used to write the model.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> that indicates what format the <paramref name="model"/> will be written in.</param>
    /// <param name="mediaType">The media type for the part.</param>
    public void Add<T>(
        string name,
        IPersistableModel<T> model,
        ModelReaderWriterContext? context = default,
        ModelReaderWriterOptions? options = default,
        string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(model, nameof(model));
        CheckDisposed();

        options ??= _modelWriteWireOptions;
        BinaryData data = context != null
            ? ModelReaderWriter.Write(model, options, context)
            : model.Write(options);
        Add(name, data.WithMediaType(mediaType));
    }

    /// <summary>
    /// Adds the provided <see cref="IPersistableModel{T}"/> as a part of this
    /// <see cref="MultiPartFormContent"/> using the default options.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="model">The <see cref="IPersistableModel{T}"/> to add as a part.</param>
    public void Add<T>(string name, IPersistableModel<T> model)
        => Add<T>(name, model, context: null);

    /// <summary>
    /// Adds the bytes held in the provided <see cref="BinaryData"/> as a part
    /// of this <see cref="MultiPartFormContent"/>. The media type from
    /// <see cref="BinaryData.MediaType"/>, if any, is used for the part.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="content">The <see cref="BinaryData"/> to add as a part.</param>
    public void Add(string name, BinaryData content)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));
        CheckDisposed();

#if NET6_0_OR_GREATER
        Add(new ReadOnlyMemoryContent(content.ToMemory()), name, mediaType: content.MediaType);
#else
        Add(new StreamContent(content.ToStream()), name, mediaType: content.MediaType);
#endif
    }

    /// <summary>
    /// Adds the provided byte array as a part of this
    /// <see cref="MultiPartFormContent"/>.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="content">The byte array to add as a part.</param>
    /// <param name="mediaType">The media type for the part.</param>
    public void Add(string name, byte[] content, string? mediaType = MediaTypeApplicationOctetStream)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));
        CheckDisposed();

        Add(new ByteArrayContent(content), name, mediaType: mediaType);
    }

    /// <summary>
    /// Adds the provided <see cref="string"/> as a part of this
    /// <see cref="MultiPartFormContent"/>.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="content">The <see cref="string"/> to add as a part.</param>
    /// <param name="mediaType">The media type for the part.</param>
    public void Add(string name, string content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(content, nameof(content));
        CheckDisposed();

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            Add(new StringContent(content, encoding: null, mediaType ?? MediaTypeTextPlain), name, mediaType);
        }
    }

    /// <summary>
    /// Adds the provided <see cref="int"/> as a part of this
    /// <see cref="MultiPartFormContent"/>.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="content">The <see cref="int"/> to add as a part.</param>
    /// <param name="mediaType">The media type for the part.</param>
    public void Add(string name, int content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        CheckDisposed();

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString(CultureInfo.InvariantCulture);
            Add(new StringContent(value, encoding: null, mediaType ?? MediaTypeTextPlain), name, mediaType);
        }
    }

    /// <summary>
    /// Adds the provided <see cref="long"/> as a part of this
    /// <see cref="MultiPartFormContent"/>.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="content">The <see cref="long"/> to add as a part.</param>
    /// <param name="mediaType">The media type for the part.</param>
    public void Add(string name, long content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        CheckDisposed();

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString(CultureInfo.InvariantCulture);
            Add(new StringContent(value, encoding: null, mediaType ?? MediaTypeTextPlain), name, mediaType);
        }
    }

    /// <summary>
    /// Adds the provided <see cref="float"/> as a part of this
    /// <see cref="MultiPartFormContent"/>.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="content">The <see cref="float"/> to add as a part.</param>
    /// <param name="mediaType">The media type for the part.</param>
    public void Add(string name, float content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        CheckDisposed();

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString("R", CultureInfo.InvariantCulture);
            Add(new StringContent(value, encoding: null, mediaType ?? MediaTypeTextPlain), name, mediaType);
        }
    }

    /// <summary>
    /// Adds the provided <see cref="double"/> as a part of this
    /// <see cref="MultiPartFormContent"/>.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="content">The <see cref="double"/> to add as a part.</param>
    /// <param name="mediaType">The media type for the part.</param>
    public void Add(string name, double content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        CheckDisposed();

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString("R", CultureInfo.InvariantCulture);
            Add(new StringContent(value, encoding: null, mediaType ?? MediaTypeTextPlain), name, mediaType);
        }
    }

    /// <summary>
    /// Adds the provided <see cref="decimal"/> as a part of this
    /// <see cref="MultiPartFormContent"/>.
    /// </summary>
    /// <param name="name">The form field name for the part.</param>
    /// <param name="content">The <see cref="decimal"/> to add as a part.</param>
    /// <param name="mediaType">The media type for the part.</param>
    public void Add(string name, decimal content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        CheckDisposed();

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString(CultureInfo.InvariantCulture);
            Add(new StringContent(value, encoding: null, mediaType ?? MediaTypeTextPlain), name, mediaType);
        }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(stream, nameof(stream));
        CheckDisposed();
        cancellationToken.ThrowIfCancellationRequested();

#if NET6_0_OR_GREATER
        _multipartContent.CopyTo(stream, default, cancellationToken);
#else
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        _multipartContent.CopyToAsync(stream).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
#endif
    }

    /// <inheritdoc/>
    public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(stream, nameof(stream));
        CheckDisposed();
        cancellationToken.ThrowIfCancellationRequested();

#if NET6_0_OR_GREATER
        await _multipartContent.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
#else
        await _multipartContent.CopyToAsync(stream).ConfigureAwait(false);
#endif
    }

    /// <inheritdoc/>
    public override void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _multipartContent.Dispose();
        _disposed = true;
    }

    private void CheckDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(MultiPartFormContent));
        }
    }

    private void Add(HttpContent content, string name, string? mediaType, string? filename = default)
    {
        if (content.Headers.ContentType is null && mediaType is not null)
        {
            Argument.AssertNotNullOrEmpty(mediaType, nameof(mediaType));

            content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
        }
        if (filename != null)
        {
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));
            _multipartContent.Add(content, name, filename);
        }
        else
        {
            _multipartContent.Add(content, name);
        }
    }

    private static string CreateBoundary()
    {
#if NET6_0_OR_GREATER
        Span<char> chars = stackalloc char[BoundaryLength];
        Span<byte> random = stackalloc byte[BoundaryLength];
        Random.Shared.NextBytes(random);
#else
        char[] chars = new char[BoundaryLength];
        byte[] random = new byte[BoundaryLength];
        lock (_randomLock)
        {
            _random.NextBytes(random);
        }
#endif
        for (int i = 0; i < BoundaryLength; i++)
        {
            chars[i] = _boundaryValues[random[i] & BoundaryAlphabetMask];
        }
        return new string(chars);
    }

    private static MemoryStream CreateJsonStream(string value)
    {
        var stream = new MemoryStream(64);
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStringValue(value);
        }
        stream.Position = 0;
        return stream;
    }

    private static MemoryStream CreateJsonStream(int value)
    {
        var stream = new MemoryStream(16);
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteNumberValue(value);
        }
        stream.Position = 0;
        return stream;
    }

    private static MemoryStream CreateJsonStream(long value)
    {
        var stream = new MemoryStream(24);
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteNumberValue(value);
        }
        stream.Position = 0;
        return stream;
    }

    private static MemoryStream CreateJsonStream(float value)
    {
        var stream = new MemoryStream(32);
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteNumberValue(value);
        }
        stream.Position = 0;
        return stream;
    }

    private static MemoryStream CreateJsonStream(double value)
    {
        var stream = new MemoryStream(32);
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteNumberValue(value);
        }
        stream.Position = 0;
        return stream;
    }

    private static MemoryStream CreateJsonStream(decimal value)
    {
        var stream = new MemoryStream(32);
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteNumberValue(value);
        }
        stream.Position = 0;
        return stream;
    }

    private sealed class FileHttpContentAdapter : HttpContent
    {
        private readonly BinaryContent _content;

        public FileHttpContentAdapter(BinaryContent content)
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
            if (disposing)
            {
                _content.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
