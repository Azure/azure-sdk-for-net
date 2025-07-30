// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

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
    /// <param name="mediaType"></param>
    public FileBinaryContent(BinaryData data, string? mediaType = "application/octet-stream")
    {
        Argument.AssertNotNull(data, nameof(data));

        _content = Create(data);
        MediaType = mediaType;
    }

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/>.
    /// </summary>
    public FileBinaryContent(Stream stream, string? mediaType = "application/octet-stream")
    {
        Argument.AssertNotNull(stream, nameof(stream));

        _content = Create(stream);
        MediaType = mediaType;
    }

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/>.
    /// </summary>
    public FileBinaryContent(string path, string? mediaType = "application/octet-stream")
    {
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        FileStream fileStream = File.OpenRead(path);
        _content = Create(fileStream);
        MediaType = mediaType;
    }

    /// <summary>
    /// The name of the file to be used when uploading this content.
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
