// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest.Core;

public class PipelineMessage : IDisposable
{
    private readonly PipelineRequest _request;
    private readonly ResponseErrorClassifier _classifier;

    private PipelineResponse? _response;

    public PipelineMessage(PipelineRequest request, ResponseErrorClassifier classifier)
    {
        _request = request;
        _classifier = classifier;
    }

    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    public virtual PipelineRequest PipelineRequest
    {
        get => _request;
        //set => _request = value;
    }

    public virtual PipelineResponse? PipelineResponse
    {
        get => _response;
        set => _response = value;
    }

    public virtual ResponseErrorClassifier ResponseErrorClassifier
    {
        get => _classifier;
        //set => _classifier = value;
    }

    public virtual void Dispose()
    {
        // TODO: implement Dispose pattern properly
        _request.Dispose();

        // TODO: should response be disposable?
    }
}
