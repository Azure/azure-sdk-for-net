// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace Azure.AI.Project;

/// <summary>
/// Adapts an Azure.Core Response to an SCM PipelineResponse.
/// </summary>
internal class ResponseAdapter : PipelineResponse
{
    private readonly Response _azureResponse;

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
        _azureResponse.Headers;

    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override void Dispose() => _azureResponse?.Dispose();
}
