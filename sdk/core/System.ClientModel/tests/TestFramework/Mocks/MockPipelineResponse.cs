// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockPipelineResponse : PipelineResponse
{
    private int _status;
    private string _reasonPhrase;
    private Stream? _contentStream;
    private BinaryData? _bufferedContent;

    private readonly MockResponseHeaders _headers;

    private bool _disposed;

    public MockPipelineResponse(int status = 0, string reasonPhrase = "", MockResponseHeaders? mockHeaders = default)
    {
        _status = status;
        _reasonPhrase = reasonPhrase;
        _headers = mockHeaders ?? new MockResponseHeaders();
    }

    public override int Status => _status;

    public void SetStatus(int value) => _status = value;

    public override string ReasonPhrase => _reasonPhrase;

    public void SetReasonPhrase(string value) => _reasonPhrase = value;

    public void SetHeader(string name, string value)
        => _headers.SetHeader(name, value);

    public void SetContent(byte[] content)
    {
        ContentStream = new MemoryStream(content, 0, content.Length, false, true);
    }

    public MockPipelineResponse SetContent(string content)
    {
        SetContent(Encoding.UTF8.GetBytes(content));
        return this;
    }

    public override Stream? ContentStream
    {
        get => _contentStream;
        set => _contentStream = value;
    }

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

    protected override PipelineResponseHeaders HeadersCore
        => _headers;

    public sealed override void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

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
