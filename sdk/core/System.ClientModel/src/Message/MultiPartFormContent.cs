// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Net.Http.Headers;
using System.Net;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Security.Cryptography;
using System.Text.Json;

namespace System.ClientModel;

/// <summary>
/// Represents a multipart form data content that can be used to send binary data as part of a HTTP request.
/// </summary>
public class MultiPartFormContent : BinaryContent
{
    private const string MediaTypeApplicationJson = "application/json";
    private const string MediaTypeTextPlain = "text/plain";
    private const string MediatypeApplicationOctetStream = "application/octet-stream";

    private static readonly ModelReaderWriterOptions ModelWriteWireOptions = new ModelReaderWriterOptions("W");
    private static readonly Random _random = new Random();
    private static readonly char[] _boundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz".ToCharArray();

    private readonly MultipartFormDataContent _multipartContent;
    private bool _disposed;

    /// <summary>
    /// Creates an instance of <see cref="MultiPartFormContent"/> with a randomly generated boundary.
    /// </summary>
    public MultiPartFormContent() : this(CreateBoundary()) { }

    /// <summary>
    /// Creates an instance of <see cref="MultiPartFormContent"/> with a specified boundary.
    /// </summary>
    /// <param name="boundary"></param>
    public MultiPartFormContent(string boundary)
    {
        _multipartContent = new MultipartFormDataContent(boundary);
        MediaType = _multipartContent.Headers.ContentType?.ToString();
    }

    // CUSTOM: Add filepart to the multipart content.
    /// <summary>
    /// Adds a file part to the multipart content with the specified name and file content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fileContent"></param>
    public void Add(string name, FileBinaryContent fileContent)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(fileContent, nameof(fileContent));

        HttpContent content = new FileHttpContentAdapter(fileContent);

        Add(content, name, fileContent.MediaType, fileContent.Filename);
    }

    //// CUSTOM: Add IPersistableModel part to the multipart content.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and content.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="model"></param>
    /// <param name="options"></param>
    /// <param name="context"></param>
    /// <param name="mediaType"></param>
    public void Add<T>(
        string name,
        IPersistableModel<T> model,
        ModelReaderWriterContext? context = default,
        ModelReaderWriterOptions? options = default,
        string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNull(model, nameof(model));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        options ??= ModelWriteWireOptions;
        BinaryData data = context != null
            ? ModelReaderWriter.Write(model, options, context)
            : model.Write(options);
        Add(name, data.WithMediaType(mediaType));
    }

    /// <summary>
    /// Adds a part to the multipart content with the specified name and content.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="model"></param>
    public void Add<T>(string name, IPersistableModel<T> model)
        => Add(name, model);

    // CUSTOM: Add optional content type parameter to the Add method.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and string content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="content"></param>
    /// <param name="mediaType"></param>
    public void Add(string name, string content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            Add(new StringContent(content), name, mediaType ?? MediaTypeTextPlain);
        }
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and integer content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="content"></param>
    /// <param name="mediaType"></param>
    public void Add(string name, int content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString("G", CultureInfo.InvariantCulture);
            Add(new StringContent(value), name, mediaType ?? MediaTypeTextPlain);
        }
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and long content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="content"></param>
    /// <param name="mediaType"></param>
    public void Add(string name, long content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString("G", CultureInfo.InvariantCulture);
            Add(new StringContent(value), name, mediaType ?? MediaTypeTextPlain);
        }
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and float content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="content"></param>
    /// <param name="mediaType"></param>
    public void Add(string name, float content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString("G", CultureInfo.InvariantCulture);
            Add(new StringContent(value), name, mediaType ?? MediaTypeTextPlain);
        }
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and double content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="content"></param>
    /// <param name="mediaType"></param>
    public void Add(string name, double content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString("G", CultureInfo.InvariantCulture);
            Add(new StringContent(value), name, mediaType ?? MediaTypeTextPlain);
        }
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and decimal content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="content"></param>
    /// <param name="mediaType"></param>
    public void Add(string name, decimal content, string? mediaType = MediaTypeApplicationJson)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        if (mediaType == MediaTypeApplicationJson)
        {
            Add(new StreamContent(CreateJsonStream(content)), name, mediaType);
        }
        else
        {
            string value = content.ToString("G", CultureInfo.InvariantCulture);
            Add(new StringContent(value), name, mediaType ?? MediaTypeTextPlain);
        }
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and byte array content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="content"></param>
    /// <param name="mediaType"></param>
    public void Add(string name, byte[] content, string? mediaType = MediatypeApplicationOctetStream)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        Add(new ByteArrayContent(content), name, mediaType: mediaType);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    /// <summary>
    /// Adds a part to the multipart content with the specified name and BinaryData content.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="content"></param>
    public void Add(string name, BinaryData content)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        // Avoid copying the underlying bytes: ReadOnlyMemoryContent / StreamContent over BinaryData
        // wrap the existing memory without a buffer copy, unlike ByteArrayContent(BinaryData.ToArray()).
#if NET6_0_OR_GREATER
        Add(new ReadOnlyMemoryContent(content.ToMemory()), name, mediaType: content.MediaType);
#else
        Add(new StreamContent(content.ToStream()), name, mediaType: content.MediaType);
#endif
    }

    /// <param name="content"></param>
    /// <param name="name"></param>
    /// <param name="filename"></param>
    /// <param name="mediaType"></param>
    private void Add(HttpContent content, string name, string? mediaType, string? filename = default)
    {
        if (mediaType != null)
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
        Span<char> chars = new char[70];
        byte[] random = new byte[70];
        _random.NextBytes(random);
        int mask = 255 >> 2;
        int i = 0;
        for (; i < 70; i++)
        {
            chars[i] = _boundaryValues[random[i] & mask];
        }
        return chars.ToString();
    }

    private static MemoryStream CreateJsonStream(object value)
    {
        var stream = new MemoryStream(64);
        using (var writer = new Utf8JsonWriter(stream))
        {
            switch (value)
            {
                case string s:
                    writer.WriteStringValue(s);
                    break;
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case long l:
                    writer.WriteNumberValue(l);
                    break;
                case float f:
                    writer.WriteNumberValue(f);
                    break;
                case double d:
                    writer.WriteNumberValue(d);
                    break;
                case decimal m:
                    writer.WriteNumberValue(m);
                    break;
                case bool b:
                    writer.WriteBooleanValue(b);
                    break;
                default:
                    throw new ArgumentException(
                        $"Unsupported primitive type '{value?.GetType().FullName ?? "null"}' for JSON multipart part.",
                        nameof(value));
            }
        }
        stream.Position = 0;
        return stream;
    }

    /// <summary>
    /// Tries to compute the length of the content.
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Writes the content to the specified stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
    {
#if NET6_0_OR_GREATER
        _multipartContent.CopyTo(stream, default, cancellationToken);
#else
        Internal.TaskExtensions.EnsureCompleted(_multipartContent.CopyToAsync(stream));
#endif
    }

    /// <summary>
    /// Asynchronously writes the content to the specified stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
    {
#if NET6_0_OR_GREATER
        await _multipartContent.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
#else
        await _multipartContent.CopyToAsync(stream).ConfigureAwait(false);
#endif
    }

    /// <summary>
    /// Disposes the multipart content and releases any resources it holds.
    /// </summary>
    public override void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _multipartContent.Dispose();
        _disposed = true;
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
