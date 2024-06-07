// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI.Tests;

internal partial class TestPipelinePolicy : PipelinePolicy
{
    private readonly Action<PipelineRequest> _processRequestAction;
    private readonly Action<PipelineResponse> _processResponseAction;

    public TestPipelinePolicy(Action<PipelineRequest> requestAction, Action<PipelineResponse> responseAction)
    {
        _processRequestAction = requestAction;
        _processResponseAction = responseAction;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        InvokeActions(message);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        InvokeActions(message);
        return ProcessNextAsync(message, pipeline, currentIndex);
    }

    private void InvokeActions(PipelineMessage message)
    {
        if (message?.Request is not null)
        {
            _processRequestAction?.Invoke(message.Request);
        }
        if (message?.Response is not null)
        {
            _processResponseAction?.Invoke(message.Response);
        }
    }
}
