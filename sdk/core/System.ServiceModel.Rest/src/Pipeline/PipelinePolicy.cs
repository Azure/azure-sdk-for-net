// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

public abstract class PipelinePolicy : IPipelinePolicy<PipelineMessage, PipelinePolicy>
{
    public abstract void Process(PipelineMessage message, ReadOnlyMemory<PipelinePolicy> pipeline);

    public abstract ValueTask ProcessAsync(PipelineMessage message, ReadOnlyMemory<PipelinePolicy> pipeline);

    protected static void ProcessNext(PipelineMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
    {
        pipeline.Span[0].Process(message, pipeline.Slice(1));
    }

    protected static ValueTask ProcessNextAsync(PipelineMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
    {
        return pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1));
    }
}
