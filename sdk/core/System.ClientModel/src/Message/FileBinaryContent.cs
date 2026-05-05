// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel;

/// <summary>
/// Represents file content for use in HTTP requests, in particular as a part of a
/// multipart form-data payload. Instances created from a file path open the underlying
/// file lazily on first write so that constructing the type does not allocate an
/// operating system file handle.
/// </summary>
public class FileBinaryContent : BinaryContent
{
    private const string DefaultMediaType = "application/octet-stream";

    private readonly Lazy<BinaryContent> _content;
    private readonly Stream? _stream;
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

        _content = new Lazy<BinaryContent>(() => Create(data.ToStream()));
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

        _stream = stream;
        _content = new Lazy<BinaryContent>(() => Create(stream));
        MediaType = mediaType;
    }

    /// <summary>
    /// Creates an instance of <see cref="FileBinaryContent"/> that reads from the file
    /// at <paramref name="path"/>. The file is opened lazily on the first write or
    /// length computation so that simply constructing the instance does not hold an
    /// operating system file handle. The file is opened at most once even under
    /// concurrent first calls; if the file cannot be opened at that time, the
    /// underlying I/O exception (for example <see cref="FileNotFoundException"/> or
    /// <see cref="UnauthorizedAccessException"/>) is propagated to the caller.
    /// </summary>
    /// <param name="path">The path to the file to send.</param>
    /// <param name="mediaType">The media type of the content.</param>
    public FileBinaryContent(string path, string? mediaType = DefaultMediaType)
    {
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        _content = new Lazy<BinaryContent>(() =>
        {
            FileStream fileStream = File.OpenRead(path);
            try
            {
                return Create(fileStream);
            }
            catch
            {
                fileStream.Dispose();
                throw;
            }
        });
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

        if (_content.IsValueCreated)
        {
            _content.Value.Dispose();
        }
        _stream?.Dispose();
        _disposed = true;
    }

    /// <inheritdoc/>
    public override bool TryComputeLength(out long length)
    {
        try
        {
            return _content.Value.TryComputeLength(out length);
        }
        catch
        {
            length = 0;
            return false;
        }
    }

    /// <inheritdoc/>
    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
        => _content.Value.WriteTo(stream, cancellationToken);

    /// <inheritdoc/>
    public override Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
        => _content.Value.WriteToAsync(stream, cancellationToken);
}
