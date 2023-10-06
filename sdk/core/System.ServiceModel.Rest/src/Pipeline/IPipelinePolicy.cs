// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

// TODO: can we make it a class? ... but it means all existing polices need to inherit from it.
public interface IPipelinePolicy<TMessage, TPolicy>
    where TPolicy : IPipelinePolicy<TMessage, TPolicy>
{
    void Process(TMessage message, ReadOnlyMemory<TPolicy> pipeline);

    ValueTask ProcessAsync(TMessage message, ReadOnlyMemory<TPolicy> pipeline);
}

//public abstract class PipelineEnumerator
//{
//    public int Length { get; internal set; }

//    public abstract bool ProcessNext();

//    public abstract ValueTask<bool> ProcessNextAsync();
//}
