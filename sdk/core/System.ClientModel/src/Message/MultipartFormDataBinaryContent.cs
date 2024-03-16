// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments

public sealed class MultipartFormDataBinaryContent : BinaryContent
{
    private readonly MultipartFormDataContent _multipartContent;

    private static Random _random = new();
    private static readonly char[] _boundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public MultipartFormDataBinaryContent()
    {
        _multipartContent = new MultipartFormDataContent(CreateBoundary());
    }

    public string? ContentType
    {
        get
        {
            if (_multipartContent.Headers.ContentType is MediaTypeHeaderValue value)
            {
                return value.ToString();
            }

            return null;
        }
    }

    internal HttpContent HttpContent => _multipartContent;

    public void Add(Stream stream, string name, string? fileName = default)
    {
        Add(new StreamContent(stream), name, fileName);
    }

    public void Add(string content, string name, string? fileName = default)
    {
        Add(new StringContent(content), name, fileName);
    }

    public void Add(BinaryData content, string name, string? fileName = default)
    {
        // TODO: is calling ToArray on BinaryData the most performant way?
        Add(new ByteArrayContent(content.ToArray()), name, fileName);
    }

    // TODO: overload for IPersistableModel?

    private void Add(HttpContent content, string name, string? fileName)
    {
        if (fileName is not null)
        {
            AddFileNameHeader(content, name, fileName);
        }

        _multipartContent.Add(content, name);
    }

    private static void AddFileNameHeader(HttpContent content, string name, string filename)
    {
        // TODO: I think we need to add the content header manually because the
        // default implementation is adding a `filename*` parameter to the header,
        // which RFC 7578 says not to do -- I am following up with the BCL team
        // on this to learn more about when this is/isn't needed.
        ContentDispositionHeaderValue header = new("form-data")
        {
            Name = name,
            FileName = filename
        };
        content.Headers.ContentDisposition = header;
    }

    private static string CreateBoundary()
    {
        Span<char> chars = new char[70];

        byte[] random = new byte[70];
        _random.NextBytes(random);

        // The following will sample evenly from the possible values.
        int mask = 255 >> 2;

        Debug.Assert(_boundaryValues.Length - 1 == mask);

        for (int i = 0; i < 70; i++)
        {
            chars[i] = _boundaryValues[random[i] & mask];
        }

        return chars.ToString();
    }

    public override bool TryComputeLength(out long length)
    {
        // We can't call the protected method on HttpContent
        length = 0;
        return false;
    }

    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
    {
        // TODO: polyfill sync-over-async for netstandard2.0.

#if NET6_0_OR_GREATER
        _multipartContent.CopyTo(stream, default, cancellationToken);
#else
        // Sync over async
        _multipartContent.CopyToAsync(stream).RunSynchronously();
#endif
    }

    public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
    {
#if NET6_0_OR_GREATER
        await _multipartContent.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
#else
        await _multipartContent.CopyToAsync(stream).ConfigureAwait(false);
#endif
    }

    public override void Dispose()
    {
        _multipartContent.Dispose();
    }
}

#pragma warning restore CS1591 // public XML comments
