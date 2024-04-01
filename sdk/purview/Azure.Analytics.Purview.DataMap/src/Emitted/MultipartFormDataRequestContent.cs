// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Analytics.Purview.DataMap.Internal;

internal class MultipartFormDataRequestContent : RequestContent
{
    // TODO: What's the right TFM here?
#if NET6_0_OR_GREATER
    private readonly System.Net.Http.MultipartFormDataContent _multipartContent;
#else
    private readonly MultipartFormDataContent _multipartContent;
#endif

    private static Random _random = new();
    private static readonly char[] _boundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public MultipartFormDataRequestContent()
    {
#if NET6_0_OR_GREATER
        _multipartContent = new System.Net.Http.MultipartFormDataContent(CreateBoundary());
#else
        // TODO: reduce the footprint of where the Multipart type is polyfilled...
        _multipartContent = new MultipartFormDataContent(CreateBoundary());
#endif
    }

    public string ContentType
    {
        get
        {
            Debug.Assert(_multipartContent.Headers.ContentType is not null);

            return _multipartContent.Headers.ContentType!.ToString();
        }
    }

    public void Add(Stream stream, string name, string fileName = default)
    {
#if NET6_0_OR_GREATER
        Add(new StreamContent(stream), name, fileName);
#else
        Add(RequestContent.Create(stream), name, fileName);
#endif
    }

    public void Add(string content, string name, string fileName = default)
    {
#if NET6_0_OR_GREATER
        Add(new StringContent(content), name, fileName);
#else
        Add(RequestContent.Create(content), name, fileName);
#endif
    }

    public void Add(int content, string name, string fileName = default)
    {
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        string value = content.ToString("G", CultureInfo.InvariantCulture);

#if NET6_0_OR_GREATER
        Add(new StringContent(value), name, fileName);
#else
        Add(RequestContent.Create(value), name, fileName);
#endif
    }

    public void Add(double content, string name, string fileName = default)
    {
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        string value = content.ToString("G", CultureInfo.InvariantCulture);

#if NET6_0_OR_GREATER
        Add(new StringContent(value), name, fileName);
#else
        Add(RequestContent.Create(value), name, fileName);
#endif
    }

    public void Add(byte[] content, string name, string fileName = default)
    {
#if NET6_0_OR_GREATER
        Add(new ByteArrayContent(content), name, fileName);
#else
        Add(RequestContent.Create(content), name, fileName);
#endif
    }

    public void Add(BinaryData content, string name, string fileName = default)
    {
#if NET6_0_OR_GREATER
        Add(new ByteArrayContent(content.ToArray()), name, fileName);
#else
        Add(RequestContent.Create(content), name, fileName);
#endif
    }

#if NET6_0_OR_GREATER
    private void Add(HttpContent content, string name, string fileName)
    {
        if (fileName is not null)
        {
            AddFileNameHeader(content, name, fileName);
        }

        _multipartContent.Add(content, name);
    }
#else
    private void Add(RequestContent content, string name, string fileName = default)
    {
        if (fileName is not null)
        {
            _multipartContent.Add(content, name, fileName, headers: default);
        }
        else
        {
            _multipartContent.Add(content, name, headers: default);
        }
    }
#endif

    private static void AddFileNameHeader(HttpContent content, string name, string filename)
    {
        // Add the content header manually because the default implementation
        // adds a `filename*` parameter to the header, which RFC 7578 says not
        // to do.  We are following up with the BCL team per correctness.
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
        // This is important to ensuring that the odds of creating a boundary
        // that occurs in any content part are astronomically small.
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
#if NET6_0_OR_GREATER
        // We can't call the protected method on HttpContent

        if (_multipartContent.Headers.ContentLength is long contentLength)
        {
            length = contentLength;
            return true;
        }

        length = 0;
        return false;
#else
        return _multipartContent.TryComputeLength(out length);
#endif
    }

    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
    {
#if NET6_0_OR_GREATER
        _multipartContent.CopyTo(stream, default, cancellationToken);
#else
    _multipartContent.WriteTo(stream, cancellationToken);
#endif
    }

    public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
    {
#if NET6_0_OR_GREATER
        await _multipartContent.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
#else
    await _multipartContent.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
#endif
    }

    public override void Dispose()
    {
        _multipartContent.Dispose();
    }
}
