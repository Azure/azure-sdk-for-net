// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Emitted;

#if !NET6_0_OR_GREATER
/*TODO internal*/
public class MultipartFormDataRequestContent : RequestContent
{
    private readonly PrototypeMultipartContent _multipartContent;

    public MultipartFormDataRequestContent()
    {
        _multipartContent = new();
    }

    // TODO: optimize
    public string ContentType => _multipartContent.ContentType;

    public void Add(Stream stream, string name, string? fileName = default)
    {
        Argument.AssertNotNull(stream, nameof(stream));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        Add(Create(stream), name, fileName);
    }

    public void Add(string content, string name, string? fileName = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        // TODO: validate header addition for string content & refactor

        Add(Create(content), name, fileName, ("Content-Type", "text/plain; charset=utf-8"));
    }

    public void Add(int content, string name, string? fileName = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        string value = content.ToString("G", CultureInfo.InvariantCulture);
        Add(Create(value), name, fileName, ("Content-Type", "text/plain; charset=utf-8"));
    }

    public void Add(double content, string name, string? fileName = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#GFormatString
        string value = content.ToString("G", CultureInfo.InvariantCulture);
        Add(Create(value), name, fileName, ("Content-Type", "text/plain; charset=utf-8"));
    }

    public void Add(byte[] content, string name, string? fileName = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        Add(Create(content), name, fileName);
    }

    public void Add(BinaryData content, string name, string? fileName = default)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        Add(Create(content), name, fileName);
    }

    // TODO: optmize per params
    private void Add(RequestContent content, string name, string? fileName, (string Name, string Value) header = default)
    {
        if (fileName is not null)
        {
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
        }

        ContentDispositionHeaderValue contentDispositionHeader = fileName is not null ?
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

        if (header != default)
        {
            _multipartContent.Add(content, header, ("Content-Disposition", contentDispositionHeader.ToString()));
        }
        else
        {
            _multipartContent.Add(content, ("Content-Disposition", contentDispositionHeader.ToString()));
        }
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
