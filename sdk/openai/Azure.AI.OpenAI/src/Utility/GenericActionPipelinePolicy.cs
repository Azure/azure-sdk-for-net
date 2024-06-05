// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

internal partial class GenericActionPipelinePolicy : PipelinePolicy
{
    private Action<PipelineMessage> _processMessageAction;

    public GenericActionPipelinePolicy(Action<PipelineMessage> processMessageAction)
    {
        _processMessageAction = processMessageAction;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _processMessageAction(message);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _processMessageAction(message);
        return ProcessNextAsync(message, pipeline, currentIndex);
    }
}
