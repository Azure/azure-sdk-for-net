// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;

namespace System.ClientModel;

internal partial class MultiPartFormDataBinaryContent : BinaryContent
{
    private readonly MultipartFormDataContent _multipartContent;

    private const int BoundaryLength = 70;
    private const string BoundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz";

    public MultiPartFormDataBinaryContent() : this(CreateBoundary()) { }

    // CUSTOM: Internal ctor to use in serialization
    internal MultiPartFormDataBinaryContent(string boundary)
    {
        _multipartContent = new MultipartFormDataContent(boundary);
    }

    internal string ContentType
    {
        get
        {
            Debug.Assert(_multipartContent.Headers.ContentType is not null);

            return _multipartContent.Headers.ContentType!.ToString();
        }
    }

    internal HttpContent HttpContent => _multipartContent;

    // CUSTOM: Add filepart to the multipart content.
    public void Add(string name, FileBinaryContent fileContent)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(fileContent, nameof(fileContent));

        HttpContent content = new HttpContentAdapter(fileContent);
        if (fileContent.ContentType != null)
        {
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(fileContent.ContentType);
        }

        Add(content, name, fileContent.Filename);
    }

    //// CUSTOM: Add IPersistableModel part to the multipart content.
    public void Add<T>(string name, IPersistableModel<T> content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        //Add(name, ModelReaderWriter.Write(content, ModelSerializationExtensions.WireOptions), contentType: contentType);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, string content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        StringContent stringContent = new(content);
        if (contentType is not null)
        {
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }

        Add(stringContent, name);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, int content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        StringContent stringContent = new(value);
        if (contentType is not null)
        {
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }
        Add(stringContent, name);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, long content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        StringContent stringContent = new(value);
        if (contentType is not null)
        {
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }
        Add(stringContent, name);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, float content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        StringContent stringContent = new(value);
        if (contentType is not null)
        {
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }
        Add(stringContent, name);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, double content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        StringContent stringContent = new(value);
        if (contentType is not null)
        {
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }
        Add(stringContent, name);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, decimal content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        string value = content.ToString("G", CultureInfo.InvariantCulture);
        StringContent stringContent = new(value);
        if (contentType is not null)
        {
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }
        Add(stringContent, name);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, bool content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        string value = content ? "true" : "false";
        StringContent stringContent = new(value);
        if (contentType is not null)
        {
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }
        Add(stringContent, name);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, byte[] content, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        var byteArrayContent = new ByteArrayContent(content);
        if (contentType is not null)
        {
            byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }

        Add(byteArrayContent, name);
    }

    // CUSTOM: Add optional content type parameter to the Add method.
    public void Add(string name, BinaryData content, string? fileName = default, string? contentType = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        ByteArrayContent byteArrayContent = new(content.ToArray());
        if (contentType is not null)
        {
            byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
        }
        Add(byteArrayContent, name, fileName);
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

    // CUSTOM: Make static & internalize to use in serialization
#if NET6_0_OR_GREATER
    internal static string CreateBoundary() =>
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

    internal static string CreateBoundary()
    {
        Span<char> chars = stackalloc char[BoundaryLength];

        byte[] random = new byte[BoundaryLength];
        lock (_random)
        {
            _random.NextBytes(random);
        }

        // Instead of `% BoundaryValues.Length` as is used above, use a mask to achieve the same result.
        // `% BoundaryValues.Length` is optimized to the equivalent on .NET Core but not on .NET Framework.
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
        // We can't call the protected method on HttpContent

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
