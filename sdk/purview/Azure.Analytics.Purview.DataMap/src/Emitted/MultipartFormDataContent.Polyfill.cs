// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Analytics.Purview.DataMap;

#if !NET6_0_OR_GREATER
internal class MultipartFormDataBinaryContent : RequestContent
{
    private static Random _random = new();
    private static readonly char[] _boundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz".ToCharArray();

    private PrototypeMultipartContent _multipartContent;

    public MultipartFormDataBinaryContent()
    {
        _multipartContent = new(CreateBoundary());
    }

    // TODO: optimize
    public string ContentType => _multipartContent.ContentType;

    public void Add(Stream stream, string name, string fileName = default)
    {
        Add(Create(stream), name, fileName);
    }

    public void Add(string content, string name, string fileName = default)
    {
        Add(Create(content), name, fileName);
    }

    public void Add(int content, string name, string fileName = default)
    {
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        string value = content.ToString("G", CultureInfo.InvariantCulture);
        Add(Create(value), name, fileName);
    }

    public void Add(double content, string name, string fileName = default)
    {
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        string value = content.ToString("G", CultureInfo.InvariantCulture);
        Add(Create(value), name, fileName);
    }

    public void Add(byte[] content, string name, string fileName = default)
    {
        Add(Create(content), name, fileName);
    }

    public void Add(BinaryData content, string name, string fileName = default)
    {
        Add(Create(content), name, fileName);
    }

    private void Add(RequestContent content, string name, string fileName)
    {
        ContentDispositionHeaderValue header = fileName is not null ?
            // TODO: optimize per strings
            new("form-data")
            {
                Name = name,
                FileName = fileName
            } :
            new("form-data")
            {
                Name = name
            };

        _multipartContent.Add(content, ("Content-Disposition", header.ToString()));
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
        => _multipartContent.TryComputeLength(out length);

    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
        => _multipartContent.WriteTo(stream, cancellationToken);

    public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
        => await _multipartContent.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);

    public override void Dispose()
        => _multipartContent.Dispose();
}
#endif
