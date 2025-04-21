// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// FileBinaryContent
/// </summary>
public partial class FileBinaryContent : BinaryContent
{
    private readonly BinaryContent _content;

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/>.
    /// </summary>
    /// <param name="data"></param>
    public FileBinaryContent(BinaryData data)
    {
        Argument.AssertNotNull(data, nameof(data));
        _content = Create(data);
    }

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/>.
    /// </summary>
    public FileBinaryContent(Stream stream)
    {
        Argument.AssertNotNull(stream, nameof(stream));
        _content = Create(stream);
    }

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/>.
    /// </summary>
    public FileBinaryContent(string path)
    {
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        FileStream fileStream = File.OpenRead(path);
        _content = Create(fileStream);
    }

    /// <summary>
    /// The content type of the file.
    /// </summary>
    public string ContentType { get; set; } = "application/octet-stream";

    /// <summary>
    /// The filename.
    /// </summary>
    public string? Filename { get; set; }

    /// <inheritdoc/>
    public override void Dispose()
    {
        _content.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    public override bool TryComputeLength(out long length)
        => _content.TryComputeLength(out length);

    /// <inheritdoc/>
    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
        => _content.WriteTo(stream, cancellationToken);

    /// <inheritdoc/>
    public override Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
        => _content.WriteToAsync(stream, cancellationToken);
}
