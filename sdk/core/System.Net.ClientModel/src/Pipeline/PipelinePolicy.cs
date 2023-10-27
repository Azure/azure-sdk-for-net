// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.Net.ClientModel.Core;

public abstract class PipelinePolicy
{
    public abstract void Process(PipelineMessage message, IPipelineEnumerator pipeline);

    public abstract ValueTask ProcessAsync(PipelineMessage message, IPipelineEnumerator pipeline);
}

// TODO: perf tradeoff between a struct you only ever call methods on through
// the interface it implements vs. an abstract class you have to allocate every time?
public interface IPipelineEnumerator
{
    int Length { get; }

    bool ProcessNext();

    ValueTask<bool> ProcessNextAsync();
}
