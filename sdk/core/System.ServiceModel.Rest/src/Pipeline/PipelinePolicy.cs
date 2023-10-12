// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

public abstract class PipelinePolicy<TMessage> where TMessage : PipelineMessage
{
    public abstract void Process(TMessage message, IPipelineEnumerator pipeline);

    public abstract ValueTask ProcessAsync(TMessage message, IPipelineEnumerator pipeline);
}

// TODO: perf tradeoff between a struct you only ever call methods on through
// the interface it implements vs. an abstract class you have to allocate every time?
public interface IPipelineEnumerator
{
    int Length { get; }

    bool ProcessNext();

    ValueTask<bool> ProcessNextAsync();
}
