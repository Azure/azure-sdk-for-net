// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.Projects;

internal partial class GenericActionPipelinePolicy : PipelinePolicy
{
    private readonly Action<PipelineRequest> _requestAction;
    private readonly Action<PipelineResponse> _responseAction;
    private readonly Action<PipelineMessage> _messageAction;

    public GenericActionPipelinePolicy(Action<PipelineRequest> requestAction = null, Action<PipelineResponse> responseAction = null, Action<PipelineMessage> messageAction = null)
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
        _messageAction = (message) =>
        {
            if (message is not null)
            {
                messageAction?.Invoke(message);
            }
        };
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _messageAction?.Invoke(message);
        _requestAction?.Invoke(message.Request);
        ProcessNext(message, pipeline, currentIndex);
        _responseAction?.Invoke(message.Response);
        _messageAction?.Invoke(message);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _messageAction?.Invoke(message);
        _requestAction?.Invoke(message.Request);
        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        _responseAction?.Invoke(message.Response);
        _messageAction?.Invoke(message);
    }
}
