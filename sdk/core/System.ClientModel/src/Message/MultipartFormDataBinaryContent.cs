// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments

public sealed class MultipartFormDataBinaryContent : BinaryContent
{
    private readonly MultipartFormDataContent _multipartContent;

    internal HttpContent HttpContent => _multipartContent;

    public MultipartFormDataBinaryContent()
    {
        // TODO: Add boundary
        _multipartContent = new MultipartFormDataContent();
    }

    public void Add(Stream stream, string name, string? fileName)
    {
        StreamContent content = new(stream);

        if (fileName is not null)
        {
            _multipartContent.Add(content, name, fileName);
        }
        else
        {
            _multipartContent.Add(content, name);
        }
    }

    public void Add(string content, string name)
    {
        StringContent stringContent = new(content);
        _multipartContent.Add(stringContent, name);
    }

    public void Add(BinaryData data, string name)
    {
        ByteArrayContent content = new(data.ToArray());
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
