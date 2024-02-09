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

    private readonly PipelineResponseHeaders _headers;

    private bool _disposed;

    public MockPipelineResponse(int status = 0, string reasonPhrase = "")
    {
        _status = status;
        _reasonPhrase = reasonPhrase;
        _headers = new MockResponseHeaders();
    }

    public override int Status => _status;

    public void SetStatus(int value) => _status = value;

    public override string ReasonPhrase => _reasonPhrase;

    public void SetReasonPhrase(string value) => _reasonPhrase = value;

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
                return BinaryData.FromString("");
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

    protected override PipelineResponseHeaders GetHeadersCore() => _headers;

    public sealed override void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var content = _contentStream;
            if (content != null)
            {
                _contentStream = null;
                content.Dispose();
            }

            _disposed = true;
        }
    }

    protected override BinaryData ReadContent(CancellationToken cancellationToken = default)
    {
        if (_bufferedContent is not null)
        {
            return _bufferedContent;
        }

        if (_contentStream is null)
        {
            _bufferedContent = BinaryData.FromString(string.Empty);
            return _bufferedContent;
        }

        MemoryStream bufferStream = new();
        _contentStream.CopyTo(bufferStream);
        _contentStream.Dispose();
        _contentStream = bufferStream;

        _bufferedContent = BinaryData.FromStream(bufferStream);
        return _bufferedContent;
    }

    protected override async ValueTask<BinaryData> ReadContentAsync(CancellationToken cancellationToken = default)
    {
        if (_bufferedContent is not null)
        {
            return _bufferedContent;
        }

        if (_contentStream is null)
        {
            _bufferedContent = BinaryData.FromString(string.Empty);
            return _bufferedContent;
        }

        MemoryStream bufferStream = new();
        await _contentStream.CopyToAsync(bufferStream).ConfigureAwait(false);
        _contentStream.Dispose();
        _contentStream = bufferStream;

        _bufferedContent = BinaryData.FromStream(bufferStream);
        return _bufferedContent;
    }
}
