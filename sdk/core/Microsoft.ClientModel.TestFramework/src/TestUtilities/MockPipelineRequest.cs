// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Microsoft.ClientModel.TestFramework.Mocks;

/// <summary>
/// A mock of <see cref="PipelineRequest"/> to use for testing.
/// </summary>
public class MockPipelineRequest : PipelineRequest
{
    private string _method;
    private Uri? _uri;
    private BinaryContent? _content;
    private readonly MockPipelineRequestHeaders _headers = new();

    /// <summary>
    /// Initializes a new instance of <see cref="MockPipelineRequest"/> with default values.
    /// </summary>
    public MockPipelineRequest()
    {
        _method = "GET";
        _uri = new Uri("https://www.example.com");
    }

    /// <inheritdoc />
    protected override BinaryContent? ContentCore
    {
        get => _content;
        set => _content = value;
    }

    /// <inheritdoc />
    protected override PipelineRequestHeaders HeadersCore
        => _headers;

    /// <inheritdoc />
    protected override string MethodCore
    {
        get => _method;
        set => _method = value;
    }

    /// <inheritdoc />
    protected override Uri? UriCore
    {
        get => _uri;
        set => _uri = value;
    }

    /// <summary>
    /// Releases all resources used by the <see cref="MockPipelineRequest"/>.
    /// This is a no-op implementation since mock requests don't hold unmanaged resources.
    /// </summary>
    public sealed override void Dispose()
    {
    }
}
