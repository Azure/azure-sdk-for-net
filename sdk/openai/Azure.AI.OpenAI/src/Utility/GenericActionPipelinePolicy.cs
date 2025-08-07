// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

internal partial class GenericActionPipelinePolicy : PipelinePolicy
{
    private Action<PipelineRequest> _requestAction;
    private Action<PipelineResponse> _responseAction;

    public GenericActionPipelinePolicy(Action<PipelineRequest> requestAction = null, Action<PipelineResponse> responseAction = null)
    {
        _requestAction = requestAction;
        _responseAction = responseAction;
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
