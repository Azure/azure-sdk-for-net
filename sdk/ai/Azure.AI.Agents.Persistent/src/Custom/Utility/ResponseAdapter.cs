// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Adapts an Azure.Core Response to an SCM PipelineResponse.
/// </summary>
internal class ResponseAdapter : PipelineResponse
{
    private readonly Response _azureResponse;
    private PipelineResponseHeaders? _headers;

    public ResponseAdapter(Response azureResponse)
    {
        _azureResponse = azureResponse;
    }

    public override int Status => _azureResponse.Status;

    public override string ReasonPhrase => _azureResponse.ReasonPhrase;

    public override Stream? ContentStream
    {
        get => _azureResponse?.ContentStream;
        set => _azureResponse.ContentStream = value;
    }

    public override BinaryData Content => _azureResponse.Content;

    protected override PipelineResponseHeaders HeadersCore =>
        _headers ??= new ResponseHeadersAdapter(_azureResponse.Headers);

    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException("Content buffering is not supported for SSE response streams.");
    }

    public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException("Content buffering is not supported for SSE response streams.");
    }

    public override void Dispose() => _azureResponse?.Dispose();
}
