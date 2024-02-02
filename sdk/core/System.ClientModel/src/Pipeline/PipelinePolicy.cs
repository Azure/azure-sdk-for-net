// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelinePolicy
{
    public abstract void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex);

    public abstract ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex);

    protected static void ProcessNext(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        currentIndex++;

        Debug.Assert(currentIndex < pipeline.Count);

        pipeline[currentIndex].Process(message, pipeline, currentIndex);
    }

    protected static async ValueTask ProcessNextAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        currentIndex++;

        Debug.Assert(currentIndex < pipeline.Count);

        await pipeline[currentIndex].ProcessAsync(message, pipeline, currentIndex).ConfigureAwait(false);
    }
}
