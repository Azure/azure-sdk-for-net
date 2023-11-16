// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ClientModel.Primitives.Pipeline;

// TODO: can we make it a class? ... but it means all existing polices need to inherit from it.
public interface IPipelinePolicy<TMessage>
{
    void Process(TMessage message, IPipelineEnumerator pipeline);

    ValueTask ProcessAsync(TMessage message, IPipelineEnumerator pipeline);
}

// TODO: perf tradeoff between a struct you only ever call methods on through
// the interface it implements vs. an abstract class you have to allocate every time?
public interface IPipelineEnumerator
{
    int Length { get; }

    bool ProcessNext();

    ValueTask<bool> ProcessNextAsync();
}
