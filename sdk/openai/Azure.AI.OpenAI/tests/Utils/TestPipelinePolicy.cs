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
        _processRequestAction?.Invoke(message?.Request);
        ProcessNext(message, pipeline, currentIndex);
        _processResponseAction?.Invoke(message?.Response);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _processRequestAction?.Invoke(message?.Request);
        await ProcessNextAsync(message, pipeline, currentIndex);
        _processResponseAction?.Invoke(message?.Response);
    }
}
