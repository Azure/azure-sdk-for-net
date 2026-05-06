// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel;

/// <summary>
/// Represents file content that can be sent to a cloud service as part of
/// a <see cref="PipelineRequest"/>.
/// </summary>
[Experimental("SCME0004")]
public sealed class FileBinaryContent : BinaryContent
{
    private const string DefaultMediaType = "application/octet-stream";

    private readonly BinaryContent _content;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of <see cref="FileBinaryContent"/> that contains
    /// the bytes held in the provided <see cref="BinaryData"/> instance.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> containing the bytes
    /// this <see cref="FileBinaryContent"/> will hold.</param>
    /// <param name="mediaType">The media type of the content. Ignored if
    /// <paramref name="data"/> already specifies a media type via
    /// <see cref="BinaryData.MediaType"/>.</param>
    public FileBinaryContent(BinaryData data, string? mediaType = DefaultMediaType)
    {
        Argument.AssertNotNull(data, nameof(data));

        _content = Create(data);
        MediaType = data.MediaType ?? mediaType;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FileBinaryContent"/> that contains
    /// the bytes held in the provided <see cref="Stream"/> instance.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> containing the bytes
    /// this <see cref="FileBinaryContent"/> will hold.</param>
    /// <param name="mediaType">The media type of the content.</param>
    public FileBinaryContent(Stream stream, string? mediaType = DefaultMediaType)
    {
        Argument.AssertNotNull(stream, nameof(stream));

        _content = Create(stream);
        MediaType = mediaType;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FileBinaryContent"/> that contains
    /// the bytes held in the file at the provided path.
    /// </summary>
    /// <remarks>
    /// The file is opened on the first call to <see cref="WriteTo"/>,
    /// <see cref="WriteToAsync"/>, or <see cref="TryComputeLength"/>.
    /// </remarks>
    /// <param name="path">The path to the file containing the bytes
    /// this <see cref="FileBinaryContent"/> will hold.</param>
    /// <param name="mediaType">The media type of the content.</param>
    public FileBinaryContent(string path, string? mediaType = DefaultMediaType)
    {
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        _content = new FileFromPathContent(path);
        MediaType = mediaType;

        string filename = Path.GetFileName(path);
        Filename = string.IsNullOrEmpty(filename)
            ? null
            : filename;
    }

    /// <summary>
    /// Gets or sets the file name associated with this file content.
    /// </summary>
    public string? Filename { get; set; }

    /// <inheritdoc/>
    public override bool TryComputeLength(out long length)
    {
        try
        {
            return _content.TryComputeLength(out length);
        }
        catch
        {
            length = 0;
            return false;
        }
    }

    /// <inheritdoc/>
    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(stream, nameof(stream));
        CheckDisposed();
        cancellationToken.ThrowIfCancellationRequested();

        _content.WriteTo(stream, cancellationToken);
    }

    /// <inheritdoc/>
    public override Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(stream, nameof(stream));
        CheckDisposed();
        cancellationToken.ThrowIfCancellationRequested();

        return _content.WriteToAsync(stream, cancellationToken);
    }

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

    private void CheckDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(FileBinaryContent));
        }
    }

    private sealed class FileFromPathContent : BinaryContent
    {
        private readonly Lazy<BinaryContent> _content;
        private bool _disposed;

        public FileFromPathContent(string path)
        {
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
        }

        public override bool TryComputeLength(out long length)
            => _content.Value.TryComputeLength(out length);

        public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
            => _content.Value.WriteTo(stream, cancellationToken);

        public override Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
            => _content.Value.WriteToAsync(stream, cancellationToken);

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

            _disposed = true;
        }
    }
}
