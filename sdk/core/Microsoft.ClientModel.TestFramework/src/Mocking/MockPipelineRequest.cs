// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Microsoft.ClientModel.TestFramework.Mocks;

/// <summary>
/// TODO.
/// </summary>
public class MockPipelineRequest : PipelineRequest
{
    private string _method;
    private Uri? _uri;
    private BinaryContent? _content;
    private readonly PipelineRequestHeaders _headers;

    private bool _disposed;

    /// <summary>
    /// TODO.
    /// </summary>
    public MockPipelineRequest()
    {
        _headers = new MockRequestHeaders();
        _method = "GET";
        _uri = new Uri("https://www.example.com");
    }

    /// <summary>
    /// TODO.
    /// </summary>
    protected override BinaryContent? ContentCore
    {
        get => _content;
        set => _content = value;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    protected override PipelineRequestHeaders HeadersCore
        => _headers;

    /// <summary>
    /// TODO.
    /// </summary>
    protected override string MethodCore
    {
        get => _method;
        set => _method = value;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    protected override Uri? UriCore
    {
        get => _uri;
        set => _uri = value;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    public sealed override void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="disposing"></param>
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
