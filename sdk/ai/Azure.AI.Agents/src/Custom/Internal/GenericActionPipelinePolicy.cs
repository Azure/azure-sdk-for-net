// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.Agents;

internal partial class GenericActionPipelinePolicy : PipelinePolicy
{
    private readonly Action<PipelineRequest> _requestAction;
    private readonly Action<PipelineResponse> _responseAction;

    public GenericActionPipelinePolicy(Action<PipelineRequest> requestAction = null, Action<PipelineResponse> responseAction = null)
    {
        _requestAction = (request) =>
        {
            if (request is not null)
            {
                requestAction?.Invoke(request);
            }
        };
        _responseAction = (response) =>
        {
            if (response is not null)
            {
                responseAction?.Invoke(response);
            }
        };
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _requestAction?.Invoke(message.Request);
        ProcessNext(message, pipeline, currentIndex);
        _responseAction?.Invoke(message.Response);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _requestAction?.Invoke(message.Request);
        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        _responseAction?.Invoke(message.Response);
    }
}
