// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Mocks;

/// <summary>
/// A mock of <see cref="PipelineResponse"/> to use for testing.
/// </summary>
public class MockPipelineResponse : PipelineResponse
{
    private readonly int _status;
    private readonly string _reasonPhrase;
    private Stream? _contentStream;
    private BinaryData? _bufferedContent;
    private bool _disposed;
    private readonly MockPipelineResponseHeaders _headers = new();

    /// <summary>
    /// Creates an instance of <see cref="MockPipelineResponse"/> to use for testing.
    /// </summary>
    /// <param name="status">The status code of the mock HTTP response.</param>
    /// <param name="reasonPhrase">The reason phrase of the mock HTTP response.</param>
    public MockPipelineResponse(int status = 0, string reasonPhrase = "")
    {
        _status = status;
        _reasonPhrase = reasonPhrase;
    }

    /// <summary>
    /// Gets a value indicating whether this mock response has been disposed.
    /// </summary>
    public bool IsDisposed
    {
        get => _disposed;
    }

    /// <inheritdoc/>
    public override int Status => _status;

    /// <inheritdoc/>
    public override string ReasonPhrase => _reasonPhrase;

    /// <summary>
    /// Sets <see cref="PipelineResponse.IsError"/> to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">A boolean value indicating if the response is an error.</param>
    public void SetIsError(bool value) => IsErrorCore = value;

    /// <summary>
    /// Adds an HTTP header to the <see cref="MockPipelineResponse"/>.
    /// </summary>
    /// <param name="name">The name of the header to add.</param>
    /// <param name="value">The value of the header to add.</param>
    /// <returns>The modified <see cref="MockPipelineResponse"/>.</returns>
    public MockPipelineResponse WithHeader(string name, string value)
    {
        _headers.SetHeader(name, value);
        return this;
    }

    /// <summary>
    /// Sets the content of the <see cref="MockPipelineResponse"/>.
    /// </summary>
    /// <param name="content">The byte array content to add.</param>
    /// <returns>The modified <see cref="MockPipelineResponse"/>.</returns>
    public MockPipelineResponse WithContent(BinaryContent content)
    {
        MemoryStream contentStream = new();
        content.WriteTo(contentStream);
        contentStream.Position = 0;
        ContentStream = contentStream;
        return this;
    }

    /// <summary>
    /// Sets the content of the <see cref="MockPipelineResponse"/>.
    /// </summary>
    /// <param name="content">The byte array content to add.</param>
    /// <returns>The modified <see cref="MockPipelineResponse"/>.</returns>
    public MockPipelineResponse WithContent(byte[] content)
    {
        ContentStream = new MemoryStream(content, 0, content.Length, false, true);
        return this;
    }

    /// <summary>
    /// Sets the content of the <see cref="MockPipelineResponse"/>.
    /// </summary>
    /// <param name="content">The string content to add.</param>
    /// <returns>The modified <see cref="MockPipelineResponse"/>.</returns>
    public MockPipelineResponse WithContent(string content)
    {
        WithContent(Encoding.UTF8.GetBytes(content));
        return this;
    }

    /// <inheritdoc/>
    public override Stream? ContentStream
    {
        get
        {
            if (_contentStream is not null)
            {
                return _contentStream;
            }
            return BufferContent().ToStream();
        }
        set
        {
            _contentStream = value;
            _bufferedContent = null;
        }
    }

    /// <inheritdoc/>
    public override BinaryData Content
    {
        get
        {
            if (_bufferedContent is not null)
            {
                return _bufferedContent;
            }

            if (_contentStream is null || _contentStream is MemoryStream)
            {
                return BufferContent();
            }

            throw new InvalidOperationException($"The response is not buffered.");
        }
    }

    /// <inheritdoc/>
    protected override PipelineResponseHeaders HeadersCore
        => _headers;

    /// <inheritdoc/>
    public sealed override void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="MockPipelineResponse"/> and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            if (_contentStream is MemoryStream)
            {
                // Ensure content is buffered before disposing the stream
                BufferContent();
            }

            Stream? content = _contentStream;
            if (content != null)
            {
                _contentStream = null;
                content.Dispose();
            }

            _disposed = true;
        }
    }

    /// <inheritdoc/>
    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
    {
        if (_bufferedContent is not null)
        {
            return _bufferedContent;
        }

        if (_contentStream is null)
        {
            _bufferedContent = new BinaryData(Array.Empty<byte>());
            return _bufferedContent;
        }

        MemoryStream bufferStream = new();
        _contentStream.CopyTo(bufferStream);
        _contentStream.Dispose();
        _contentStream = null;
        bufferStream.Position = 0;

        // Less efficient FromStream method called here because it is a mock.
        // For intended production implementation, see HttpClientTransportResponse.
        _bufferedContent = BinaryData.FromStream(bufferStream);
        return _bufferedContent;
    }

    /// <inheritdoc/>
    public override async ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
    {
        if (_bufferedContent is not null)
        {
            return _bufferedContent;
        }

        if (_contentStream is null)
        {
            _bufferedContent = new BinaryData(Array.Empty<byte>());
            return _bufferedContent;
        }

        MemoryStream bufferStream = new();

#if NETSTANDARD2_0 || NETFRAMEWORK
        await _contentStream.CopyToAsync(bufferStream).ConfigureAwait(false);
        _contentStream.Dispose();
#else
        await _contentStream.CopyToAsync(bufferStream, cancellationToken).ConfigureAwait(false);
        await _contentStream.DisposeAsync().ConfigureAwait(false);
#endif

        _contentStream = null;
        bufferStream.Position = 0;

        // Less efficient FromStream method called here because it is a mock.
        // For intended production implementation, see HttpClientTransportResponse.
        _bufferedContent = BinaryData.FromStream(bufferStream);
        return _bufferedContent;
    }
}
