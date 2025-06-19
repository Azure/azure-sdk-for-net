// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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
    private int _status;
    private string _reasonPhrase;
    private Stream? _contentStream;
    private BinaryData? _bufferedContent;
    private bool _disposed;
    private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

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
        if (!_headers.TryGetValue(name, out List<string>? values))
        {
            _headers[name] = values = new List<string>();
        }

        values.Add(value);
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
        get => _contentStream;
        set => _contentStream = value;
    }

    /// <inheritdoc/>
    public override BinaryData Content
    {
        get
        {
            if (_contentStream is null)
            {
                return new BinaryData(Array.Empty<byte>());
            }

            if (ContentStream is not MemoryStream memoryContent)
            {
                throw new InvalidOperationException($"The response is not buffered.");
            }

            if (memoryContent.TryGetBuffer(out ArraySegment<byte> segment))
            {
                return new BinaryData(segment.AsMemory());
            }
            else
            {
                return new BinaryData(memoryContent.ToArray());
            }
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

    /// <inheritdoc/>
    protected void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
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
        _contentStream = bufferStream;

        // Less efficient FromStream method called here because it is a mock.
        // For intended production implementation, see HttpClientTransportResponse.
        _bufferedContent = BinaryData.FromStream(bufferStream);
        _contentStream.Seek(0, SeekOrigin.Begin);
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

        _contentStream = bufferStream;

        // Less efficient FromStream method called here because it is a mock.
        // For intended production implementation, see HttpClientTransportResponse.
        _bufferedContent = BinaryData.FromStream(bufferStream);
        _contentStream.Seek(0, SeekOrigin.Begin);
        return _bufferedContent;
    }
}
