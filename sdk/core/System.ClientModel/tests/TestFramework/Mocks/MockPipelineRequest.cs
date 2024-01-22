// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace ClientModel.Tests.Mocks;

public class MockPipelineRequest : PipelineRequest
{
    private string _method;
    private Uri? _uri;
    private BinaryContent? _content;
    private readonly PipelineRequestHeaders _headers;

    private bool _disposed;

    public MockPipelineRequest()
    {
        _headers = new MockRequestHeaders();
        _method = "GET";
    }

    protected override BinaryContent? GetContentCore()
        => _content;

    protected override PipelineRequestHeaders GetHeadersCore()
        => _headers;

    protected override string GetMethodCore()
        => _method;

    protected override Uri GetUriCore()
    {
        if (_uri is null)
        {
            throw new InvalidOperationException("Uri has not be set on HttpMessageRequest instance.");
        }

        return _uri;
    }

    protected override void SetContentCore(BinaryContent? content)
        => _content = content;

    protected override void SetMethodCore(string method)
        => _method = method;

    protected override void SetUriCore(Uri uri)
        => _uri = uri;

    public sealed override void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var content = _content;
            if (content != null)
            {
                _content = null;
                content.Dispose();
            }

            _disposed = true;
        }
    }
}