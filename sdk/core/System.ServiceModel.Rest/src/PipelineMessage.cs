// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest.Core;

public class PipelineMessage : IDisposable
{
    private PipelineResponse? _response;

    protected internal PipelineMessage(PipelineRequest request, ResponseErrorClassifier classifier)
    {
        Request = request;
        ResponseClassifier = classifier;

        // TODO: take options and wire them through?
    }

    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    public virtual PipelineRequest Request { get; }

    public virtual PipelineResponse Response
    {
        get
        {
            if (_response is null)
            {
                throw new InvalidOperationException("Response was not set.");
            }

            return _response;
        }

        set => _response = value;
    }

    public virtual ResponseErrorClassifier ResponseClassifier { get; set; }

    public virtual void Dispose()
    {
        // TODO: implement Dispose pattern properly
        Request.Dispose();
        Response.Dispose();
    }
}
