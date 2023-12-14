// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;

namespace TestHelpers.Internal;

internal class MockPipelineResponse : PipelineResponse
{
    private int _status;
    private string _reasonPhrase;
    private Stream? _contentStream;

    private readonly MessageHeaders _headers;

    private bool _disposed;

    public MockPipelineResponse()
    {
        _status = 0;
        _reasonPhrase = string.Empty;
        _headers = new MockMessageHeaders();
    }

    public override int Status => _status;

    public void SetStatus(int value) => _status = value;

    public override string ReasonPhrase => _reasonPhrase;

    public void SetReasonPhrase(string value) => _reasonPhrase = value;

    public override Stream? ContentStream
    {
        get => _contentStream;
        set => _contentStream = value;
    }

    protected override MessageHeaders GetHeadersCore() => _headers;

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
