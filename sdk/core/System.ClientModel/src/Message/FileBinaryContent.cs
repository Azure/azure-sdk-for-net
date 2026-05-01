// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel;

/// <summary>
/// FileBinaryContent
/// </summary>
public class FileBinaryContent : BinaryContent
{
    private const string DefaultMediaType = "application/octet-stream";

    private readonly BinaryContent _content;
    private bool _disposed;

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/>.
    /// </summary>
    /// <param name="data">The content to send.</param>
    /// <param name="mediaType">The media type to use when <paramref name="data"/> does not
    /// already carry one via <see cref="BinaryData.MediaType"/>. To override an existing
    /// media type on <paramref name="data"/>, use
    /// <see cref="BinaryData.WithMediaType(string?)"/> before passing it in.</param>
    public FileBinaryContent(BinaryData data, string? mediaType = DefaultMediaType)
    {
        Argument.AssertNotNull(data, nameof(data));

        _content = Create(data);
        MediaType = data.MediaType ?? mediaType;
    }

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/> from an existing
    /// <see cref="Stream"/>.
    /// </summary>
    /// <param name="stream">The seekable stream containing the file's bytes. On
    /// successful construction, the <see cref="FileBinaryContent"/> takes ownership
    /// of the stream and disposes it when the content is disposed.</param>
    /// <param name="mediaType">The media type of the content.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="stream"/> is
    /// not seekable. The caller retains ownership of <paramref name="stream"/> in
    /// this case.</exception>
    public FileBinaryContent(Stream stream, string? mediaType = DefaultMediaType)
    {
        Argument.AssertNotNull(stream, nameof(stream));

        _content = Create(stream);
        MediaType = mediaType;
    }

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/>.
    /// </summary>
    public FileBinaryContent(string path, string? mediaType = DefaultMediaType)
    {
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        FileStream fileStream = File.OpenRead(path);
        try
        {
            _content = Create(fileStream);
        }
        catch
        {
            fileStream.Dispose();
            throw;
        }
        MediaType = mediaType;
        Filename = Path.GetFileName(path);
    }

    /// <summary>
    /// The name of the file to be used when uploading this content.
    /// </summary>
    public string? Filename { get; set; }

    /// <inheritdoc/>
    public override void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _content.Dispose();
        _disposed = true;
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
