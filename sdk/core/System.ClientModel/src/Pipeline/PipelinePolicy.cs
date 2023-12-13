// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelinePolicy
{
    public abstract void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex);

    public abstract ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex);

    protected virtual bool ProcessNext(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        currentIndex++;
        pipeline[currentIndex].Process(message, pipeline, currentIndex);
        return currentIndex < pipeline.Count;
    }

    protected virtual async Task<bool> ProcessNextAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        currentIndex++;
        await pipeline[currentIndex].ProcessAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        return currentIndex < pipeline.Count;
    }
}
