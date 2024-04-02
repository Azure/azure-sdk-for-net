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

namespace Azure.Core.Emitted;

#if NET6_0_OR_GREATER
/*TODO internal*/
public class MultipartFormDataRequestContent : RequestContent
{
    private readonly MultipartFormDataContent _multipartContent;

    private static Random _random = new();
    private static readonly char[] _boundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public MultipartFormDataRequestContent()
    {
        _multipartContent = new MultipartFormDataContent(CreateBoundary());
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
        Argument.AssertNotNull(stream, nameof(stream));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        Add(new StreamContent(stream), name, fileName);
    }

    public void Add(string content, string name, string fileName = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        Add(new StringContent(content), name, fileName);
    }

    public void Add(int content, string name, string fileName = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        string value = content.ToString("G", CultureInfo.InvariantCulture);
        Add(new StringContent(value), name, fileName);
    }

    public void Add(double content, string name, string fileName = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        string value = content.ToString("G", CultureInfo.InvariantCulture);
        Add(new StringContent(value), name, fileName);
    }

    public void Add(byte[] content, string name, string fileName = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        Add(new ByteArrayContent(content), name, fileName);
    }

    public void Add(BinaryData content, string name, string fileName = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        Add(new ByteArrayContent(content.ToArray()), name, fileName);
    }

    private void Add(HttpContent content, string name, string fileName)
    {
        if (fileName is not null)
        {
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));

            AddFileNameHeader(content, name, fileName);
        }

        _multipartContent.Add(content, name);
    }

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
        // TODO: polyfill sync-over-async for netstandard2.0 for Azure clients.
        // Tracked by https://github.com/Azure/azure-sdk-for-net/issues/42674

        //#if NET6_0_OR_GREATER
        _multipartContent.CopyTo(stream, default, cancellationToken);
        //#else
        //#pragma warning disable AZC0107 // DO NOT call public asynchronous method in synchronous scope.
        //        _multipartContent.CopyToAsync(stream).EnsureCompleted();
        //#pragma warning restore AZC0107 // DO NOT call public asynchronous method in synchronous scope.
        //#endif
    }

    public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        //#if NET6_0_OR_GREATER
        await _multipartContent.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
        //#else
        //    await _multipartContent.CopyToAsync(stream).ConfigureAwait(false);
        //#endif
    }

    public override void Dispose()
    {
        _multipartContent.Dispose();
    }
}
#endif
