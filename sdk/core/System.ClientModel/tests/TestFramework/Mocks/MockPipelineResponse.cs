// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;

namespace ClientModel.Tests.Mocks;

public class MockPipelineResponse : PipelineResponse
{
    private int _status;
    private string _reasonPhrase;
    private Stream? _contentStream;

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
        SetContentStream(new MemoryStream(content, 0, content.Length, false, true));
    }

    public MockPipelineResponse SetContent(string content)
    {
        SetContent(Encoding.UTF8.GetBytes(content));
        return this;
    }

    public Stream? ContentStream
    {
        get => GetContentStream();
        set => SetContentStream(value);
    }

    protected override Stream? GetContentStream()
        => _contentStream;

    protected override void SetContentStream(Stream? stream)
        => _contentStream = stream;

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
}
